using Infrastructure.Messaging.Interfaces;
using Infrastructure.Messaging.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace SgiAzure.Infrastructure.Messaging
{

    /// <summary>
    /// Proveedor de RabbitMQ encargado de realizar tareas de un Broker de mensajería
    /// </summary>
    public class RabbitMqBroker : IMessageBroker, IAsyncDisposable
    {
        /// <summary>
        /// Logger encargado de loguear los eventos del broker de mensajería
        /// </summary>
        private readonly ILogger<RabbitMqBroker> _logger;

        /// <summary>
        /// Configuración de rabbitmq
        /// </summary>
        private readonly RabbitMQSettings _rabbitMqSettings;

        /// <summary>
        /// Objeto de conexión a la instancia de rabbitmq
        /// </summary>
        private readonly IConnection _connection;

        public RabbitMqBroker(
            ILogger<RabbitMqBroker> logger,
            IOptions<RabbitMQSettings> options,
            IConnection connection)
        {
            _logger = logger;
            _rabbitMqSettings = options.Value;
            _connection = connection;
        }

        /// <summary>
        /// Método estático encargado de crear una instancia del broker de mensajerías
        /// </summary>
        /// <param name="options">Objeto que contiene la parametrización de la conexión al broker de mensajería</param>
        /// <param name="logger">Referencia al logger que se está ejecutando en ese momento</param>
        /// <returns>Retorna una instancia del broker de mensajería de forma asíncrona</returns>
        public static async Task<RabbitMqBroker> CreateAsync(
            IOptions<RabbitMQSettings> options,
            ILogger<RabbitMqBroker> logger)
        {
            var settings = options.Value;

            var factory = new ConnectionFactory
            {
                HostName = settings.Host,
                UserName = settings.Credentials.Username,
                Password = settings.Credentials.Password,
                AutomaticRecoveryEnabled = true,
                NetworkRecoveryInterval = TimeSpan.FromSeconds(5),
                ClientProvidedName = settings.Credentials.ClientProvidedName ?? "SgiAzureApp"
            };

            var connection = await factory.CreateConnectionAsync();

            return new RabbitMqBroker(logger, options, connection);
        }

        public async ValueTask DisposeAsync()
        {
            try
            {
                if (_connection is not null && _connection.IsOpen)
                {
                    await _connection.CloseAsync();
                    _logger.LogInformation("Conexión RabbitMQ cerrada correctamente.");
                }
                _connection?.Dispose();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cerrar la conexión de RabbitMQ.");
            }
        }

        /// <summary>
        /// Método encargado de publicar un mensaje de forma asíncrona
        /// </summary>
        /// <param name="queueName">Nombre de la cola a la cual se intenta conectar</param>
        /// <param name="message">Mensaje a enviar</param>
        /// <param name="exchange">Nombre del exchange</param>
        /// <param name="ct">Token de cancelación del proceso</param>
        /// <returns>Operación asíncrona</returns>
        public async Task PublishAsync(string queueName, string message, string exchange = "", CancellationToken ct = default)
        {
            if (string.IsNullOrEmpty(queueName)) throw new ArgumentException("queueName is required", nameof(queueName));
            if (string.IsNullOrEmpty(message)) throw new ArgumentNullException(nameof(message));

            await using var channel = await _connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(
                    queue: queueName,
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );

            var body = Encoding.UTF8.GetBytes(message);

            var props = new BasicProperties()
            {
                ContentType = "application/json",
                MessageId = Guid.NewGuid().ToString(),
                DeliveryMode = DeliveryModes.Persistent,
            };

            await channel.BasicPublishAsync(
                exchange: exchange,
                routingKey: queueName,
                mandatory: false,
                basicProperties: props,
                body: body
            );

            _logger.LogInformation("Mensaje publicado en la cola {QueueName} con MessageId={MessageId}",
                queueName, props.MessageId);
        }

        /// <summary>
        /// Método encargado de realizar la subscripción a una cola específica.
        /// </summary>
        /// <param name="queueName"></param>
        /// <param name="messageHandler"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task SubscribeAsync(
            string queueName,
            Func<string, IMessageMetadata, CancellationToken, Task> messageHandler,
            CancellationToken ct)
        {
            if (string.IsNullOrWhiteSpace(queueName)) throw new ArgumentException("Queue name is required.", nameof(queueName));
            if (messageHandler is null) throw new ArgumentNullException(nameof(messageHandler));

            var channel = await _connection.CreateChannelAsync(cancellationToken:ct);

            await channel.QueueDeclareAsync(
                queue: queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null,
                cancellationToken: ct
            );

            if (_rabbitMqSettings.PrefetchCount > 0)
            {
                await channel.BasicQosAsync(
                    prefetchSize: 0,
                    prefetchCount: _rabbitMqSettings.PrefetchCount,
                    global: false,
                    cancellationToken: ct
                );
            }

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.ReceivedAsync += async (_, ea) =>
            {
                if (ct.IsCancellationRequested)
                    return;

                var rawBody = ea.Body.ToArray();
                var rawMessage = Encoding.UTF8.GetString(rawBody);

                var metadata = new MessageMetadata
                {
                    Exchange = ea.Exchange,
                    Queue = queueName,
                    RoutingKey = ea.RoutingKey,
                    MessageId = ea.BasicProperties?.MessageId,
                    DeliveryTag = ea.DeliveryTag,
                    Headers = ea.BasicProperties?.Headers,
                    Attempt = 0
                };

                try
                {
                    await messageHandler(rawMessage, metadata, ct);
                    await channel.BasicAckAsync(ea.DeliveryTag, false);
                }
                catch (Exception ex)
                {
                    _logger.LogError(
                        ex,
                        "Error procesando mensaje desde {Queue}. MessageId={MessageId}.",
                        queueName,
                        metadata.MessageId);

                    await channel.BasicNackAsync(ea.DeliveryTag, false, requeue: false);
                }
            };

            await channel.BasicConsumeAsync(
                queue: queueName,
                autoAck: false,
                consumer: consumer
            );

            _logger.LogInformation("Suscrito a la cola {QueueName}", queueName);

            while (!ct.IsCancellationRequested)
            {
                await Task.Delay(500, ct);
            }

            _logger.LogInformation("Cancelando suscripción a la cola {QueueName}", queueName);
        }
    }
}
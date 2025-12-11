using Domain.Interfaces.Entities;
using Infrastructure.Messaging.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using SgiAzure.Domain.Interfaces.Services;
using System.Text;

namespace SgiAzure.Infrastructure.Services
{
    /// <summary>
    /// Servicio para la gestión de mensajería mediante RabbitMQ.
    /// Implementa la interfaz <see cref="IMessagingService"/> y proporciona funcionalidad para publicar, 
    /// consumir, declarar y eliminar colas en RabbitMQ.
    /// </summary>
    public class RabbitMQService : IMessagingService, IAsyncDisposable
    {
        /// <summary>
        /// Conexión activa con el servidor RabbitMQ.
        /// </summary>
        private readonly IConnection _connection;

        /// <summary>
        /// Configuración de RabbitMQ obtenida de <see cref="RabbitMQSettings"/>.
        /// Contiene detalles como el host, credenciales y otros parámetros.
        /// </summary>
        private readonly RabbitMQSettings _rabbitMqSettings;

        /// <summary>
        /// Logger utilizado para registrar eventos e información sobre el funcionamiento del servicio.
        /// </summary>
        private readonly ILogger<RabbitMQService> _logger;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="RabbitMQService"/>.
        /// Configura la conexión con RabbitMQ utilizando las opciones proporcionadas.
        /// </summary>
        /// <param name="options">Configuración de RabbitMQ proporcionada mediante <see cref="IOptions{TOptions}"/>.</param>
        /// <param name="logger">Logger para registrar eventos e información de depuración.</param>
        public RabbitMQService(IOptions<RabbitMQSettings> options, ILogger<RabbitMQService> logger)
        {
            _rabbitMqSettings = options?.Value ?? throw new InvalidOperationException("RabbitMQSettings is missing");
            _logger = logger;

            var factory = new ConnectionFactory
            {
                HostName = _rabbitMqSettings.Host,
                UserName = _rabbitMqSettings.Credentials.Username,
                Password = _rabbitMqSettings.Credentials.Password
            };

            _connection = CreateConnectionRabbitMq(factory).Result;
        }

        /// <summary>
        /// Establece una conexión asincrónica con RabbitMQ utilizando la configuración de la fábrica.
        /// </summary>
        /// <param name="factory">Instancia de <see cref="ConnectionFactory"/> configurada.</param>
        /// <returns>Conexión activa con RabbitMQ.</returns>
        private async Task<IConnection> CreateConnectionRabbitMq(ConnectionFactory factory)
        {
            try
            {
                return await factory.CreateConnectionAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al establecer la conexión con RabbitMQ");
                throw;
            }
        }

        /// <summary>
        /// Publica un mensaje en la cola especificada.
        /// </summary>
        /// <param name="queueName">Nombre de la cola donde se enviará el mensaje.</param>
        /// <param name="message">Mensaje a publicar.</param>
        /// <param name="exchange">Intercambio a utilizar (vacío por defecto).</param>
        public async Task PublishAsync(string queueName, string message, string exchange = "")
        {
            using (var channel = await _connection.CreateChannelAsync())
            {
                await channel.QueueDeclareAsync(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
                var body = Encoding.UTF8.GetBytes(message);
                await channel.BasicPublishAsync(exchange: exchange, routingKey: queueName, body: body);
            }
        }

        /// <summary>
        /// Consume mensajes de una cola de forma asíncrona.
        /// </summary>
        /// <param name="queueName">Nombre de la cola de la que se desean consumir mensajes.</param>
        /// <param name="messageHandler">Función para procesar los mensajes recibidos.</param>
        //public async Task ConsumeAsync(string queueName, Func<string, IMessageMetadata, Task> messageHandler)
        //{
        //    var channel = await _connection.CreateChannelAsync();

        //    var consumer = new AsyncEventingBasicConsumer(channel);
        //    consumer.ReceivedAsync += async (model, ea) =>
        //    {
        //        var body = ea.Body.ToArray();
        //        var message = Encoding.UTF8.GetString(body);
        //        var metadata = new MessageMetadata()
        //        {
        //            Exchange = ea.Exchange,
        //            MessageId = ea.BasicProperties.MessageId,
        //            DeliveryTag = ea.DeliveryTag,
        //            Queue = queueName,
        //            RoutingKey = ea.RoutingKey,
        //            Headers = ea.BasicProperties.Headers,
        //        };
        //        bool isSuccess = false;
        //        int retryCount = 0;
        //        while (retryCount < _rabbitMqSettings.MaxRetryAttemps && !isSuccess ) {
        //            try
        //            {
        //                metadata.Attempt = retryCount;
        //                await messageHandler(message, (IMessageMetadata)metadata);

        //                await channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false);
        //                isSuccess = true;
        //            }
        //            catch (Exception ex)
        //            {

        //                retryCount++;
        //                _logger.LogWarning(ex,"Error procesando el mensaje. Intento {RetryCount} de {MaxRetryAttempts}.", retryCount, _rabbitMqSettings.MaxRetryAttemps);

        //                if (retryCount >= _rabbitMqSettings.MaxRetryAttemps)
        //                {
        //                    await channel.BasicNackAsync(deliveryTag: ea.DeliveryTag, multiple: false, requeue: false);
        //                    _logger.LogError("Mensaje descartado tras {MaxRetryAttempts} intentos fallidos.", _rabbitMqSettings.MaxRetryAttemps);
        //                }
        //                else
        //                {
        //                    await Task.Delay(TimeSpan.FromSeconds(2 * retryCount));
        //                }
        //            }
        //        }
        //    };

        //    await channel.BasicConsumeAsync(queue: queueName, autoAck: false, consumer: consumer);
        //}

        /// <summary>
        /// Declara una nueva cola en RabbitMQ.
        /// </summary>
        /// <param name="queueName">Nombre de la cola a declarar.</param>
        public async Task DeclareQueue(string queueName)
        {
            using (var channel = await _connection.CreateChannelAsync())
            {
                await channel.QueueDeclareAsync(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            }
        }

        /// <summary>
        /// Elimina una cola existente en RabbitMQ.
        /// </summary>
        /// <param name="queueName">Nombre de la cola a eliminar.</param>
        public async Task DeleteQueue(string queueName)
        {
            using (var channel = await _connection.CreateChannelAsync())
            {
                await channel.QueueDeleteAsync(queue: queueName);
            }
        }

        /// <summary>
        /// Libera los recursos asociados con RabbitMQ cuando el servicio es eliminado.
        /// </summary>
        /// <returns>Tarea que representa la operación de limpieza.</returns>
        public async ValueTask DisposeAsync()
        {
            if (_connection != null && _connection.IsOpen)
            {
                await _connection.CloseAsync();
                _connection.Dispose();
            }
        }

        public Task ConsumeAsync(string queueName, Func<string, IMessageMetadata, Task> messageHandler)
        {
            throw new NotImplementedException();
        }
    }
}

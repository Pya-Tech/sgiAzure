using Application.Messaging.Interfaces;
using Infrastructure.Messaging.Interfaces;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Registry;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace SgiAzure.Infrastructure.Messaging
{

    /// <summary>
    /// Pipeline de un Mensaje que se procesa en el worker
    /// </summary>
    /// <typeparam name="TMessage">Clase del mensaje a procesar en el pipeline del Mensajes</typeparam>
    public class MessagePipeline<TMessage>
    {
        /// <summary>
        /// broker encargado de publicara mensajes que no fueron procesados correctamente.
        /// </summary>
        private readonly IDlqPublisher _dlqPublisher;

        /// <summary>
        /// Handler encargado de inyectar la lógica interna necesaria en el mensaje a procesar
        /// </summary>
        private readonly IMessageHandler<TMessage> _handler;

        /// <summary>
        /// Opciones de serializado y deserializado
        /// </summary>
        private readonly JsonSerializerOptions _jsonOptions;

        /// <summary>
        /// Inyección del Logger
        /// </summary>
        private readonly ILogger<MessagePipeline<TMessage>> _logger;

        /// <summary>
        /// Inyección del Validador
        /// </summary>
        private readonly IMessageValidator<TMessage>? _validator;

        /// <summary>
        /// Inyección de pipeline de resiliencia para manejar reintentos.
        /// </summary>
        private readonly ResiliencePipeline _pipeline;

        public MessagePipeline(
            IMessageHandler<TMessage> handler, 
            IDlqPublisher dlqPublisher, 
            ILogger<MessagePipeline<TMessage>> logger,
            JsonSerializerOptions jsonOptions,
            ResiliencePipelineProvider<string> pipelineProvider,
            IMessageValidator<TMessage>? validator = null
            )
        {
            _handler = handler;
            _validator = validator;
            _dlqPublisher = dlqPublisher;
            _logger = logger;
            _jsonOptions = jsonOptions ?? new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _pipeline = pipelineProvider.GetPipeline("message-pipeline");
        }

        /// <summary>
        /// Método encargado de procesar el mensaje en todo su flujo.
        /// </summary>
        /// <param name="rawMessage">Mensaje procesado</param>
        /// <param name="metadata"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        /// <exception cref="JsonException"></exception>
        public async Task ProcessAsync(string rawMessage, IMessageMetadata metadata, CancellationToken ct)
        {
            try
            {
                TMessage dto = JsonSerializer.Deserialize<TMessage>(rawMessage, _jsonOptions) ?? throw new JsonException($"No se pudo deseralizar mensaje a la clase '{nameof(TMessage)}' ");
                if(_validator is not null)
                {
                    _validator.Validate(dto);
                }
                await _pipeline.ExecuteAsync(async ct =>
                {
                    await _handler.HandleAsync(dto, ct);
                });
            
            }
            catch (Exception ex)
            {

                if(ex is JsonException)
                {
                    _logger.LogWarning(ex,
                        "Error deserializando mensaje. Queue={Queue}, MessageId={MessageId}, Preview={Preview}",
                        metadata.Queue,
                        metadata.MessageId,
                        rawMessage.Length > 200 ? rawMessage[..200] : rawMessage);

                    await _dlqPublisher.PublishAsync(metadata.Queue, rawMessage, ex, ct);
                    return;
                }

                if(ex is ValidationException)
                {
                    _logger.LogWarning(ex,
                        "Mensaje inválido. Queue={Queue}, MessageId={MessageId}",
                        metadata.Queue,
                        metadata.MessageId);

                    await _dlqPublisher.PublishAsync(metadata.Queue, rawMessage, ex, ct);
                    return;
                }


                if(ex is ExecutionRejectedException)
                {
                    _logger.LogError(ex,
                        "Error definitivo procesando mensaje. Se envía a DLQ. Queue={Queue}, MessageId={MessageId}",
                        metadata.Queue,
                        metadata.MessageId);

                    await _dlqPublisher.PublishAsync(metadata.Queue, rawMessage, ex, ct);
                    return;
                }
                await _dlqPublisher.PublishAsync(metadata.Queue, rawMessage, ex, ct);
            }
        }
    }
}
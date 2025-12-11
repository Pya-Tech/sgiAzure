using Infrastructure.Messaging.Interfaces;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Messaging.Dlq
{
    /// <summary>
    /// Publicador encargado de reenviar mensajes que fallaron en su procesamiento
    /// hacia una Dead-Letter Queue (DLQ).
    /// 
    /// Este componente toma el mensaje original, el contexto del error y lo envuelve
    /// en un payload estandarizado antes de enviarlo a la cola <c>{queueName}.dlq</c>.
    /// 
    /// Su objetivo es permitir:
    /// - Inspectar fallos sin perder el mensaje original.
    /// - Trazabilidad del error.
    /// - Reintentos o reprocesamientos posteriores.
    /// </summary>
    public class DlqPublisher : IDlqPublisher
    {
        /// <summary>
        /// Logger para depuración
        /// </summary>
        private readonly ILogger<DlqPublisher> _logger;

        /// <summary>
        /// Broker de mensajería con el cual se realizará la publicación de mensajes no procesados correctamente.
        /// </summary>
        private readonly IMessageBroker _messageBroker;

        /// <summary>
        /// Inicializa una nueva instancia del publicador DLQ.
        /// </summary>
        public DlqPublisher(ILogger<DlqPublisher> logger, IMessageBroker messageBroker)
        {
            _logger = logger;
            _messageBroker = messageBroker;
        }

        /// <summary>
        /// Publica un mensaje fallido en la cola DLQ correspondiente,
        /// agregando información diagnóstica del error.
        /// </summary>
        /// <param name="originalQueue">Nombre de la cola original donde ocurrió el fallo.</param>
        /// <param name="rawMessage">Mensaje crudo que causó el error.</param>
        /// <param name="reason">Excepción que describe el motivo del fallo.</param>
        /// <param name="ct">Token de cancelación.</param>
        public async Task PublishAsync(string originalQueue, string rawMessage, Exception reason, CancellationToken ct)
        {
            try
            {
                var dlqName = $"{originalQueue}.dlq";

                var envelope = new
                {
                    OriginalQueue = originalQueue,
                    OriginalMessage = rawMessage,
                    ErrorMessage = reason.Message,
                    reason.StackTrace,
                    TimestampUtc = DateTime.UtcNow
                };

                var dlqPayload = JsonSerializer.Serialize(envelope);

                await _messageBroker.PublishAsync(dlqName, dlqPayload, ct: ct);

                _logger.LogWarning(
                    "Mensaje enviado a DLQ {DlqName} desde la cola {Queue}. Error={ErrorMessage}",
                    dlqName,
                    originalQueue,
                    reason.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error enviando mensaje a DLQ para la cola {Queue}", originalQueue);
            }
        }
    }
}

namespace Domain.Interfaces.Entities
{
    /// <summary>
    /// Metadatos técnicos sobre un mensaje extraídos del broker.
    /// 
    /// Importante: Esto NO es parte del dominio y nunca debe llegar al caso de uso.
    /// Solo sirve para trazabilidad, logging, retries y DLQ.
    /// </summary>
    public interface IMessageMetadata
    {
        /// <summary>
        /// Nombre del exchange desde donde vino el mensaje.
        /// </summary>
        string Exchange { get; }

        /// <summary>
        /// Nombre de la cola asociada.
        /// </summary>
        string Queue { get; }

        /// <summary>
        /// Routing key usada en el enrutamiento del mensaje.
        /// </summary>
        string RoutingKey { get; }

        /// <summary>
        /// Identificador único del mensaje asignado por el broker.
        /// </summary>
        string? MessageId { get; }

        /// <summary>
        /// Delivery tag del broker. Sirve para ACK/NACK.
        /// No es parte del dominio.
        /// </summary>
        ulong DeliveryTag { get; }

        /// <summary>
        /// Número de intentos de procesamiento.
        /// Usado por el pipeline de reintentos.
        /// </summary>
        int Attempt { get; set; }

        /// <summary>
        /// Headers técnicos del broker: correlationId, traceId, properties, etc.
        /// </summary>
        IDictionary<string, object>? Headers { get; }
    }
}

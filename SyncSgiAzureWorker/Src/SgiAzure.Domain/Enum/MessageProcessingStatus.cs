namespace SgiAzure.Domain.Enum
{
    /// <summary>
    /// Enum que representa los posibles estados del procesamiento de mensajes en el sistema.
    /// </summary>
    public enum MessageProcessingStatus
    {
        /// <summary>
        /// El mensaje está pendiente de ser procesado.
        /// </summary>
        Pending,

        /// <summary>
        /// El mensaje está siendo procesado.
        /// </summary>
        Processing,

        /// <summary>
        /// El mensaje ha sido procesado exitosamente.
        /// </summary>
        Processed,

        /// <summary>
        /// Hubo un error al procesar el mensaje.
        /// </summary>
        Failed
    }
}

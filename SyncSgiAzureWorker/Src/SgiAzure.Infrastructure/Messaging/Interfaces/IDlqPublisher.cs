namespace Infrastructure.Messaging.Interfaces
{
    /// <summary>
    /// Publica mensajes rechazados o fallidos a una Dead Letter Queue.
    /// 
    /// El dominio no debe decidir qué hacer con un mensaje fallido.
    /// Esta responsabilidad es puramente técnica.
    /// </summary>
    public interface IDlqPublisher
    {
        /// <summary>
        /// Envía el mensaje original a la DLQ junto con la razón del fallo.
        /// </summary>
        Task PublishAsync(string originalQueue, string rawMessage, Exception reason, CancellationToken ct);
    }
}

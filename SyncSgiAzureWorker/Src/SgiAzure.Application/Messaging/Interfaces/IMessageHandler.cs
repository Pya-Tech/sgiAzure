namespace Application.Messaging.Interfaces
{
    /// <summary>
    /// Contrato que representa un paso del procesamiento de negocio para un tipo de mensaje.
    /// 
    /// Este handler:
    /// - Recibe un DTO ya deserializado y validado.
    /// - Ejecuta el caso de uso correspondiente.
    /// - No sabe de brokers, JSON o transportes.
    /// 
    /// Esto cumple Clean Architecture: la aplicación recibe datos limpios
    /// y ejecuta la lógica del dominio sin acoplarse a infraestructura.
    /// </summary>
    public interface IMessageHandler<in TMessage>
    {
        /// <summary>
        /// Ejecuta la acción de negocio asociada a este tipo de mensaje.
        /// </summary>
        /// <param name="message">Mensaje a procesar</param>
        /// <param name="cancellationToken">Token de cancelación de proceso asociado</param>
        /// <returns>Tarea asíncrona que maneja el mensaje</returns>
        Task HandleAsync(TMessage message, CancellationToken cancellationToken);
    }
}

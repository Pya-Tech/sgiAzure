namespace Infrastructure.Messaging.Interfaces
{
    /// <summary>
    /// Abstracción de un broker de mensajería (RabbitMQ, Azure Service Bus, Kafka, etc.).
    /// Su responsabilidad es única: transportar mensajes sin conocer el dominio.
    /// 
    /// - No valida mensajes.
    /// - No ejecuta lógica de negocio.
    /// - No convierte a DTOs.
    /// - No hace reintentos lógicos.
    /// 
    /// Cumple con el principio de Single Responsibility y permite aplicar
    /// el principio de Dependency Inversion, desacoplando la aplicación de la infraestructura.
    /// </summary>
    public interface IMessageBroker
    {
        /// <summary>
        /// Publica un mensaje crudo en una cola
        /// </summary>
        /// <param name="queueName">Nombre de la cola</param>
        /// <param name="message">Mensaje a publicar</param>
        /// <param name="exchange">Nombre del intercambiador</param>
        /// <param name="ct">Cancelación token</param>
        /// <returns>Tarea asíncrona de publicación del mensaje en la cola</returns>
        Task PublishAsync(
            string queueName,
            string message,
            string exchange = "",
            CancellationToken ct = default
        );

        /// <summary>
        /// Se suscribe a una cola y recibe mensajes crudos.
        /// El broker solo entrega string + metadata,
        /// la lógica real la hace un pipeline o un handler en Application.
        /// </summary>
        /// <param name="queueName">Nombre de la cola</param>
        /// <param name="messageHandler">Función handler que ejecutará la acción de subscribir el mensaje</param>
        /// <param name="ct">Token de cancelación del proceso</param>
        /// <returns>Tarea asíncrona de subscripción</returns>
        Task SubscribeAsync(
            string queueName,
            Func<string, IMessageMetadata, CancellationToken, Task> messageHandler,
            CancellationToken ct
        );
    }
}

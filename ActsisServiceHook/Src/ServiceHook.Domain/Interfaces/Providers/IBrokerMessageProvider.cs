namespace ServiceHook.Domain.Interfaces.Providers
{
    /// <summary>
    /// Interface that defines methods for a messaging service responsible 
    /// for publishing and consuming messages from a specified message queue.
    /// </summary>
    public interface IBrokerMessageProvider
    {
        /// <summary>
        /// Método encaragdo de declarar una cola
        /// </summary>
        /// <param name="queueName">Nombre de la cola</param>
        /// <returns>Una tarea que representa la operaci�n as�ncrona</returns>
        Task DeclareQueue(string queueName);

        /// <summary>
        /// Método encargado de eliminar una cola
        /// </summary>
        /// <param name="queueName">Nombre de la cola</param>
        /// <returns>Una tarea que representa la operación asíncrona</returns>
        Task DeleteQueue(string queueName);

        /// <summary>
        /// Publishes a message to a specified queue asynchronously.
        /// </summary>
        /// <param name="queueName">The name of the queue to publish the message to.</param>
        /// <param name="message">The message to be published.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task PublishAsync(string queueName, string message, string exchange = "");

        /// <summary>
        /// Consumes a message from a specified queue asynchronously.
        /// </summary>
        /// <param name="queueName">The name of the queue from which to consume the message.</param>
        /// <returns>
        /// A task that represents the asynchronous operation, with the consumed message 
        /// as the result.
        /// </returns>
        Task ConsumeAsync(string queueName, Func<string, Task> messageHandler);
    }
}

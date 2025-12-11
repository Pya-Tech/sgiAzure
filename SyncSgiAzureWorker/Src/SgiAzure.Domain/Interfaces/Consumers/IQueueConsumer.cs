namespace SgiAzure.Domain.Interfaces.Consumers
{
    /// <summary>
    /// Representa un consumidor de colas de mensajes. 
    /// Esta interfaz define los métodos necesarios para consumir mensajes de una cola específica 
    /// dentro de un sistema de mensajería.
    /// </summary>
    public interface IQueueConsumer
    {
        /// <summary>
        /// Consume los mensajes de una cola específica.
        /// Este método se utiliza para escuchar y procesar los mensajes provenientes de una cola de mensajería.
        /// 
        /// El procesamiento de los mensajes es realizado de manera asincrónica para optimizar el rendimiento y permitir
        /// la gestión eficiente de recursos.
        /// </summary>
        /// <param name="queueName">El nombre de la cola desde la cual se consumirán los mensajes.</param>
        /// <param name="cancellationToken">Un token de cancelación que puede ser utilizado para cancelar el proceso de consumo de mensajes.</param>
        /// <returns>Una tarea asincrónica que representa la operación de consumo de mensajes. 
        /// El método no devuelve ningún valor, ya que se utiliza para procesar los mensajes de manera interna.</returns>
        /// <exception cref="ArgumentNullException">Lanzado si el nombre de la cola es nulo o vacío.</exception>
        /// <exception cref="OperationCanceledException">Lanzado si el proceso de consumo es cancelado mediante el token de cancelación.</exception>
        Task ConsumeAsync(string queueName, CancellationToken cancellationToken);
    }
}

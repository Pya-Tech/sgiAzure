using SgiAzure.Application.Interfaces.Dtos;
using SgiAzure.Domain.Enum;

namespace SgiAzure.Application.Interfaces.Services
{
    public interface IMessageProcessingService<T>where T: IMessageProcesingDto
    {
        /// <summary>
        /// Agrega un nuevo procesamiento de mensaje a la base de datos de manera asíncrona.
        /// </summary>
        /// <param name="messageProcessing">El objeto <see cref="IMessageProcessing"/> que representa el procesamiento de mensaje a agregar.</param>
        /// <returns>Una tarea asincrónica que representa la operación de agregar.</returns>
        Task RegisterMessage(T messageProcessingDto);

        /// <summary>
        /// Obtiene un procesamiento de mensaje por su <paramref name="messageId"/> de manera asíncrona.
        /// </summary>
        /// <param name="messageId">El identificador del mensaje.</param>
        /// <returns>Una tarea asincrónica que devuelve el procesamiento de mensaje o null si no se encuentra.</returns>
        Task<T?> GetByMessageIdAsync(string messageId);

        /// <summary>
        /// Actualiza el estado de un procesamiento de mensaje de manera asíncrona.
        /// </summary>
        /// <param name="messageProcessing">El objeto <see cref="IMessageProcessing"/> con la nueva información del procesamiento de mensaje.</param>
        /// <returns>Una tarea asincrónica que representa la operación de actualización.</returns>
        Task UpdateAsync(T messageProcessingDto);

        /// <summary>
        /// Elimina un procesamiento de mensaje de la base de datos de manera asíncrona.
        /// </summary>
        /// <param name="messageId">El identificador del mensaje a eliminar.</param>
        /// <returns>Una tarea asincrónica que representa la operación de eliminación.</returns>
        Task DeleteAsync(string messageId);

        /// <summary>
        /// Obtiene el procesamiento de mensaje por su estado <paramref name="status"/> de manera asíncrona.
        /// </summary>
        /// <param name="status">El estado del procesamiento de mensaje.</param>
        /// <returns>Una tarea asincrónica que devuelve la lista de mensajes con el estado dado.</returns>
        Task<IEnumerable<T>> GetByStatusAsync(MessageProcessingStatus status);
    }
}

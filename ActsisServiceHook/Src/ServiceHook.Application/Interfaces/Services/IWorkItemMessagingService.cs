using ServiceHook.Application.Dto;
using ServiceHook.Application.Interfaces.Dto;

namespace ServiceHook.Application.Interfaces.Services
{
    /// <summary>
    /// Define un servicio de mensajería para publicar WorkItems en un broker de mensajería.
    /// </summary>
    /// <typeparam name="T">
    /// El tipo de DTO que implementa la interfaz <see cref="IWorkItemDto"/>.
    /// Representa el formato del mensaje a publicar.
    /// </typeparam>
    public interface IWorkItemMessagingService
    {
        /// <summary>
        /// Publica un WorkItem en el broker de mensajería.
        /// </summary>
        /// <param name="workItemDto">
        /// Una instancia del tipo <typeparamref name="T"/> que contiene los datos del WorkItem a publicar.
        /// </param>
        /// <returns>
        /// Una tarea que representa la operación asíncrona de publicación.
        /// </returns>
        Task PublishWorkItemCreated(WorkItemCreatedMessageDto workItemDto);


        /// <summary>
        /// Publica un WorkItem actualizado en el broker de mensajería
        /// </summary>
        /// <param name="workItemDto">
        /// Una instancia del tipo <typeparamref name="T"/> que contiene los datos del WorkItem a publicar.
        /// </param>        
        /// <returns>
        /// Una tarea que representa la operación asíncrona de publicación.
        /// </returns>        
        Task PublishWorkItemUpdated(WorkItemUpdatedMessageDto updatedWorkItemDto);
    }


}

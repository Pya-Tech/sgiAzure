namespace SgiAzure.Application.Interfaces.Services
{
    using SgiAzure.Application.Dtos;
    using SgiAzure.Application.Interfaces.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interfaz para el servicio de manejo de WorkItems de Azure DevOps.
    /// Proporciona métodos para interactuar con los WorkItems, incluyendo la creación, actualización, 
    /// obtención, eliminación, cambio de tipo, y manejo de comentarios.
    /// </summary>
    public interface IWorkItemService<T> where T : IWorkItemDto
    {
        /// <summary>
        /// Crea un nuevo WorkItem en Azure DevOps.
        /// </summary>
        /// <param name="workItem">Entidad del WorkItem a crear.</param>
        /// <returns>El WorkItem creado con su ID.</returns>
        Task<T> CreateWorkItemAsync(WorkItemCreatedDto workItem);

        /// <summary>
        /// Obtiene un WorkItem por su ID.
        /// </summary>
        /// <param name="workItemId">El ID del WorkItem a obtener.</param>
        /// <returns>El WorkItem correspondiente al ID proporcionado.</returns>
        Task<T> GetWorkItemAsync(int workItemId);

        /// <summary>
        /// Actualiza un WorkItem existente en Azure DevOps.
        /// </summary>
        /// <param name="workItemId">El ID del WorkItem a actualizar.</param>
        /// <param name="workItem">La entidad WorkItem con los datos actualizados.</param>
        /// <returns>El WorkItem actualizado.</returns>
        Task<T> UpdateWorkItemAsync(int workItemId, WorkItemUpdatedDto workItem);

        /// <summary>
        /// Elimina un WorkItem de Azure DevOps.
        /// </summary>
        /// <param name="workItemId">El ID del WorkItem a eliminar.</param>
        Task DeleteWorkItemAsync(int workItemId);

        /// <summary>
        /// Cambia el tipo de un WorkItem existente.
        /// </summary>
        /// <param name="workItemId">El ID del WorkItem cuyo tipo se va a cambiar.</param>
        /// <param name="newType">El nuevo tipo de WorkItem.</param>
        /// <returns>El WorkItem actualizado con el nuevo tipo.</returns>
        Task<T> ChangeWorkItemTypeAsync(int workItemId, string newType);

        /// <summary>
        /// Clona un WorkItem de Azure DevOps.
        /// </summary>
        /// <param name="workItemId">El ID del WorkItem a clonar.</param>
        /// <returns>El nuevo WorkItem clonado.</returns>
        Task<T> CloneWorkItemAsync(int workItemId);

        /// <summary>
        /// Añade un comentario a un WorkItem.
        /// </summary>
        /// <param name="workItemId">El ID del WorkItem al que se le añadirá el comentario.</param>
        /// <param name="comment">El comentario a añadir.</param>
        /// <returns>El WorkItem con el comentario añadido.</returns>
        Task<T> AddCommentAsync(int workItemId, string comment);

        /// <summary>
        /// Obtiene una lista de WorkItems asociados a un proyecto de Azure DevOps.
        /// </summary>
        /// <param name="projectName">El nombre del proyecto de Azure DevOps.</param>
        /// <returns>Una lista de WorkItems del proyecto especificado.</returns>
        Task<List<T>> GetWorkItemsByProjectAsync(string projectName);


        /// <summary>
        /// Revierte los datos de un Workitem a una revisión específica
        /// </summary>
        /// <param name="workItemId">Identificador del WorkItem</param>
        /// <param name="revisionId">Número de revisión de WorkItem</param>
        /// <returns>WorkItem modificado</returns>
        Task<T> RollbackWorkItemByRevisionId(int workItemId, int revisionId);
    }
}

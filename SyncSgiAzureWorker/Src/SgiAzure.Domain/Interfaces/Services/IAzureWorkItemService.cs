using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Interfaces.Entities;

namespace SgiAzure.Domain.Interfaces.Services
{
    /// <summary>
    /// Interfaz que define los métodos para interactuar con Azure DevOps para la gestión de requerimientos.
    /// Proporciona abstracciones para la creación, actualización y obtención de Work Items en Azure DevOps, 
    /// facilitando la independencia de la lógica de negocio en la capa de aplicación de cualquier implementación específica.
    /// </summary>
    public interface IAzureWorkItemService<T> where T : IWorkItem
    {
        /// <summary>
        /// Crea un nuevo Work Item en Azure DevOps utilizando un objeto WorkItemEntity.
        /// </summary>
        /// <param name="workItemDto">El objeto WorkItemEntity que representa el requerimiento a crear.</param>
        /// <returns>Un <see cref="Task{WorkItem}"/> que representa la operación asíncrona con el Work Item creado.</returns>
        Task<T> CreateWorkItemAsync(T workItemDto);

        /// <summary>
        /// Actualiza un Work Item existente en Azure DevOps utilizando un objeto WorkItemEntity.
        /// </summary>
        /// <param name="id">El identificador del Work Item que se va a actualizar.</param>
        /// <param name="workItemDto">El objeto WorkItemEntity que contiene los datos actualizados.</param>
        /// <returns>Un <see cref="Task{WorkItem}"/> que representa la operación asíncrona de actualización con el Work Item actualizado.</returns>
        Task<T> UpdateWorkItemAsync(int id, T workItemDto);


        /// <summary>
        /// Obtiene un Work Item de Azure DevOps y lo convierte en un objeto Requirement.
        /// </summary>
        /// <param name="workItemId">El identificador del Work Item que se desea obtener.</param>
        /// <returns>Un <see cref="Task{Requirement}"/> que representa el requerimiento correspondiente al Work Item.</returns>
        Task<T> GetWorkItemAsync(int workItemId);
    }
}

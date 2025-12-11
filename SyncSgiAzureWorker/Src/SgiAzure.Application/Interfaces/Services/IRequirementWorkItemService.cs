using SgiAzure.Application.Interfaces.Dtos;

namespace SgiAzure.Application.Interfaces.Services
{
    /// <summary>
    /// Define los métodos para la gestión de operaciones relacionadas con RequirementWorkItems.
    /// </summary>
    public interface IRequirementWorkItemService<T> where T : IRequirementWorkItemDto
    {
        /// <summary>
        /// Agrega un nuevo RequirementWorkItem de forma asincrónica.
        /// </summary>
        /// <param name="requirementWorkItem">La instancia de RequirementWorkItem a agregar.</param>
        /// <returns>Tarea que representa la operación asincrónica.</returns>
        Task<T> AddRequirementWorkItemAsync(T requirementWorkItem, CancellationToken ct = default);

        /// <summary>
        /// Agrega un nuevo RequirementWorkItem de forma asíncrona
        /// </summary>
        /// <param name="workItemId">Identificador del workItem</param>
        /// <param name="requirementId">Identificador del número de requerimiento</param>
        /// <param name="customer">Cliente origen del cual pertenece el workItem o requerimiento.</param>
        /// <returns>Tarea que representa la operación asíncrona</returns>
        Task<T> AddRequirementWorkItemAsync(int workItemId, int requirementId, int customerId, string customerName, CancellationToken ct = default);

        /// <summary>
        /// Obtiene un RequirementWorkItem basado en el ID del requisito de forma asincrónica.
        /// </summary>
        /// <param name="requirementId">El ID del requisito para buscar.</param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica.
        /// El resultado contiene el RequirementWorkItem correspondiente al ID del requisito, o null si no se encuentra.
        /// </returns>
        Task<T> GetRequirementWorkItemByRequirementIdAsync(int requirementId, CancellationToken ct = default);

        /// <summary>
        /// Obtiene una colección de RequirementWorkItems basada en el ID del WorkItemEntity de forma asincrónica.
        /// </summary>
        /// <param name="workItemId">El ID del WorkItemEntity para buscar.</param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica.
        /// El resultado contiene una colección de RequirementWorkItems relacionados con el ID del WorkItemEntity especificado.
        /// </returns>
        Task<T> GetRequirementWorkItemsByWorkItemIdAsync(int workItemId, CancellationToken ct = default);

        /// <summary>
        /// Actualiza un RequirementWorkItem existente de forma asincrónica.
        /// </summary>
        /// <param name="requirementWorkItem">La instancia de RequirementWorkItem con los datos actualizados.</param>
        /// <returns>Tarea que representa la operación asincrónica.</returns>
        Task UpdateRequirementWorkItemAsync(int requirementId, T requirementWorkItem, CancellationToken ct = default);

        /// <summary>
        /// Elimina un RequirementWorkItem basado en el ID del requisito y el ID del WorkItemEntity de forma asincrónica.
        /// </summary>
        /// <param name="requirementId">El ID del requisito del RequirementWorkItem a eliminar.</param>
        /// <param name="workItemId">El ID del WorkItemEntity del RequirementWorkItem a eliminar.</param>
        /// <returns>Tarea que representa la operación asincrónica.</returns>
        Task DeleteRequirementWorkItemAsync(int requirementId, int workItemId, CancellationToken ct = default);
    }
}

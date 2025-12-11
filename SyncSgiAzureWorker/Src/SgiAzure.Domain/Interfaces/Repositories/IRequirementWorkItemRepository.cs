using SgiAzure.Domain.Interfaces.Entities;

namespace SgiAzure.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interfaz para gestionar la relación entre Requerimientos y Work Items.
    /// </summary>
    public interface IRequirementWorkItemRepository<T> where T : IRequirementWorkItem
    {
        /// <summary>
        /// Agrega una nueva relación entre un Requerimiento y un Work Item.
        /// </summary>
        /// <param name="requirementWorkItem">La entidad RequirementWorkItem a agregar.</param>
        /// <returns>Tarea que representa la operación asincrónica.</returns>
        Task<T> AddAsync(T requirementWorkItem, CancellationToken ct = default);

        /// <summary>
        /// Recupera un RequirementWorkItem basado en el ID del Requerimiento.
        /// </summary>
        /// <param name="requirementId">El ID del Requerimiento.</param>
        /// <returns>Tarea que representa la operación asincrónica. El resultado de la tarea contiene el RequirementWorkItem asociado con el ID de Requerimiento dado, o null si no se encuentra.</returns>
        Task<T?> GetByRequirementIdAsync(int requirementId, CancellationToken ct = default);

        /// <summary>
        /// Recupera una colección de RequirementWorkItems asociados con un ID específico de Work Item.
        /// </summary>
        /// <param name="workItemId">El ID del Work Item.</param>
        /// <returns>Tarea que representa la operación asincrónica. El resultado de la tarea contiene una colección de RequirementWorkItems asociados con el ID de Work Item dado.</returns>
        Task<T?> GetByWorkItemIdAsync(int workItemId, CancellationToken ct = default);

        /// <summary>
        /// Actualiza un RequirementWorkItem existente.
        /// </summary>
        /// <param name="requirementWorkItem">La entidad RequirementWorkItem a actualizar.</param>
        /// <returns>Tarea que representa la operación asincrónica.</returns>
        Task UpdateAsync(int requirementId, T requirementWorkItem, CancellationToken ct = default);

        /// <summary>
        /// Elimina una relación entre un Requerimiento y un Work Item basándose en sus IDs.
        /// </summary>
        /// <param name="requirementId">El ID del Requerimiento.</param>
        /// <param name="workItemId">El ID del Work Item.</param>
        /// <returns>Tarea que representa la operación asincrónica.</returns>
        Task DeleteAsync(int requirementId, int workItemId, CancellationToken ct = default);
    }
}

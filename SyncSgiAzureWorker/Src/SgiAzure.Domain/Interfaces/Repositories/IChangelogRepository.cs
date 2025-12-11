using SgiAzure.Domain.Interfaces.Entities;
using System.Threading.Tasks;

namespace SgiAzure.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interfaz que define las operaciones para el repositorio de <see cref="IChangeLog"/>.
    /// </summary>
    /// <typeparam name="T">El tipo que implementa <see cref="IChangeLog"/>.</typeparam>
    public interface IChangelogRepository<T> where T : IChangeLog
    {
        /// <summary>
        /// Agrega un nuevo changelog a la base de datos de manera asíncrona.
        /// </summary>
        /// <param name="requirementWorkItem">El objeto <typeparamref name="T"/> que representa el changelog a agregar.</param>
        /// <returns>Una tarea asincrónica que representa la operación de agregar.</returns>
        Task AddAsync(T requirementWorkItem, CancellationToken ct = default);

        /// <summary>
        /// Obtiene un changelog asociado con un <paramref name="requirementId"/> de manera asíncrona.
        /// </summary>
        /// <param name="requirementId">El identificador del requerimiento.</param>
        /// <returns>Una tarea asincrónica que devuelve el changelog asociado o null si no se encuentra.</returns>
        Task<T?> GetChangelogByRequirementId(int requirementId, CancellationToken ct = default);

        /// <summary>
        /// Obtiene un changelog asociado con un <paramref name="workItemId"/> de manera asíncrona.
        /// </summary>
        /// <param name="workItemId">El identificador del WorkItemEntity.</param>
        /// <returns>Una tarea asincrónica que devuelve el changelog asociado o null si no se encuentra.</returns>
        Task<T?> GetChangelogByWorkItemId(int workItemId, CancellationToken ct = default);

        /// <summary>
        /// Actualiza un changelog existente de manera asíncrona.
        /// </summary>
        /// <param name="changeLog">El objeto <typeparamref name="T"/> que representa el changelog actualizado.</param>
        /// <returns>Una tarea asincrónica que representa la operación de actualización.</returns>
        Task UpdateAsync(int changeLogId, T changeLog, CancellationToken ct = default);

        /// <summary>
        /// Elimina un changelog de la base de datos de manera asíncrona.
        /// </summary>
        /// <param name="changeLogId">El identificador del changelog a eliminar.</param>
        /// <returns>Una tarea asincrónica que representa la operación de eliminación.</returns>
        Task DeleteAsync(int changeLogId, CancellationToken ct = default);
    }
}

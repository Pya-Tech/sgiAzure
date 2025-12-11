using SgiAzure.Domain.Interfaces.Entities;

namespace SgiAzure.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Repositorio encargado de gestionar los artefactos de SGI y Azure
    /// (tabla work_artifacts), tales como tipos de requerimiento o tipos de Work Item.
    /// </summary>
    /// <typeparam name="T">Entidad que representa un artefacto.</typeparam>
    public interface IWorkArtifactRepository<T> where T : IWorkArtifact
    {
        /// <summary>
        /// Obtiene un artefacto por su identificador único.
        /// </summary>
        Task<T> GetByIdAsync(int id, CancellationToken ct = default);

        /// <summary>
        /// Obtiene un artefacto por su nombre (ej.: “GT2”, “Task”, “Bug”).
        /// </summary>
        Task<T> GetByNameAsync(string name, CancellationToken ct = default);

        /// <summary>
        /// Obtiene todos los artefactos de un tipo específico
        /// (Requirement o WorkItem).
        /// </summary>
        Task<IEnumerable<T>> GetByTypeAsync(int type, CancellationToken ct = default);

        /// <summary>
        /// Obtiene todos los artefactos disponibles.
        /// </summary>
        Task<IEnumerable<T>> GetAllAsync(CancellationToken ct = default);

        /// <summary>
        /// Crea un nuevo artefacto.
        /// </summary>
        Task<T> CreateAsync(T entity, CancellationToken ct = default);

        /// <summary>
        /// Actualiza un artefacto existente.
        /// </summary>
        Task UpdateAsync(T entity, CancellationToken ct = default);

        /// <summary>
        /// Elimina un artefacto de forma permanente.
        /// </summary>
        Task DeleteAsync(int id, CancellationToken ct = default);
    }
}

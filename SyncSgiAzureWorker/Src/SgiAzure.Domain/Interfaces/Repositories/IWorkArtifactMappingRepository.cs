using SgiAzure.Domain.Interfaces.Entities;

namespace SgiAzure.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Repositorio encargado de gestionar los mapeos de artefactos entre SGI y Azure DevOps.
    /// 
    /// Esta entidad representa el vínculo entre:
    /// - Un artefacto del SGI (RequirementArtifact)
    /// - Su artefacto equivalente en Azure DevOps (WorkItemArtifact)
    /// 
    /// Permite resolver, para un cliente específico, cómo debe traducirse un tipo de requerimiento de SGI
    /// a un tipo de WorkItem en Azure DevOps, y viceversa.
    /// </summary>
    /// <typeparam name="T">Entidad que implementa <see cref="IWorkArtifactMapping"/>.</typeparam>
    public interface IWorkArtifactMappingRepository<T> where T : IWorkArtifactMapping
    {
        /// <summary>
        /// Obtiene un mapeo por su identificador único.
        /// </summary>
        /// <param name="id">Identificador del registro en la tabla <c>work_artifacts_mappings</c>.</param>
        /// <param name="ct">Token de cancelación.</param>
        /// <returns>
        /// Un objeto <typeparamref name="T"/> si existe.
        /// Lanza excepción si el registro no se encuentra.
        /// </returns>
        Task<T> GetByIdAsync(int id, CancellationToken ct = default);

        /// <summary>
        /// Obtiene el mapeo correspondiente a un artefacto de requerimiento del SGI.
        /// </summary>
        /// <param name="requirementArtifactId">Identificador del artefacto de SGI.</param>
        /// <param name="customerId">Identificador del cliente al que pertenece la configuración.</param>
        /// <param name="ct">Token de cancelación.</param>
        /// <returns>
        /// Un objeto <typeparamref name="T"/> que contiene la relación SGI → Azure.
        /// Lanza excepción si no existe relación para dicho cliente.
        /// </returns>
        Task<T> GetByRequirementArtifactIdAsync(int requirementArtifactId, int customerId, CancellationToken ct = default);

        /// <summary>
        /// Obtiene el mapeo a partir del nombre del artefacto de requerimiento en SGI.
        /// </summary>
        /// <param name="artifactName">Nombre del artefacto SGI (columna <c>Name</c> en la tabla <c>work_artifacts</c>).</param>
        /// <param name="customerId">Cliente al que pertenece el mapeo.</param>
        /// <param name="ct">Token de cancelación.</param>
        /// <returns>
        /// Un objeto <typeparamref name="T"/> cuyo <c>RequirementArtifact</c> tiene el nombre especificado.
        /// Lanza excepción si no existe coincidencia.
        /// </returns>
        Task<T> GetByRequirementArtifactNameAsync(string artifactName, int customerId, CancellationToken ct = default);

        /// <summary>
        /// Obtiene el mapeo a partir del nombre del artefacto de Work Item en Azure DevOps.
        /// </summary>
        /// <param name="artifactName">Nombre del artefacto en Azure (por ejemplo: "Bug", "Task", "Incident").</param>
        /// <param name="customerId">Cliente asociado al mapeo.</param>
        /// <param name="ct">Token de cancelación.</param>
        /// <returns>
        /// Objeto <typeparamref name="T"/> cuyo <c>WorkitemArtifact</c> coincide con el nombre indicado.
        /// Lanza excepción si no existe coincidencia.
        /// </returns>
        Task<T> GetByWorkItemArtifactNameAsync(string artifactName, int customerId, CancellationToken ct = default);

        /// <summary>
        /// Obtiene el tipo de requerimiento SGI equivalente a un artefacto de Work Item de Azure.
        /// </summary>
        /// <param name="workItemArtifactId">Identificador del artefacto de Azure.</param>
        /// <param name="customerId">Identificador del cliente.</param>
        /// <param name="ct">Token de cancelación.</param>
        /// <returns>
        /// El mapeo correspondiente SGI ← Azure.
        /// Lanza excepción si no existe relación para el cliente.
        /// </returns>
        Task<T> GetByWorkItemArtifactIdAsync(int workItemArtifactId, int customerId, CancellationToken ct = default);

        /// <summary>
        /// Obtiene todos los mapeos configurados para un cliente.
        /// </summary>
        /// <param name="customerId">Identificador del cliente.</param>
        /// <param name="ct">Token de cancelación.</param>
        /// <returns>
        /// Colección de <typeparamref name="T"/> representando todos los mapeos activos del cliente.
        /// </returns>
        Task<IEnumerable<T>> GetByCustomerIdAsync(int customerId, CancellationToken ct = default);

        /// <summary>
        /// Crea un nuevo mapeo de artefactos entre SGI y Azure.
        /// </summary>
        /// <param name="entity">Entidad que representa el mapeo a persistir.</param>
        /// <param name="ct">Token de cancelación.</param>
        /// <returns>
        /// La entidad creada con su Id asignada.
        /// </returns>
        Task<T> CreateAsync(T entity, CancellationToken ct = default);

        /// <summary>
        /// Actualiza un mapeo existente.
        /// </summary>
        /// <param name="entity">Entidad con los datos actualizados.</param>
        /// <param name="ct">Token de cancelación.</param>
        Task UpdateAsync(T entity, CancellationToken ct = default);

        /// <summary>
        /// Elimina un mapeo de forma permanente.
        /// </summary>
        /// <param name="id">Identificador del mapeo a eliminar.</param>
        /// <param name="ct">Token de cancelación.</param>
        Task DeleteAsync(int id, CancellationToken ct = default);

        /// <summary>
        /// Deshabilita un mapeo sin eliminarlo, evitando su uso en sincronizaciones.
        /// </summary>
        /// <param name="id">Identificador del mapeo a desactivar.</param>
        /// <param name="ct">Token de cancelación.</param>
        Task DisableAsync(int id, CancellationToken ct = default);
    }
}

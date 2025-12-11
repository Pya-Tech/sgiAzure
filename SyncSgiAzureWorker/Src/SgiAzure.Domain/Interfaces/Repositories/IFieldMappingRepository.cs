using SgiAzure.Domain.Interfaces.Entities;

namespace SgiAzure.Domain.Interfaces.Repositories
{
    public interface IFieldMappingRepository<T> where T : IFieldMapping
    {
        /// <summary>
        /// Obtiene el mapeo de un campo origen.
        /// </summary>
        Task<T> GetBySourceIdAsync(int sourceId, int customerId, CancellationToken ct = default);

        /// <summary>
        /// Obtiene el mapeo de un campo destino.
        /// </summary>
        Task<T> GetByMappedIdAsync(int mappedId, int customerId, CancellationToken ct = default);

        /// <summary>
        /// Obtiene un mapeo por su identificador.
        /// </summary>
        Task<T> GetByIdAsync(int id, CancellationToken ct = default);

        /// <summary>
        /// Obtiene todos los mapeos pertenecientes a un cliente.
        /// </summary>
        Task<IEnumerable<T>> GetByCustomerIdAsync(int customerId, CancellationToken ct = default);

        /// <summary>
        /// Crea un nuevo mapeo.
        /// </summary>
        Task<T> CreateAsync(T entity, CancellationToken ct = default);

        /// <summary>
        /// Actualiza un mapeo existente.
        /// </summary>
        Task UpdateAsync(T entity, CancellationToken ct = default);

        /// <summary>
        /// Deshabilita un mapeo sin eliminarlo.
        /// </summary>
        Task DisableAsync(int id, CancellationToken ct = default);

        /// <summary>
        /// Elimina físicamente un mapeo.
        /// </summary>
        Task DeleteAsync(int id, CancellationToken ct = default);
    }
}

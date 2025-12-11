using SgiAzure.Domain.Interfaces.Entities;

namespace SgiAzure.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Repositorio encargado de gestionar las equivalencias de valores entre SGI y Azure
    /// almacenadas en la tabla <c>field_value_mappings</c>.
    /// 
    /// Permite resolver qué valor de Azure corresponde a un valor SGI (y viceversa),
    /// considerando el parámetro al que pertenece y el cliente (multitenant).
    /// </summary>
    /// <typeparam name="T">Entidad de dominio que representa un mapeo de valores.</typeparam>
    public interface IFieldValueMappingRepository<T> where T : IFieldValueMapping
    {
        /// <summary>
        /// Obtiene un mapeo específico por su identificador único.
        /// </summary>
        /// <param name="id">Identificador del mapeo.</param>
        /// <param name="ct">Token de cancelación.</param>
        /// <returns>Instancia de <typeparamref name="T"/> si existe.</returns>
        Task<T> GetByIdAsync(int id, CancellationToken ct = default);

        /// <summary>
        /// Obtiene el mapeo SGI → Azure usando el identificador del valor local
        /// (valor almacenado en SGI).
        /// </summary>
        /// <param name="localValueId">Id del valor SGI.</param>
        /// <param name="fieldParameterId">Id del parámetro al que pertenece el valor (estado, prioridad, etc.).</param>
        /// <param name="customerId">Id del cliente para el cual se configuró el mapeo.</param>
        /// <param name="ct">Token de cancelación.</param>
        /// <returns>Mapeo que contiene el valor equivalente en Azure.</returns>
        Task<T> GetMappingByLocalValueAsync(
            int localValueId,
            int fieldParameterId,
            int customerId,
            CancellationToken ct = default);

        /// <summary>
        /// Obtiene el mapeo Azure → SGI usando el identificador del valor equivalente en Azure.
        /// </summary>
        /// <param name="equivalentValueId">Id del valor en Azure.</param>
        /// <param name="fieldParameterId">Id del parámetro al que pertenece el valor.</param>
        /// <param name="customerId">Id del cliente asociado.</param>
        /// <param name="ct">Token de cancelación.</param>
        /// <returns>Mapeo que contiene el valor equivalente en SGI.</returns>
        Task<T> GetMappingByEquivalentValueAsync(
            int equivalentValueId,
            int fieldParameterId,
            int customerId,
            CancellationToken ct = default);

        /// <summary>
        /// Obtiene todos los mapeos de valores asociados a un parámetro
        /// (ej. todos los estados) para un cliente determinado.
        /// </summary>
        /// <param name="fieldParameterId">Id del parámetro.</param>
        /// <param name="customerId">Cliente.</param>
        /// <param name="ct">Token de cancelación.</param>
        /// <returns>Colección de mapeos.</returns>
        Task<IEnumerable<T>> GetMappingsByFieldParameterAsync(
            int fieldParameterId,
            int customerId,
            CancellationToken ct = default);


        /// <summary>
        /// Obtiene el mapeo SGI → Azure usando el <c>ValueCode</c> del valor SGI.
        /// </summary>
        /// <param name="localValueCode">Código del valor SGI (ej. "A", "P", "C").</param>
        /// <param name="fieldParameterId">Id del parámetro asociado.</param>
        /// <param name="customerId">Cliente para el que aplica el mapeo.</param>
        /// <param name="ct">Token de cancelación.</param>
        /// <returns>Mapeo que contiene el valor equivalente en Azure.</returns>
        Task<T> GetMappingByLocalValueCodeAsync(
            string localValueCode,
            int fieldParameterId,
            int customerId,
            CancellationToken ct = default);

        /// <summary>
        /// Obtiene el mapeo Azure → SGI usando el <c>ValueCode</c> del valor Azure.
        /// </summary>
        /// <param name="equivalentValueCode">Código del valor en Azure (ej. "New", "Active", "Closed").</param>
        /// <param name="fieldParameterId">Id del parámetro asociado.</param>
        /// <param name="customerId">Cliente para el cual se configuró el mapeo.</param>
        /// <param name="ct">Token de cancelación.</param>
        /// <returns>Mapeo que contiene el valor equivalente en SGI.</returns>
        Task<T> GetMappingByEquivalentValueCodeAsync(
            string equivalentValueCode,
            int fieldParameterId,
            int customerId,
            CancellationToken ct = default);



        /// <summary>
        /// Crea un nuevo mapeo de valores.
        /// </summary>
        /// <param name="entity">Entidad a persistir.</param>
        /// <param name="ct">Token de cancelación.</param>
        /// <returns>Instancia creada.</returns>
        Task<T> CreateAsync(T entity, CancellationToken ct = default);

        /// <summary>
        /// Actualiza un mapeo existente.
        /// </summary>
        /// <param name="entity">Entidad con los cambios a aplicar.</param>
        /// <param name="ct">Token de cancelación.</param>
        Task UpdateAsync(T entity, CancellationToken ct = default);

        /// <summary>
        /// Elimina un mapeo permanentemente.
        /// </summary>
        /// <param name="id">Identificador del mapeo.</param>
        /// <param name="ct">Token de cancelación.</param>
        Task DeleteAsync(int id, CancellationToken ct = default);
    }
}

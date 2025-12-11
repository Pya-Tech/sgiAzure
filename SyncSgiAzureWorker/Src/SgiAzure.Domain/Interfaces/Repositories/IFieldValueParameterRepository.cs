using SgiAzure.Domain.Interfaces.Entities;

namespace SgiAzure.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Repositorio encargado de gestionar los valores asociados a un parámetro de campo
    /// (tabla field_value_parameters).
    /// </summary>
    /// <typeparam name="T">Entidad que representa un valor de parámetro.</typeparam>
    public interface IFieldValueParameterRepository<T> where T : IFieldValueParameter
    {
        /// <summary>
        /// Obtiene un valor de parámetro por su identificador único.
        /// </summary>
        Task<T> GetByIdAsync(int id, CancellationToken ct = default);

        /// <summary>
        /// Obtiene un valor específico según su código y el parámetro al que pertenece.
        /// </summary>
        Task<T> GetByValueCodeAsync(string valueCode, int fieldParameterId, CancellationToken ct = default);

        /// <summary>
        /// Retorna todos los valores de un parámetro.
        /// </summary>
        Task<IEnumerable<T>> GetByFieldParameterIdAsync(int fieldParameterId, CancellationToken ct = default);

        /// <summary>
        /// Inserta un nuevo valor de parámetro.
        /// </summary>
        Task<T> CreateAsync(T entity, CancellationToken ct = default);

        /// <summary>
        /// Actualiza un valor de parámetro existente.
        /// </summary>
        Task UpdateAsync(T entity, CancellationToken ct = default);

        /// <summary>
        /// Deshabilita un valor sin eliminarlo.
        /// </summary>
        Task DisableAsync(int id, CancellationToken ct = default);

        /// <summary>
        /// Elimina un valor de parámetro de forma permanente.
        /// </summary>
        Task DeleteAsync(int id, CancellationToken ct = default);
    }
}

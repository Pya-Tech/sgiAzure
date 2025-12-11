using SgiAzure.Domain.Interfaces.Entities;

namespace SgiAzure.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Contrato genérico para el repositorio de parámetros de campo.
    /// Proporciona métodos para operaciones CRUD y de activación/desactivación.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad que implementa IFieldParameter</typeparam>
    public interface IFieldParameterRepository<T> where T : IFieldParameter
    {
        /// <summary>
        /// Obtiene todos los parámetros de campo disponibles.
        /// </summary>
        Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Crea un nuevo parámetro de campo en el repositorio.
        /// </summary>
        /// <param name="entity">Entidad con los datos del parámetro a crear.</param>
        Task<T> CreateFieldParameter(T entity, CancellationToken ct = default);

        /// <summary>
        /// Actualiza un Campo personalizado
        /// </summary>
        /// <param name="id">Identificador de referencia.</param>
        /// <param name="entity">Entidad usada como filtro adicional.</param>
        Task<T> UpdateFieldParameter(int id, T entity, CancellationToken ct = default);

        /// <summary>
        /// Obtiene un parámetro de campo a partir de su identificador único.
        /// </summary>
        /// <param name="id">Identificador del parámetro.</param>
        Task<T> GetFieldParameterById(int id, CancellationToken ct = default);

        /// <summary>
        /// Obtiene un parámetro de campo usando su código único.
        /// </summary>
        /// <param name="code">Código del parámetro.</param>
        Task<T> GetFieldParameterByCode(string code, CancellationToken ct = default);

        /// <summary>
        /// Obtiene un parámetro de campo a partir del valor asociado al código.
        /// </summary>
        /// <param name="codeValue">Valor del código del parámetro.</param>
        Task<T> GetFieldParameterByCodeValue(string codeValue, CancellationToken ct = default);

        /// <summary>
        /// Desactiva (inhabilita) un parámetro de campo específico.
        /// </summary>
        /// <param name="id">Identificador del parámetro a desactivar.</param>
        Task DisabledFieldParameter(int id, CancellationToken ct = default);

        /// <summary>
        /// Activa un parámetro de campo previamente deshabilitado.
        /// </summary>
        /// <param name="id">Identificador del parámetro a habilitar.</param>
        Task EnabledFieldParameter(int id, CancellationToken ct = default);
    }
}

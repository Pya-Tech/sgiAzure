using SgiAzure.Domain.Interfaces.Entities;

namespace SgiAzure.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interfaz que define los métodos para obtener parámetros de requerimientos desde el repositorio.
    /// </summary>
    /// <typeparam name="T">Tipo genérico que implementa la interfaz IMultiTable.</typeparam>
    public interface IRequirementParameterRepository<T> where T : IMultiTable
    {
        /// <summary>
        /// Obtiene todos los contratos disponibles
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica, con una colección de contratos.</returns>
        Task<IEnumerable<T>> GetRequirementContracts(CancellationToken ct = default);

        /// <summary>
        /// Obtiene todos los tipos de requerimiento disponibles.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica, con una colección de tipos de requerimiento.</returns>
        Task<IEnumerable<T>> GetRequirementTypes(CancellationToken ct = default);

        /// <summary>
        /// Obtiene todos los sistemas de requerimiento disponibles.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica, con una colección de sistemas de requerimiento.</returns>
        Task<IEnumerable<T>> GetRequirementSystems(CancellationToken ct = default);

        /// <summary>
        /// Obtiene todas las áreas de requerimiento disponibles.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica, con una colección de áreas de requerimiento.</returns>
        Task<IEnumerable<T>> GetRequirementAreas(string company, CancellationToken ct = default);

        /// <summary>
        /// Obtiene todas las sub-áreas de requerimiento disponibles.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica, con una colección de sub-áreas de requerimiento.</returns>
        Task<IEnumerable<T>> GetRequirementSubAreas(string company, CancellationToken ct = default);

        /// <summary>
        /// Obtiene todas las clasificaciones de requerimiento disponibles.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica, con una colección de clasificaciones de requerimiento.</returns>
        Task<IEnumerable<T>> GetRequirementClasifications(string company, CancellationToken ct = default);

        /// <summary>
        /// Obtiene todos los temas de requerimiento disponibles.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica, con una colección de temas de requerimiento.</returns>
        Task<IEnumerable<T>> GetRequirementTopics(string company, CancellationToken ct = default);

        /// <summary>
        /// Obtiene un tipo de requerimiento específico por su identificador (ID).
        /// </summary>
        /// <param name="id">El identificador único del tipo de requerimiento a obtener.</param>
        /// <returns>Una tarea que representa la operación asincrónica, con el tipo de requerimiento encontrado.</returns>
        Task<T> GetRequirementTypeByIdAsync(string requirementTypeId, CancellationToken ct = default);

        /// <summary>
        /// Obtiene una contrato específico por su identificador (ID).
        /// </summary>
        /// <param name="id">El identificador único del contrato a obtener.</param>
        /// <returns>Una tarea que representa la operación asincrónica, con el contrato encontrado.</returns>
        Task<T> GetRequirementContractById(string contractId, CancellationToken ct = default);

        /// <summary>
        /// Obtiene una contrato específico por la empresa.
        /// </summary>
        /// <param name="company">El identificador único de la empresa.</param>
        /// <returns>Una tarea que representa la operación asincrónica, con el contrato encontrado.</returns>
        Task<IEnumerable<T>> GetRequirementContractsByCompany(string company, CancellationToken ct = default);

        /// <summary>
        /// Obtiene un sistema de requerimiento específico por su identificador (ID).
        /// </summary>
        /// <param name="id">El identificador único del sistema de requerimiento a obtener.</param>
        /// <returns>Una tarea que representa la operación asincrónica, con el sistema de requerimiento encontrado.</returns>
        Task<T> GetRequirementSystemByIdAsync(string systemId, CancellationToken ct = default);

        /// <summary>
        /// Obtiene un área de requerimiento específica por su identificador (ID).
        /// </summary>
        /// <param name="id">El identificador único del área de requerimiento a obtener.</param>
        /// <returns>Una tarea que representa la operación asincrónica, con el área de requerimiento encontrada.</returns>
        Task<T> GetRequirementAreaByIdAsync(string areaId, string company, CancellationToken ct = default);

        /// <summary>
        /// Obtiene una sub-área de requerimiento específica por su identificador (ID).
        /// </summary>
        /// <param name="id">El identificador único de la sub-área de requerimiento a obtener.</param>
        /// <returns>Una tarea que representa la operación asincrónica, con la sub-área de requerimiento encontrada.</returns>
        Task<T> GetRequirementSubAreaByIdAsync(string subAreaId, string company, CancellationToken ct = default);

        /// <summary>
        /// Obtiene una clasificación de requerimiento específica por su identificador (ID).
        /// </summary>
        /// <param name="id">El identificador único de la clasificación de requerimiento a obtener.</param>
        /// <returns>Una tarea que representa la operación asincrónica, con la clasificación de requerimiento encontrada.</returns>
        Task<T> GetRequirementClasificationByIdAsync(string clasificationId, string company, CancellationToken ct = default);

        /// <summary>
        /// Obtiene un tema de requerimiento específico por su identificador (ID).
        /// </summary>
        /// <param name="id">El identificador único del tema de requerimiento a obtener.</param>
        /// <returns>Una tarea que representa la operación asincrónica, con el tema de requerimiento encontrado.</returns>
        Task<T> GetRequirementTopicByIdAsync(string requirementTopicId, string company, CancellationToken ct = default);
    }
}
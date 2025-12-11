using SgiAzure.Application.Dtos;
using SgiAzure.Application.Interfaces.Dtos;

namespace SgiAzure.Application.Interfaces.Services
{
    /// <summary>
    /// Interfaz para el servicio de gestión de requerimientos.
    /// Proporciona métodos para la creación, actualización, eliminación y obtención de requerimientos.
    /// </summary>
    /// <typeparam name="T">Tipo de DTO de requerimiento que implementa <see cref="IRequirementDto"/>.</typeparam>
    public interface IRequirementService<T> where T : IRequirementDto
    {
        /// <summary>
        /// Crea un nuevo requerimiento en el sistema.
        /// </summary>
        /// <param name="requirementCreatedDto">DTO del requerimiento a crear.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        Task<RequirementDto> CreateRequirementAsync(RequirementCreatedDto requirementCreatedDto, CancellationToken ct = default);

        /// <summary>
        /// Obtiene un requerimiento por su identificador.
        /// </summary>
        /// <param name="requirementDtoId">El identificador del requerimiento a obtener.</param>
        /// <returns>El DTO del requerimiento correspondiente.</returns>
        Task<T> GetRequirementByIdAsync(int requirementDtoId, CancellationToken ct = default);

        /// <summary>
        /// Obtiene todos los requerimientos en el sistema.
        /// </summary>
        /// <returns>Una lista de DTOs de todos los requerimientos.</returns>
        Task<IEnumerable<T>> GetAllRequirementsAsync(CancellationToken ct = default);

        /// <summary>
        /// Actualiza un requerimiento existente.
        /// </summary>
        /// <param name="requirementUpdatedDto">DTO del requerimiento con los nuevos datos.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        Task UpdateRequirementAsync(int requirementId, RequirementUpdatedDto requirementUpdatedDto, CancellationToken ct = default);

        /// <summary>
        /// Elimina un requerimiento del sistema.
        /// </summary>
        /// <param name="requirementDtoId">El identificador del requerimiento a eliminar.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        Task DeleteRequirementAsync(int requirementDtoId, CancellationToken ct = default);
    }
}

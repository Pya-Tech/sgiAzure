using SgiAzure.Application.Dtos;
using SgiAzure.Application.Interfaces.Services;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Interfaces.Repositories;

namespace SgiAzure.Application.Services
{
    /// <summary>
    /// Servicio que maneja la lógica de negocio relacionada con los requerimientos.
    /// Implementa la interfaz <see cref="IRequirementService{RequirementDto}"/>.
    /// Utiliza el repositorio de requerimientos para realizar operaciones CRUD en la base de datos.
    /// </summary>
    public class RequirementService : IRequirementService<RequirementDto>
    {
        /// <summary>
        /// Repositorio de requerimientos para interactuar con la base de datos.
        /// </summary>
        private readonly IRequirementRepository<Requirement> _requirementRepository;

        /// <summary>
        /// Constructor de la clase <see cref="RequirementService"/>.
        /// Inyecta la dependencia del repositorio de requerimientos.
        /// </summary>
        /// <param name="requirementRepository">Repositorio para realizar operaciones CRUD con los requerimientos.</param>
        public RequirementService(IRequirementRepository<Requirement> requirementRepository)
        {
            _requirementRepository = requirementRepository;
        }

        /// <summary>
        /// Crea un nuevo requerimiento de forma asíncrona.
        /// Convierte el objeto <see cref="RequirementDto"/> a una entidad <see cref="Requirement"/> 
        /// y lo guarda en la base de datos.
        /// </summary>
        /// <param name="requirementDto">El objeto <see cref="RequirementDto"/> que contiene los datos del requerimiento.</param>
        /// <returns>Una tarea que representa la operación asincrónica de creación.</returns>
        public async Task<RequirementDto> CreateRequirementAsync(RequirementCreatedDto requirementCreatedDto, CancellationToken ct = default)
        {
            var requirement = await _requirementRepository.CreateAsync(requirementCreatedDto.ToDomainEntity(), ct);
            return RequirementDto.FromDomainEntity(requirement);
        }

        /// <summary>
        /// Elimina un requerimiento de forma asíncrona por su identificador.
        /// Llama al repositorio para eliminar el requerimiento correspondiente en la base de datos.
        /// </summary>
        /// <param name="requirementDtoId">Identificador del requerimiento a eliminar.</param>
        /// <returns>Una tarea que representa la operación asincrónica de eliminación.</returns>
        public async Task DeleteRequirementAsync(int requirementDtoId, CancellationToken ct = default)
        {
            await _requirementRepository.DeleteAsync(requirementDtoId, ct);
        }

        /// <summary>
        /// Obtiene todos los requerimientos de forma asíncrona.
        /// Llama al repositorio para obtener todos los requerimientos y los convierte a objetos <see cref="RequirementDto"/>.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica. El resultado es una lista de <see cref="RequirementDto"/>.</returns>
        public async Task<IEnumerable<RequirementDto>> GetAllRequirementsAsync(CancellationToken ct = default)
        {
            var requirements = await _requirementRepository.GetAllAsync(ct);

            return requirements.Select(requirement => RequirementDto.FromDomainEntity(requirement));
        }

        /// <summary>
        /// Obtiene un requerimiento por su identificador de forma asíncrona.
        /// Llama al repositorio para obtener el requerimiento con el ID especificado y lo convierte a un <see cref="RequirementDto"/>.
        /// </summary>
        /// <param name="requirementDtoId">Identificador único del requerimiento.</param>
        /// <returns>Una tarea que representa la operación asincrónica. El resultado es el <see cref="RequirementDto"/> correspondiente.</returns>
        public async Task<RequirementDto> GetRequirementByIdAsync(int requirementDtoId, CancellationToken ct = default)
        {
            var requirement = await _requirementRepository.GetByIdAsync(requirementDtoId, ct);

            return RequirementDto.FromDomainEntity(requirement);
        }

        /// <summary>
        /// Método que actualizaría un requerimiento de forma asíncrona.
        /// Actualmente no está implementado y lanza una excepción si se llama.
        /// </summary>
        /// <param name="requirementDto">El objeto <see cref="RequirementDto"/> con los datos actualizados.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        /// <exception cref="NotImplementedException">Este método aún no está implementado.</exception>
        public async Task UpdateRequirementAsync(int requirementId,RequirementUpdatedDto requirementUpdatedDto, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(nameof(requirementId));
            ArgumentNullException.ThrowIfNull(nameof(requirementUpdatedDto));
            await _requirementRepository.UpdateAsync(requirementId, requirementUpdatedDto.ToDomainEntity(), ct);
        }
    }
}

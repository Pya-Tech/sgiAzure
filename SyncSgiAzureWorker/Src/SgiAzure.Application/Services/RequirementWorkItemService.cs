using SgiAzure.Application.Dtos;
using SgiAzure.Application.Interfaces.Services;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Interfaces.Repositories;

namespace SgiAzure.Application.Services
{
    /// <summary>
    /// Servicio para gestionar operaciones relacionadas con RequirementWorkItems, proporcionando métodos para agregar, obtener, actualizar y eliminar elementos.
    /// </summary>
    public class RequirementWorkItemService : IRequirementWorkItemService<RequirementWorkItemDto>
    {

        /// <summary>
        /// Propiedad encargada de inyectar el repositorio de la relación entre requerimientos y workItem de azure.
        /// </summary>
        private readonly IRequirementWorkItemRepository<RequirementWorkItem> _requirementWorkItemRepository;

        /// <summary>
        /// Constructor que inicializa el servicio con una instancia del repositorio.
        /// </summary>
        /// <param name="repository">Instancia de IRequirementWorkItemRepository para gestionar RequirementWorkItems.</param>
        public RequirementWorkItemService(IRequirementWorkItemRepository<RequirementWorkItem> repository)
        {
            _requirementWorkItemRepository = repository;
        }

        /// <summary>
        /// Agrega un nuevo RequirementWorkItem al repositorio.
        /// </summary>
        /// <param name="requirementWorkItem">Instancia de RequirementWorkItem a agregar.</param>
        public async Task<RequirementWorkItemDto> AddRequirementWorkItemAsync(RequirementWorkItemDto requirementWorkItem, CancellationToken ct = default)
        {
            RequirementWorkItem requirementWorkItemCreated = await _requirementWorkItemRepository.AddAsync(requirementWorkItem.ToDomainEntity());
            return RequirementWorkItemDto.FromDomainEntity(requirementWorkItemCreated);
        }

        public async Task<RequirementWorkItemDto> AddRequirementWorkItemAsync(int workItemId, int requirementId, int customerId, string customerName, CancellationToken ct = default)
        {
            RequirementWorkItem requirementWorkItem = new (){ CustomerId = customerId, WorkItemId = workItemId, RequirementId = requirementId, Customer= customerName };
            await _requirementWorkItemRepository.AddAsync(requirementWorkItem);
            return RequirementWorkItemDto.FromDomainEntity(requirementWorkItem);
        }

        /// <summary>
        /// Obtiene un RequirementWorkItem basado en el ID del Requirement.
        /// </summary>
        /// <param name="requirementId">ID del Requirement asociado al RequirementWorkItem.</param>
        /// <returns>RequirementWorkItem asociado al Requirement, o null si no se encuentra.</returns>
        public async Task<RequirementWorkItemDto?> GetRequirementWorkItemByRequirementIdAsync(int requirementId, CancellationToken ct = default)
        {
            RequirementWorkItem? requirement = await _requirementWorkItemRepository.GetByRequirementIdAsync(requirementId);
            return requirement != null ? RequirementWorkItemDto.FromDomainEntity(requirement):null;
        }



        /// <summary>
        /// Actualiza un RequirementWorkItem existente en el repositorio.
        /// </summary>
        /// <param name="requirementWorkItem">Instancia de RequirementWorkItem con los datos actualizados.</param>
        public async Task UpdateRequirementWorkItemAsync(int requirementId, RequirementWorkItemDto requirementWorkItem, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(requirementWorkItem);
            ArgumentNullException.ThrowIfNull(requirementId);
            await _requirementWorkItemRepository.UpdateAsync(requirementId, requirementWorkItem.ToDomainEntity());
        }

        /// <summary>
        /// Elimina un RequirementWorkItem del repositorio basado en el RequirementId y el WorkItemId.
        /// </summary>
        /// <param name="requirementId">ID del Requirement del RequirementWorkItem a eliminar.</param>
        /// <param name="workItemId">ID del WorkItemEntity del RequirementWorkItem a eliminar.</param>
        public async Task DeleteRequirementWorkItemAsync(int requirementId, int workItemId, CancellationToken ct = default)
        {
            await _requirementWorkItemRepository.DeleteAsync(requirementId, workItemId);
        }

        /// <summary>
        /// Método encargado de obtener una relación WorkItemEntity y requerimiento a partir del identificador del workItem
        /// </summary>
        /// <param name="workItemId"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public async Task<RequirementWorkItemDto> GetRequirementWorkItemsByWorkItemIdAsync(int workItemId, CancellationToken ct = default)
        {
            RequirementWorkItem? requirementWorkItem = await _requirementWorkItemRepository.GetByWorkItemIdAsync(workItemId);
            return requirementWorkItem == null
                ? throw new KeyNotFoundException($"No se encontró un registro con el ID de WorkItemEntity: {workItemId}")
                : RequirementWorkItemDto.FromDomainEntity(requirementWorkItem);
        }


    }
}

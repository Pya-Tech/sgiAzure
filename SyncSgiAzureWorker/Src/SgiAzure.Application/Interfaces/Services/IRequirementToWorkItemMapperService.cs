using SgiAzure.Application.Dtos;
using SgiAzure.Domain.Entities;

namespace SgiAzure.Application.Interfaces.Services
{

    /// <summary>
    /// Interface encargada de abstraer los miembros del servicio de sincronización SGI-Azure
    /// </summary>
    public interface IRequirementToWorkItemMapperService
    {
        /// <summary>
        /// Mapea un Requirement a un WorkItemEntity y lo crea en Azure DevOps.
        /// </summary>
        /// <param name="requirement">El requerimiento que será mapeado.</param>
        /// <returns>El WorkItemEntity creado o mapeado.</returns>
        Task<WorkItemDto> MapRequirementToWorkItemAsync(RequirementDto requirement);

        /// <summary>
        /// Mapea un WorkItemEntity a un Requirement y lo crea en el sistema de gestión.
        /// </summary>
        /// <param name="workItem">El WorkItemEntity que será mapeado.</param>
        /// <returns>El requerimiento creado o mapeado.</returns>
        Task<WorkItemDto> MapWorkItemToRequirementAsync(WorkItemDto workItem);
    }
}

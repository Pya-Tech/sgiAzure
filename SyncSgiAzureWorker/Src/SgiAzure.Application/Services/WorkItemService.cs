using SgiAzure.Application.Dtos;
using SgiAzure.Application.Interfaces.Services;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Interfaces.Providers;

namespace SgiAzure.Application.Services
{
    /// <summary>
    /// Servicio para gestionar workitems en Azure DevOps.
    /// Proporciona métodos para crear, actualizar, eliminar y consultar workitems,
    /// así como para realizar operaciones específicas como agregar comentarios, cambiar el tipo de workitem,
    /// clonar workitems y revertir a una revisión específica.
    /// </summary>
    /// <typeparam name="WorkItemDto">Tipo DTO que representa un workitem.</typeparam>
    public class WorkItemService : IWorkItemService<WorkItemDto>
    {

        /// <summary>
        /// Proveedor de workItems
        /// </summary>
        private readonly IAzureWorkItemProvider<WorkItemEntity> _azureWorkItemProvider;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="WorkItemService"/>.
        /// </summary>
        /// <param name="azureWorkItemProvider">Proveedor de workitems de Azure DevOps.</param>
        /// <exception cref="ArgumentNullException">Se lanza si <paramref name="azureWorkItemProvider"/> es nulo.</exception>
        public WorkItemService(IAzureWorkItemProvider<WorkItemEntity> azureWorkItemProvider)
        {
            _azureWorkItemProvider = azureWorkItemProvider ?? throw new ArgumentNullException(nameof(azureWorkItemProvider));
        }

        /// <summary>
        /// Agrega un comentario a un workitem existente.
        /// </summary>
        /// <param name="workItemId">ID del workitem al que se agregará el comentario.</param>
        /// <param name="comment">Comentario a agregar.</param>
        /// <returns>Un DTO que representa el workitem actualizado.</returns>
        public async Task<WorkItemDto> AddCommentAsync(int workItemId, string comment)
        {
            var workItemEntity = await _azureWorkItemProvider.AddCommentAsync(workItemId, comment);
            return WorkItemDto.FromDomainEntity(workItemEntity);
        }

        /// <summary>
        /// Cambia el tipo de un workitem existente.
        /// </summary>
        /// <param name="workItemId">ID del workitem cuyo tipo se cambiará.</param>
        /// <param name="newType">Nuevo tipo de workitem.</param>
        /// <returns>Un DTO que representa el workitem actualizado.</returns>
        public async Task<WorkItemDto> ChangeWorkItemTypeAsync(int workItemId, string newType)
        {
            var workItemEntity = await _azureWorkItemProvider.ChangeWorkItemTypeAsync(workItemId, newType);
            return WorkItemDto.FromDomainEntity(workItemEntity);
        }

        /// <summary>
        /// Clona un workitem existente.
        /// </summary>
        /// <param name="workItemId">ID del workitem a clonar.</param>
        /// <returns>Un DTO que representa el workitem clonado.</returns>
        public async Task<WorkItemDto> CloneWorkItemAsync(int workItemId)
        {
            var workItemEntity = await _azureWorkItemProvider.CloneWorkItemAsync(workItemId);
            return WorkItemDto.FromDomainEntity(workItemEntity);
        }

        /// <summary>
        /// Crea un nuevo workitem en Azure DevOps.
        /// </summary>
        /// <param name="workItem">DTO con los datos del workitem a crear.</param>
        /// <returns>Un DTO que representa el workitem creado.</returns>
        public async Task<WorkItemDto> CreateWorkItemAsync(WorkItemCreatedDto workItem)
        {
            var workItemEntity = await _azureWorkItemProvider.CreateWorkItemAsync(workItem.ToDomainEntity());
            return WorkItemDto.FromDomainEntity(workItemEntity);
        }

        /// <summary>
        /// Elimina un workitem existente.
        /// </summary>
        /// <param name="workItemId">ID del workitem a eliminar.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        public async Task DeleteWorkItemAsync(int workItemId)
        {
            await _azureWorkItemProvider.DeleteWorkItemAsync(workItemId);
        }

        /// <summary>
        /// Obtiene un workitem por su ID.
        /// </summary>
        /// <param name="workItemId">ID del workitem a obtener.</param>
        /// <returns>Un DTO que representa el workitem.</returns>
        public async Task<WorkItemDto> GetWorkItemAsync(int workItemId)
        {
            var workItemEntity = await _azureWorkItemProvider.GetWorkItemAsync(workItemId);
            return WorkItemDto.FromDomainEntity(workItemEntity);
        }

        /// <summary>
        /// Obtiene todos los workitems de un proyecto específico.
        /// </summary>
        /// <param name="projectName">Nombre del proyecto.</param>
        /// <returns>Una lista de DTOs que representan los workitems del proyecto.</returns>
        public async Task<List<WorkItemDto>> GetWorkItemsByProjectAsync(string projectName)
        {
            var workItemsEntities = await _azureWorkItemProvider.GetWorkItemsByProjectAsync(projectName);
            return workItemsEntities.Select(workItem => WorkItemDto.FromDomainEntity(workItem)).ToList();
        }

        /// <summary>
        /// Revierte un workitem a una revisión específica.
        /// </summary>
        /// <param name="workItemId">ID del workitem a revertir.</param>
        /// <param name="revisionId">ID de la revisión a la que se revertirá el workitem.</param>
        /// <returns>Un DTO que representa el workitem revertido.</returns>
        public async Task<WorkItemDto> RollbackWorkItemByRevisionId(int workItemId, int revisionId)
        {
            var workItemEntity = await _azureWorkItemProvider.RevertWorkItemToRevision(workItemId, revisionId);
            return WorkItemDto.FromDomainEntity(workItemEntity);
        }

        /// <summary>
        /// Actualiza un workitem existente.
        /// </summary>
        /// <param name="workItemId">ID del workitem a actualizar.</param>
        /// <param name="workItem">DTO con los nuevos datos del workitem.</param>
        /// <returns>Un DTO que representa el workitem actualizado.</returns>
        public async Task<WorkItemDto> UpdateWorkItemAsync(int workItemId, WorkItemUpdatedDto workItem)
        {
            var workItemDto = await _azureWorkItemProvider.GetWorkItemAsync(workItemId);
            if (workItemDto == null)
            {
                throw new KeyNotFoundException($"No existe workItem con el identificador {workItemId}");
            }

            var workItemEntity = await _azureWorkItemProvider.UpdateWorkItemAsync(workItemId, workItem.ToDomainEntity());
            return WorkItemDto.FromDomainEntity(workItemEntity);
        }
    }
}
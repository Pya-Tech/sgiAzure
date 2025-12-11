using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.VisualStudio.Services.WebApi.Patch;
using Microsoft.VisualStudio.Services.WebApi.Patch.Json;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Enumerators;
using SgiAzure.Domain.Exceptions;
using SgiAzure.Domain.Interfaces.Providers;
using SgiAzure.Infrastructure.Builders;
using SgiAzure.Infrastructure.Mappers;
using SgiAzure.Infrastructure.Settings;

namespace SgiAzure.Infrastructure.Providers
{
    /// <summary>
    /// Proveedor para interactuar con los WorkItems de Azure DevOps.
    /// Implementa la interfaz <see cref="IAzureWorkItemProvider{WorkItem}"/> y proporciona métodos para crear, 
    /// actualizar y recuperar WorkItems de un proyecto de Azure DevOps.
    /// </summary>
    public class AzureWorkItemProvider : IAzureWorkItemProvider<WorkItemEntity>
    {
        private WorkItemTrackingHttpClient _workItemClient { get; set; }
        private AzureDevopsServerSettings _azureDevopsServerSettings { get; set; }
        private AzureConfigurations _azureConfigurations { get; set; }
        private VssConnection _connection { get; set; }

        /// <summary>
        /// Constructor de la clase que inicializa el cliente de Azure DevOps y la configuración necesaria.
        /// </summary>
        /// <param name="azureConfigurations">Configuraciones de Azure para los campos de WorkItem.</param>
        /// <param name="azureDevopsServerSettings">Configuraciones del servidor de Azure DevOps.</param>
        public AzureWorkItemProvider(AzureConfigurations azureConfigurations, AzureDevopsServerSettings azureDevopsServerSettings)
        {
            _azureConfigurations = azureConfigurations;
            _azureDevopsServerSettings = azureDevopsServerSettings;
            var connection = new VssConnection(azureDevopsServerSettings.Uri,
                                                   new VssBasicCredential(string.Empty, _azureDevopsServerSettings.Token.Trim()));
            ConnectAzureWorkItemProvider(connection);
        }

        public void ConnectAzureWorkItemProvider(VssConnection connection)
        {
            try
            {
                _workItemClient = connection.GetClient<WorkItemTrackingHttpClient>();
                _connection = connection;
            }
            catch (VssUnauthorizedException unauthorizedEx)
            {
                throw new AzureException(unauthorizedEx.Message, ErrorCode.AzureNotAuthorized, unauthorizedEx.InnerException);
            }

        }

        /// <summary>
        /// Construye el documento JSON para un WorkItem basado en los datos de <see cref="WorkItemEntity"/>.
        /// </summary>
        /// <param name="workItem">Entidad de tipo <see cref="WorkItemEntity"/> que representa un WorkItem.</param>
        /// <returns>Un <see cref="JsonPatchDocument"/> para crear o actualizar un WorkItem.</returns>
        private JsonPatchDocument BuildWorkItemCreatedJson(WorkItemEntity workItem)
        {
            return new CreatedWorkItemBuilder(_azureConfigurations.Fields)
                .WithTitle(workItem.Title ?? string.Empty)
                .WithDescription(workItem.Description ?? string.Empty)
                .WithRequirement(workItem.RequirementId.ToString() ?? string.Empty)
                .WithPriority(int.Parse(workItem.Priority))
                .WithAssignedUser(workItem.ResponsibleUser)
                .WithAssignTo(_azureDevopsServerSettings.User)
                .WithStartDate(workItem.StartDate)
                .WithTargetDate(workItem.TargetDate)
                .WithCompany(workItem.Company ?? string.Empty)
                .WithSystem(workItem.System ?? string.Empty)
                .WithCreatedBy(workItem.CreatedBy ?? string.Empty)
                .WithReportType(workItem.ReportType)
                .WithProcessingType(workItem.ProcessingType)
                .WithState(workItem.State)
                .WithComment(workItem.Comment)
                .Build();
        }

        /// <summary>
        /// Construye el documento JSON para un WorkItem basado en los datos de <see cref="WorkItemEntity"/>.
        /// </summary>
        /// <param name="workItem">Entidad de tipo <see cref="WorkItemEntity"/> que representa un WorkItem.</param>
        /// <returns>Un <see cref="JsonPatchDocument"/> para crear o actualizar un WorkItem.</returns>
        private JsonPatchDocument BuildWorkItemUpdatedJson(WorkItemEntity workItem)
        {
            return new UpdateWorkItemBuilder(_azureConfigurations.Fields)
                .WithTitle(workItem.Title ?? string.Empty)
                .WithDescription(workItem.Description ?? string.Empty)
                .WithRequirement(workItem.RequirementId.ToString() ?? string.Empty)
                .WithPriority(int.TryParse(workItem.Priority, out var pr) ? pr : null)
                .WithAssignedUser(workItem.ResponsibleUser)
                .WithAssignTo(_azureDevopsServerSettings.User)
                .WithStartDate(workItem.StartDate)
                .WithTargetDate(workItem.TargetDate)
                .WithCompany(workItem.Company ?? string.Empty)
                .WithSystem(workItem.System ?? string.Empty)
                .WithCreatedBy(workItem.CreatedBy ?? string.Empty)
                .WithReportType(workItem.ReportType ?? string.Empty)
                .WithProcessingType(workItem.ProcessingType ?? string.Empty)
                .WithState(workItem.State)
                .WithComment(workItem.Comment)
                .Build();
        }

        /// <summary>
        /// Crea un nuevo WorkItem en Azure DevOps.
        /// </summary>
        /// <param name="workItem">El WorkItem que se va a crear.</param>
        /// <returns>La entidad <see cref="WorkItemEntity"/> creada con el ID del WorkItem.</returns>
        /// <exception cref="ObjectDisposedException">Se lanza si el cliente ha sido dispuesto.</exception>
        /// <exception cref="InvalidOperationException">Se lanza si no se puede crear el WorkItem.</exception>
        public async Task<WorkItemEntity> CreateWorkItemAsync(WorkItemEntity workItem)
        {
            if (_workItemClient == null)
            {
                throw new ObjectDisposedException(nameof(_workItemClient), "El cliente ha sido dispuesto.");
            }

            var json = BuildWorkItemCreatedJson(workItem);

            var createdWorkItem = await _workItemClient.CreateWorkItemAsync(json,
                                                                           _azureDevopsServerSettings.Project,
                                                                           workItem.WorkItemType)
                                  ?? throw new InvalidOperationException("No se pudo insertar WorkItemEntity.");

            var mapper = new WorkItemMapper(_azureConfigurations.Fields);
            
            WorkItemEntity workItemEntity = mapper.MapToWorkItemEntity(createdWorkItem);
            return workItemEntity;
        }

        /// <summary>
        /// Obtiene un WorkItem existente en Azure DevOps utilizando su ID.
        /// </summary>
        /// <param name="workItemId">El ID del WorkItem a obtener.</param>
        /// <returns>La entidad <see cref="WorkItemEntity"/> correspondiente al WorkItem obtenido.</returns>
        /// <exception cref="InvalidOperationException">Se lanza si no se encuentra el WorkItem.</exception>
        public async Task<WorkItemEntity> GetWorkItemAsync(int workItemId)
        {
            var workItem = await _workItemClient.GetWorkItemAsync(workItemId)
                           ?? throw new AzureException($"No existe workItem con el identificador {workItemId}", ErrorCode.AzureWorkItemNotFound);
            return new WorkItemEntity
            {
                WorkItemId = workItem.Id,
            };
        }

        /// <summary>
        /// Actualiza un WorkItem existente en Azure DevOps.
        /// </summary>
        /// <param name="workItemId">El ID del WorkItem que se desea actualizar.</param>
        /// <param name="workItem">La entidad <see cref="WorkItemEntity"/> con los nuevos datos.</param>
        /// <returns>La entidad <see cref="WorkItemEntity"/> actualizada.</returns>
        /// <exception cref="ObjectDisposedException">Se lanza si el cliente ha sido dispuesto.</exception>
        /// <exception cref="InvalidOperationException">Se lanza si no se puede actualizar el WorkItem.</exception>
        public async Task<WorkItemEntity> UpdateWorkItemAsync(int workItemId, WorkItemEntity workItem)
        {
            if (_workItemClient == null)
                throw new ObjectDisposedException(nameof(_workItemClient), "El cliente ha sido dispuesto.");

            var json = BuildWorkItemUpdatedJson(workItem);

            var updatedWorkItem = await _workItemClient.UpdateWorkItemAsync(json, workItemId)
                                       ?? throw new InvalidOperationException("No se pudo actualizar WorkItemEntity.");

            var mapper = new WorkItemMapper(_azureConfigurations.Fields);

            WorkItemEntity workItemEntity = mapper.MapToWorkItemEntity(updatedWorkItem);
            return workItemEntity;
        }

        /// <summary>
        /// Elimina un WorkItem de Azure DevOps.
        /// </summary>
        /// <param name="workItemId">El ID del WorkItem a eliminar.</param>
        /// <exception cref="InvalidOperationException">Se lanza si ocurre un error al eliminar el WorkItem.</exception>
        public async Task DeleteWorkItemAsync(int workItemId)
        {
            try
            {
                await _workItemClient.DeleteWorkItemAsync(workItemId);
            }
            catch (Exception ex)
            {
                throw new AzureException($"Error al eliminar el WorkItem con ID {workItemId}: {ex.Message}", ErrorCode.AzureWorkItemDeleteFailed);
            }
        }

        /// <summary>
        /// Cambia el tipo de un WorkItem en Azure DevOps.
        /// </summary>
        /// <param name="workItemId">El ID del WorkItem cuyo tipo se desea cambiar.</param>
        /// <param name="newType">El nuevo tipo de WorkItem.</param>
        /// <returns>La entidad <see cref="WorkItemEntity"/> con el nuevo tipo.</returns>
        /// <exception cref="InvalidOperationException">Se lanza si ocurre un error al cambiar el tipo.</exception>
        public async Task<WorkItemEntity> ChangeWorkItemTypeAsync(int workItemId, string newType)
        {
            try
            {
                var patchDocument = new JsonPatchDocument
                {
                    new JsonPatchOperation
                    {
                        Operation = Operation.Replace,
                        Path = "/fields/System.WorkItemType",
                        Value = newType
                    }
                };

                var updatedWorkItem = await _workItemClient.UpdateWorkItemAsync(patchDocument, workItemId);
                return new WorkItemEntity { WorkItemId = updatedWorkItem.Id };
            }
            catch (Exception ex)
            {
                throw new AzureException($"Error al cambiar el tipo del WorkItem con ID {workItemId}: {ex.Message}");
            }
        }

        /// <summary>
        /// Clona un WorkItem existente en Azure DevOps.
        /// </summary>
        /// <param name="workItemId">El ID del WorkItem a clonar.</param>
        /// <returns>La entidad <see cref="WorkItemEntity"/> con el ID del WorkItem clonado.</returns>
        /// <exception cref="InvalidOperationException">Se lanza si ocurre un error al clonar el WorkItem.</exception>
        public async Task<WorkItemEntity> CloneWorkItemAsync(int workItemId)
        {
            try
            {
                var workItem = await _workItemClient.GetWorkItemAsync(workItemId);
                //var clonedWorkItem = await _workItemClient.CreateWorkItemAsync(BuildWorkItemJson(workItem), _azureDevopsServerSettings.Project, workItem.Type.Name);
                return new WorkItemEntity { WorkItemId = workItemId };
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al clonar el WorkItem con ID {workItemId}: {ex.Message}");
            }
        }

        /// <summary>
        /// Añade un comentario a un WorkItem existente en Azure DevOps.
        /// </summary>
        /// <param name="workItemId">El ID del WorkItem al que se añadirá el comentario.</param>
        /// <param name="comment">El comentario que se añadirá al WorkItem.</param>
        /// <returns>La entidad <see cref="WorkItemEntity"/> con el ID del WorkItem actualizado.</returns>
        /// <exception cref="InvalidOperationException">Se lanza si ocurre un error al añadir el comentario.</exception>
        public async Task<WorkItemEntity> AddCommentAsync(int workItemId, string comment)
        {
            try
            {
                var patchDocument = new JsonPatchDocument
                {
                    new JsonPatchOperation
                    {
                        Operation = Operation.Add,
                        Path = "/fields/System.History",
                        Value = comment
                    }
                };
                var updatedWorkItem = await _workItemClient.UpdateWorkItemAsync(patchDocument, workItemId);
                return new WorkItemEntity { WorkItemId = updatedWorkItem.Id };
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al añadir comentario al WorkItem con ID {workItemId}: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene los WorkItems de un proyecto de Azure DevOps.
        /// </summary>
        /// <param name="projectName">El nombre del proyecto de Azure DevOps.</param>
        /// <returns>Una lista de entidades <see cref="WorkItemEntity"/> que representan los WorkItems del proyecto.</returns>
        /// <exception cref="InvalidOperationException">Se lanza si ocurre un error al obtener los WorkItems.</exception>
        public async Task<List<WorkItemEntity>> GetWorkItemsByProjectAsync(string projectName)
        {
            try
            {
                var workItems = await _workItemClient.QueryByWiqlAsync(new Wiql
                {
                    Query = $"SELECT [System.Id], [System.Title] FROM WorkItems WHERE [System.TeamProject] = '{projectName}'"
                });

                return workItems.WorkItems.Select(item => new WorkItemEntity { WorkItemId = item.Id }).ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al obtener los WorkItems del proyecto {projectName}: {ex.Message}");
            }
        }

        public async Task<WorkItemEntity> RevertWorkItemToRevision(int workItemId, int revisionId)
        {
            var revisions = await _workItemClient.GetRevisionsAsync(workItemId);
            var specificRevision = revisions.First(r => r.Rev == revisionId);

            if (specificRevision == null)
            {
                throw new InvalidDataException("Revisión no encontrada.");
            }
            var update = new JsonPatchDocument();

            foreach (var field in specificRevision.Fields)
            {
                update.Add(new JsonPatchOperation
                {
                    Operation = Operation.Replace,
                    Path = $"/fields/{field.Key}",
                    Value = field.Value
                });
            }
            var updatedWorkItem = await _workItemClient.UpdateWorkItemAsync(update, workItemId);
            var mapper = new WorkItemMapper(_azureConfigurations.Fields);

            WorkItemEntity workItemEntity = mapper.MapToWorkItemEntity(updatedWorkItem);
            return workItemEntity;
        }
    }
}

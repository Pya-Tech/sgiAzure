using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Interfaces.Services;
using SgiAzure.Infrastructure.Builders;
using SgiAzure.Infrastructure.Settings;

namespace SgiAzure.Infrastructure.Services
{

    /// <summary>
    /// Servicio encargado de gestionar objetos WorkItemEntity de azure Devops
    /// </summary>
    public class AzureWorkItemService : IAzureWorkItemService<WorkItemEntity>
    {

        /// <summary>
        /// Objeto de configuración de azure
        /// </summary>
        private readonly AzureConfigurations _azureConfigurations;

        /// <summary>
        /// Objeto que contiene la conexión a azure
        /// </summary>
        private AzureDevopsServerSettings _azureDevopsServerSettings { get; set; }


        /// <summary>
        /// Cliente Genérico para la consulta de WorkItems
        /// </summary>
        private WorkItemTrackingHttpClient _workItemClient { get; set; }



        /// <summary>
        /// Método que contiene la interface
        /// </summary>
        /// <param name="options">Objeto que contiene la configuración de Azure</param>
        public AzureWorkItemService(AzureDevopsServerSettings azureDevopsServerSettings, AzureConfigurations azureConfigurations)
        {
            _azureConfigurations = azureConfigurations;
            _azureDevopsServerSettings = azureDevopsServerSettings;
            var vssConnection = new VssConnection(azureDevopsServerSettings.Uri, new VssBasicCredential(string.Empty, _azureDevopsServerSettings.Token));
            _workItemClient = vssConnection.GetClient<WorkItemTrackingHttpClient>();
        }

        public async Task<WorkItemEntity> CreateWorkItemAsync(WorkItemEntity workitem)
        {
            if (_workItemClient == null)
            {
                throw new ObjectDisposedException(nameof(_workItemClient), "El cliente ha sido dispuesto.");
            }
            var json =  new CreatedWorkItemBuilder(_azureConfigurations.Fields)
                .WithTitle(workitem.Title ?? string.Empty)
                .WithDescription(workitem.Description ?? string.Empty)
                .WithRequirement(workitem.RequirementId.ToString() ?? string.Empty)
                .WithPriority(int.Parse(workitem.Priority))
                .WithAssignedUser(workitem.ResponsibleUser)
                //.WithAssignTo(workitem.AssignedTo ?? string.Empty)
                .WithAssignTo("pablo.serrano" ?? string.Empty)
                .WithStartDate(workitem.StartDate)
                .WithTargetDate(workitem.TargetDate)
                .WithCompany(workitem.Company ?? string.Empty)
                .WithSystem(workitem.System ?? string.Empty)
                .WithCreatedBy(workitem.CreatedBy ?? string.Empty)
                .WithReportType(workitem.ReportType ?? string.Empty)
                .WithProcessingType(workitem.ProcessingType ?? string.Empty)
                .Build();
            var createdWorkItem = await _workItemClient.CreateWorkItemAsync(json, _azureDevopsServerSettings.Project, workitem.WorkItemType) ?? throw new InvalidOperationException("no se pudo insertar WorkItemEntity.");
            WorkItemEntity responseWorkItem = new()
            {
                WorkItemId = createdWorkItem.Id,
                RequirementId = workitem.RequirementId,
            };
            return responseWorkItem;
        }

        public async Task<WorkItemEntity> UpdateWorkItemAsync(int id, WorkItemEntity workitem)
        {
            if (_workItemClient == null) throw new ObjectDisposedException(nameof(_workItemClient), "El cliente ha sido dispuesto.");

            var json = new UpdateWorkItemBuilder(_azureConfigurations.Fields)
                .WithTitle(workitem.Title ?? string.Empty)
                .WithDescription(workitem.Description ?? string.Empty)
                .WithRequirement(workitem.RequirementId.ToString() ?? string.Empty)
                .WithPriority(int.Parse(workitem.Priority))
                .WithAssignedUser(workitem.ResponsibleUser)
                .WithAssignTo(workitem.AssignedTo ?? string.Empty)
                .WithStartDate(workitem.StartDate ?? DateTime.Now)
                .WithTargetDate(workitem.TargetDate ?? DateTime.Now)
                .WithCompany(workitem.Company ?? string.Empty)
                .WithSystem(workitem.System ?? string.Empty)
                .WithCreatedBy(workitem.CreatedBy ?? string.Empty)
                .WithReportType(workitem.ReportType ?? string.Empty)
                .WithProcessingType(workitem.ProcessingType ?? string.Empty)
                .Build();

            var newWorkItem = await _workItemClient.UpdateWorkItemAsync(json, id) ?? throw new InvalidOperationException("no se pudo insertar WorkItemEntity.");
            WorkItemEntity responseWorkItem = new()
            {
                WorkItemId = newWorkItem.Id,
                RequirementId = workitem.RequirementId,
            };
            return responseWorkItem;
        }

        public Task<WorkItemEntity> GetWorkItemAsync(int workItemId)
        {
            throw new NotImplementedException();
        }
    }
}

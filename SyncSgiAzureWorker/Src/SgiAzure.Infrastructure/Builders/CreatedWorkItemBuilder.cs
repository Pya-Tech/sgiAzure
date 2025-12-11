using Microsoft.VisualStudio.Services.WebApi.Patch.Json;
using SgiAzure.Infrastructure.Settings;

namespace SgiAzure.Infrastructure.Builders
{
    /// <summary>
    /// Builder para crear un documento de parche (<see cref="JsonPatchDocument"/>) para WorkItems.
    /// Proporciona métodos para configurar campos específicos del WorkItemEntity.
    /// </summary>
    /// <remarks>
    /// Método constructor del builder
    /// </remarks>
    public class CreatedWorkItemBuilder(AzureFieldsConfiguration azureConfigurations) : BaseWorkItemPatchDocumentBuilder(azureConfigurations)
    {

        /// <summary>
        /// Especifica el título del WorkItemEntity.
        /// </summary>
        public CreatedWorkItemBuilder WithTitle(string title)
        {
            AddField(_fieldsConfiguration.TitleField, title);
            return this;
        }

        /// <summary>
        /// Especifica el sistema asociado al WorkItemEntity.
        /// </summary>
        public CreatedWorkItemBuilder WithSystem(string system)
        {
            AddField(_fieldsConfiguration.SystemField, system);
            return this;
        }

        /// <summary>
        /// Especifica el sistema asociado al WorkItemEntity.
        /// </summary>
        public CreatedWorkItemBuilder WithCreatedBy(string createdBy)
        {
            AddField(_fieldsConfiguration.CreatedBy, createdBy);
            return this;
        }

        /// <summary>
        /// Especifica el sistema asociado al WorkItemEntity.
        /// </summary>
        public CreatedWorkItemBuilder WithProcessingType(string? processingType)
        {
            AddField(_fieldsConfiguration.ProcessingType, processingType);
            return this;
        }


        /// <summary>
        /// Especifica el sistema asociado al WorkItemEntity.
        /// </summary>
        public CreatedWorkItemBuilder WithReportType(string reportType)
        {
            AddField(_fieldsConfiguration.ReportType, reportType);
            return this;
        }

        /// <summary>
        /// Especifica la descripción del WorkItemEntity.
        /// </summary>
        public CreatedWorkItemBuilder WithDescription(string description)
        {
            AddField(_fieldsConfiguration.DescriptionField, description);
            return this;
        }

        /// <summary>
        /// Especifica la prioridad del WorkItemEntity.
        /// </summary>
        public CreatedWorkItemBuilder WithPriority(int priority)
        {
            AddField(_fieldsConfiguration.PriorityField, priority);
            return this;
        }


        /// <summary>
        /// Especifica la prioridad del WorkItemEntity.
        /// </summary>
        public CreatedWorkItemBuilder WithState(string? state)
        {
            AddField(_fieldsConfiguration.State, state);
            return this;
        }

        /// <summary>
        /// Especifica la prioridad del WorkItemEntity.
        /// </summary>
        public CreatedWorkItemBuilder WithReason(string reason)
        {
            AddField(_fieldsConfiguration.Reason, reason);
            return this;
        }

        /// <summary>
        /// Especifica la prioridad del WorkItemEntity.
        /// </summary>
        public CreatedWorkItemBuilder WithCommentCount(string commentCount)
        {
            AddField(_fieldsConfiguration.CommentCount, commentCount);
            return this;
        }

        /// <summary>
        /// Especifica la fecha de inicio del WorkItemEntity.
        /// </summary>
        public CreatedWorkItemBuilder WithStartDate(DateTime? startDate)
        {
            AddField(_fieldsConfiguration.StartDateField, startDate);
            return this;
        }

        /// <summary>
        /// Especifica el usuario asignado al WorkItemEntity.
        /// </summary>
        public CreatedWorkItemBuilder WithAssignTo(string email)
        {
            AddField(_fieldsConfiguration.AssignToField, email);
            return this;
        }

        /// <summary>
        /// Especifica el campo Custom.Requirement.
        /// </summary>
        public CreatedWorkItemBuilder WithRequirement(string requirement)
        {
            AddField(_fieldsConfiguration.RequirementField, requirement);
            return this;
        }

        /// <summary>
        /// Especifica el campo Custom.Company.
        /// </summary>
        public CreatedWorkItemBuilder WithCompany(string company)
        {
            AddField(_fieldsConfiguration.CompanyField, company);
            return this;
        }

        /// <summary>
        /// Especifica el campo Custom.AssignedUser.
        /// </summary>
        public CreatedWorkItemBuilder WithAssignedUser(string assignedUser)
        {
            AddField(_fieldsConfiguration.AssignedUserField, assignedUser);
            return this;
        }

        /// <summary>
        /// Especifica si el WorkItemEntity es requerido.
        /// </summary>
        public CreatedWorkItemBuilder WithRequired(bool required)
        {
            AddField(_fieldsConfiguration.RequiredField, required);
            return this;
        }

        /// <summary>
        /// Especifica la fecha objetivo del WorkItemEntity.
        /// </summary>
        public CreatedWorkItemBuilder WithTargetDate(DateTime? targetDate)
        {
            AddField(_fieldsConfiguration.TargetDateField, targetDate);
            return this;
        }


        /// <summary>
        /// Especifica el usuario asignado al WorkItemEntity.
        /// </summary>
        public CreatedWorkItemBuilder WithComment(string? comment)
        {
            AddField(_fieldsConfiguration.CommentField, comment);
            return this;
        }

        /// <summary>
        /// Agrega un campo personalizado al WorkItemEntity.
        /// </summary>
        public CreatedWorkItemBuilder WithCustomField(string fieldName, object value)
        {
            if (string.IsNullOrEmpty(fieldName))
                throw new ArgumentException("El nombre del campo no puede estar vacío.", nameof(fieldName));

            AddField($"/fields/{fieldName}", value);
            return this;
        }
    }
}

using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Services.WebApi.Patch;
using Microsoft.VisualStudio.Services.WebApi.Patch.Json;
using SgiAzure.Infrastructure.Settings;

namespace SgiAzure.Infrastructure.Builders
{
    /// <summary>
    /// Builder para crear un documento de actualización de WorkItemEntity (<see cref="JsonPatchDocument"/>).
    /// Este builder proporciona métodos para establecer o actualizar campos específicos de un WorkItemEntity
    /// en Azure DevOps mediante un enfoque fluido.
    /// </summary>
    /// <remarks>
    /// Constructor del builder para actualizar un WorkItemEntity.
    /// </remarks>
    /// <param name="azureConfigurations">Objeto que contiene las configuraciones de Azure.</param>
    /// <exception cref="InvalidOperationException">Se lanza si las configuraciones de Azure o los campos están nulos.</exception>
    public class UpdateWorkItemBuilder(AzureFieldsConfiguration azureConfigurations) : BaseWorkItemPatchDocumentBuilder(azureConfigurations)
    {


        /// <summary>
        /// Actualiza el título del WorkItemEntity.
        /// </summary>
        /// <param name="title">Nuevo título del WorkItemEntity.</param>
        /// <returns>Instancia del builder con el cambio aplicado.</returns>
        public UpdateWorkItemBuilder WithTitle(string title)
        {
            AddField(_fieldsConfiguration.TitleField, title, Operation.Replace);
            return this;
        }

        /// <summary>
        /// Actualiza el usuario asignado del WorkItemEntity.
        /// </summary>
        /// <param name="assignedUser">Nuevo título del WorkItemEntity.</param>
        /// <returns>Instancia del builder con el cambio aplicado.</returns>
        public UpdateWorkItemBuilder WithAssignedUser(string assignedUser)
        {
            AddField(_fieldsConfiguration.AssignedUserField, assignedUser, Operation.Replace);
            return this;
        }


        /// <summary>
        /// Actualiza la descripción del WorkItemEntity.
        /// </summary>
        /// <param name="description">Nueva descripción del WorkItemEntity.</param>
        /// <returns>Instancia del builder con el cambio aplicado.</returns>
        public UpdateWorkItemBuilder WithDescription(string description)
        {
            AddField(_fieldsConfiguration.DescriptionField, description, Operation.Replace);
            return this;
        }

        /// <summary>
        /// Actualiza la prioridad del WorkItemEntity.
        /// </summary>
        /// <param name="priority">Nueva prioridad del WorkItemEntity (entero).</param>
        /// <returns>Instancia del builder con el cambio aplicado.</returns>
        public UpdateWorkItemBuilder WithPriority(int? priority)
        {
            if (priority == null) return this;
            AddField(_fieldsConfiguration.PriorityField, priority, Operation.Replace);
            return this;
        }


        /// <summary>
        /// Especifica la prioridad del WorkItemEntity.
        /// </summary>
        public UpdateWorkItemBuilder WithState(string? state)
        {
            AddField(_fieldsConfiguration.State, state, Operation.Replace);
            return this;
        }

        /// <summary>
        /// Especifica la prioridad del WorkItemEntity.
        /// </summary>
        public UpdateWorkItemBuilder WithReason(string? reason)
        {
            AddField(_fieldsConfiguration.Reason, reason, Operation.Replace);
            return this;
        }

        /// <summary>
        /// Especifica la prioridad del WorkItemEntity.
        /// </summary>
        public UpdateWorkItemBuilder WithCommentCount(string? commentCount)
        {
            AddField(_fieldsConfiguration.CommentCount, commentCount, Operation.Replace);
            return this;
        }

        /// <summary>
        /// Asigna un usuario al WorkItemEntity.
        /// </summary>
        /// <param name="email">Correo electrónico del usuario asignado.</param>
        /// <returns>Instancia del builder con el cambio aplicado.</returns>
        public UpdateWorkItemBuilder WithAssignedTo(string email)
        {
            AddField(_fieldsConfiguration.AssignedUserField, email, Operation.Replace);
            return this;
        }

        /// <summary>
        /// Establece o actualiza la fecha objetivo del WorkItemEntity.
        /// </summary>
        /// <param name="targetDate">Nueva fecha objetivo.</param>
        /// <returns>Instancia del builder con el cambio aplicado.</returns>
        public UpdateWorkItemBuilder WithTargetDate(DateTime? targetDate)
        {
            AddField(_fieldsConfiguration.TargetDateField, targetDate, Operation.Replace);
            return this;
        }



        /// <summary>
        /// Especifica el sistema asociado al WorkItemEntity.
        /// </summary>
        public UpdateWorkItemBuilder WithSystem(string system)
        {
            AddField(_fieldsConfiguration.SystemField, system, Operation.Replace);
            return this;
        }

        /// <summary>
        /// Especifica el sistema asociado al WorkItemEntity.
        /// </summary>
        public UpdateWorkItemBuilder WithCreatedBy(string createdBy)
        {
            AddField(_fieldsConfiguration.CreatedBy, createdBy, Operation.Replace);
            return this;
        }

        /// <summary>
        /// Especifica el sistema asociado al WorkItemEntity.
        /// </summary>
        public UpdateWorkItemBuilder WithProcessingType(string processingType)
        {
            AddField(_fieldsConfiguration.ProcessingType, processingType, Operation.Replace);
            return this;
        }


        /// <summary>
        /// Especifica el sistema asociado al WorkItemEntity.
        /// </summary>
        public UpdateWorkItemBuilder WithReportType(string reportType)
        {
            AddField(_fieldsConfiguration.ReportType, reportType, Operation.Replace);
            return this;
        }

  
        /// <summary>
        /// Especifica la fecha de inicio del WorkItemEntity.
        /// </summary>
        public UpdateWorkItemBuilder WithStartDate(DateTime? startDate)
        {
            AddField(_fieldsConfiguration.StartDateField, startDate, Operation.Replace);
            return this;
        }

        /// <summary>
        /// Especifica el usuario asignado al WorkItemEntity.
        /// </summary>
        public UpdateWorkItemBuilder WithAssignTo(string email)
        {
            AddField(_fieldsConfiguration.AssignToField, email, Operation.Replace);
            return this;
        }

        /// <summary>
        /// Especifica el campo Custom.Requirement.
        /// </summary>
        public UpdateWorkItemBuilder WithRequirement(string requirement)
        {
            AddField(_fieldsConfiguration.RequirementField, requirement, Operation.Replace);
            return this;
        }

        /// <summary>
        /// Especifica el campo Custom.Company.
        /// </summary>
        public UpdateWorkItemBuilder WithCompany(string company)
        {
            AddField(_fieldsConfiguration.CompanyField, company, Operation.Replace);
            return this;
        }


        /// <summary>
        /// Especifica si el WorkItemEntity es requerido.
        /// </summary>
        public UpdateWorkItemBuilder WithRequired(bool required)
        {
            AddField(_fieldsConfiguration.RequiredField, required, Operation.Replace);
            return this;
        }

        /// <summary>
        /// Especifica si el WorkItemEntity es requerido.
        /// </summary>
        public UpdateWorkItemBuilder WithComment(string? comment)
        {
            AddField(_fieldsConfiguration.CommentField, comment, Operation.Add);
            return this;
        }

        /// <summary>
        /// Agrega o actualiza un campo personalizado del WorkItemEntity.
        /// </summary>
        /// <param name="fieldName">Nombre del campo personalizado.</param>
        /// <param name="value">Valor del campo.</param>
        /// <returns>Instancia del builder con el cambio aplicado.</returns>
        /// <exception cref="ArgumentException">Se lanza si el nombre del campo está vacío o nulo.</exception>
        public UpdateWorkItemBuilder WithCustomField(string fieldName, object value)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new ArgumentException("El nombre del campo no puede estar vacío.", nameof(fieldName));

            AddField($"/fields/{fieldName}", value, Operation.Replace);
            return this;
        }



    }
}

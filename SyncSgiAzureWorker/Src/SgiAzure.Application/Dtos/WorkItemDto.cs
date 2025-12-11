using SgiAzure.Application.Interfaces.Dtos;
using SgiAzure.Domain.Entities;
using System.Text.Json.Serialization;

namespace SgiAzure.Application.Dtos
{
    /// <summary>
    /// Data Transfer Object (DTO) que representa un WorkItemEntity en Azure DevOps.
    /// Este DTO facilita la transferencia de datos de un WorkItemEntity entre las capas de la aplicación.
    /// </summary>
    public class WorkItemDto : IWorkItemDto
    {
        /// <summary>
        /// Identificador único del WorkItemEntity en Azure DevOps.
        /// Representa el identificador asignado al WorkItemEntity dentro de la plataforma Azure DevOps.
        /// </summary>
        [JsonPropertyName("workitem_id")]
        public int? WorkItemId { get; set; }

        /// <summary>
        /// Identificador del requerimiento asociado con el WorkItemEntity.
        /// Este identificador se usa para vincular el WorkItemEntity con un requerimiento específico.
        /// </summary>
        [JsonPropertyName("requirement_id")]
        public int? RequirementId { get; set; }

        /// <summary>
        /// Título descriptivo del WorkItemEntity.
        /// Un título breve que describe el propósito o la tarea del WorkItemEntity.
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// Descripción detallada del WorkItemEntity.
        /// Proporciona una explicación más extensa sobre el trabajo que debe realizarse.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Correo o identificador de la persona asignada al WorkItemEntity.
        /// Representa a la persona responsable de ejecutar o supervisar el trabajo.
        /// </summary>
        [JsonPropertyName("assigned_to")]
        public string? AssignedTo { get; set; }

        /// <summary>
        /// Usuario responsable del WorkItemEntity.
        /// Nombre del usuario que se encarga de gestionar o supervisar el trabajo del WorkItemEntity.
        /// </summary>
        [JsonPropertyName("responsible_user")]
        public string ResponsibleUser { get; set; } = string.Empty;

        /// <summary>
        /// Prioridad asignada al WorkItemEntity.
        /// Se utiliza para indicar la importancia del WorkItemEntity, generalmente en un formato numérico o textual.
        /// </summary>
        [JsonPropertyName("priority")]
        public string Priority { get; set; } = "1";

        /// <summary>
        /// Fecha y hora de la creación del WorkItemEntity.
        /// Fecha en la que se creó el WorkItemEntity en Azure DevOps.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Fecha en la que el WorkItemEntity cambió a su estado actual.
        /// Representa el momento en que el WorkItemEntity alcanzó su estado más reciente.
        /// </summary>
        [JsonPropertyName("state_end_date")]
        public DateTime? StateEndDate { get; set; }

        /// <summary>
        /// Fecha final del estado actual del WorkItemEntity.
        /// Es un alias de la propiedad <see cref="StateEndDate"/> y se usa como sinónimo para la fecha en la que finalizó el estado.
        /// </summary>
        [JsonPropertyName("final_status_date")]
        public DateTime? FinalStatusDate { get; set; }

        /// <summary>
        /// Área organizacional o equipo relacionado con el WorkItemEntity.
        /// Describe la unidad organizacional o el área técnica asociada al trabajo.
        /// </summary>
        [JsonPropertyName("area")]
        public string? Area { get; set; }

        /// <summary>
        /// Tiempo estimado en horas para completar el WorkItemEntity.
        /// Indica cuántas horas se estiman para completar el trabajo descrito en el WorkItemEntity.
        /// </summary>
        [JsonPropertyName("scheduled_hours")]
        public string? ScheduledHours { get; set; }

        /// <summary>
        /// Nombre del proyecto asociado al WorkItemEntity.
        /// Representa el proyecto dentro de Azure DevOps al que pertenece el WorkItemEntity.
        /// </summary>
        [JsonPropertyName("project")]
        public string? Project { get; set; }

        /// <summary>
        /// Sistema o área técnica relacionada con el WorkItemEntity.
        /// Describe el sistema o la división técnica en la que se está llevando a cabo el trabajo.
        /// </summary>
        [JsonPropertyName("system")]
        public string? System { get; set; }

        /// <summary>
        /// Tipo de WorkItemEntity.
        /// Define el tipo de WorkItemEntity, por ejemplo, Bug, Task, User Story, etc.
        /// </summary>
        [JsonPropertyName("workitem_type")]
        public string? WorkItemType { get; set; }

        /// <summary>
        /// Fecha de inicio planificada para el WorkItemEntity.
        /// Representa la fecha en la que se tiene previsto iniciar el trabajo.
        /// </summary>
        [JsonPropertyName("start_date")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Fecha objetivo o deadline para el WorkItemEntity.
        /// Define el momento en el que se espera que el trabajo esté completado.
        /// </summary>
        [JsonPropertyName("target_date")]
        public DateTime? TargetDate { get; set; }

        /// <summary>
        /// Empresa asociada al WorkItemEntity.
        /// Representa el nombre de la empresa relacionada con el WorkItemEntity.
        /// </summary>
        [JsonPropertyName("company")]
        public string Company { get; set; } = default!;

        /// <summary>
        /// Usuario que crea el requerimiento.
        /// Es el usuario que origina el trabajo o la tarea asociada con el WorkItemEntity.
        /// </summary>
        [JsonPropertyName("created_by")]
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Tipo de procesamiento del WorkItemEntity.
        /// Describe el tipo de acción o procesamiento que debe llevarse a cabo en el WorkItemEntity.
        /// </summary>
        [JsonPropertyName("processing_type")]
        public string? ProcessingType { get; set; }

        /// <summary>
        /// Tipo de reporte asociado al WorkItemEntity.
        /// Indica el tipo de reporte o resultado que se debe generar a partir del WorkItemEntity.
        /// </summary>
        [JsonPropertyName("report_type")]
        public string ReportType { get; set; } = string.Empty;

        /// <summary>
        /// Convierte el DTO en una entidad de dominio <see cref="WorkItemEntity"/>.
        /// Mapea las propiedades del DTO a los campos correspondientes en la entidad de dominio.
        /// </summary>
        /// <returns>Una nueva instancia de la entidad <see cref="WorkItemEntity"/> con los valores del DTO.</returns>
        public WorkItemEntity ToDomainEntity()
        {
            return new WorkItemEntity()
            {
                Company = Company,
                RequirementId = RequirementId,
                Area = Area,
                ScheduledHours = ScheduledHours,
                AssignedTo = AssignedTo,
                CreatedAt = CreatedAt,
                StateEndDate = StateEndDate,
                Description = Description,
                Priority = Priority,
                Project = Project,
                System = System,
                ResponsibleUser = ResponsibleUser,
                StartDate = StartDate,
                TargetDate = TargetDate,
                Title = Title,
                WorkItemId = WorkItemId,
                WorkItemType = WorkItemType,
                CreatedBy = CreatedBy,
                ProcessingType = ProcessingType,
                ReportType = ReportType,
            };
        }

        public static WorkItemDto FromDomainEntity(WorkItemEntity entity)
        {
            return new WorkItemDto()
            {
                WorkItemId = entity.WorkItemId,
                RequirementId = entity.RequirementId,
                Title = entity.Title,
                Description = entity.Description,
                AssignedTo = entity.AssignedTo,
                ResponsibleUser = entity.ResponsibleUser,
                Priority = entity.Priority,
                CreatedAt = entity.CreatedAt,
                StateEndDate = entity.StateEndDate,
                FinalStatusDate = entity.StateEndDate,
                Area = entity.Area,
                ScheduledHours = entity.ScheduledHours,
                Project = entity.Project,
                System = entity.System,
                WorkItemType = entity.WorkItemType,
                StartDate = entity.StartDate,
                TargetDate = entity.TargetDate,
                Company = entity.Company,
                CreatedBy = entity.CreatedBy,
                ProcessingType = entity.ProcessingType,
                ReportType = entity.ReportType,
            };
        }

    }
}

using ServiceHook.Application.Interfaces.Dto;
using ServiceHook.Domain.Entities;
using System.Text.Json.Serialization;

namespace ServiceHook.Application.Dto
{
    /// <summary>
    /// Data Transfer Object (DTO) que representa un WorkItem en Azure DevOps.
    /// Este DTO facilita la transferencia de datos de un WorkItem entre las capas de la aplicación.
    /// </summary>
    public class WorkItemDto : IWorkItemDto
    {
        /// <summary>
        /// Identificador único del WorkItem en Azure DevOps.
        /// Representa el identificador asignado al WorkItem dentro de la plataforma Azure DevOps.
        /// </summary>
        [JsonPropertyName("workitem_id")]
        public int? WorkItemId { get; set; }

        /// <summary>
        /// Identificador del requerimiento asociado con el WorkItem.
        /// Este identificador se usa para vincular el WorkItem con un requerimiento específico.
        /// </summary>
        [JsonPropertyName("requirement_id")]
        public int? RequerimentId { get; set; }

        /// <summary>
        /// Título descriptivo del WorkItem.
        /// Un título breve que describe el propósito o la tarea del WorkItem.
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// Descripción detallada del WorkItem.
        /// Proporciona una explicación más extensa sobre el trabajo que debe realizarse.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Número de revisión
        /// </summary>
        [JsonPropertyName("System.Rev")]
        public int? SystemRev { get; set; }

        /// <summary>
        /// Fecha en la que se autorizó el workItem
        /// </summary>
        [JsonPropertyName("System.AuthorizedDate")]
        public DateTime? SystemAuthorizedDate { get; set; }

        /// <summary>
        /// Fecha en la que se generó la nueva revisión del WorkItem
        /// </summary>
        [JsonPropertyName("System.RevisedDate")]
        public DateTime? SystemRevisedDate { get; set; }

        /// <summary>
        /// Fecha en la que se realizó un cambio
        /// </summary>
        [JsonPropertyName("System.ChangedDate")]
        public DateTime? SystemChangedDate { get; set; }

        /// <summary>
        /// Marca de agua del WorkItem
        /// </summary>
        [JsonPropertyName("System.Watermark")]
        public int? SystemWatermark { get; set; }   


        /// <summary>
        /// Comentario proveniente del foro de discusión
        /// </summary>
        [JsonPropertyName("comment")]
        public string? Comment { get; set; }

        /// <summary>
        /// Correo o identificador de la persona asignada al WorkItem.
        /// Representa a la persona responsable de ejecutar o supervisar el trabajo.
        /// </summary>
        [JsonPropertyName("assigned_to")]
        public string? AssignedTo { get; set; }

        /// <summary>
        /// Usuario responsable del WorkItem.
        /// Nombre del usuario que se encarga de gestionar o supervisar el trabajo del WorkItem.
        /// </summary>
        [JsonPropertyName("responsible_user")]
        public string? ResponsibleUser { get; set; } = string.Empty;

        /// <summary>
        /// Prioridad asignada al WorkItem.
        /// Se utiliza para indicar la importancia del WorkItem, generalmente en un formato numérico o textual.
        /// </summary>
        [JsonPropertyName("priority")]
        public string? Priority { get; set; } = "1";

        /// <summary>
        /// Fecha y hora de la creación del WorkItem.
        /// Fecha en la que se creó el WorkItem en Azure DevOps.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Fecha en la que el WorkItem cambió a su estado actual.
        /// Representa el momento en que el WorkItem alcanzó su estado más reciente.
        /// </summary>
        [JsonPropertyName("state_end_date")]
        public DateTime? StateEndDate { get; set; }

        /// <summary>
        /// Fecha final del estado actual del WorkItem.
        /// Es un alias de la propiedad <see cref="StateEndDate"/> y se usa como sinónimo para la fecha en la que finalizó el estado.
        /// </summary>
        [JsonPropertyName("final_status_date")]
        public DateTime? FinalStatusDate { get; set; }

        /// <summary>
        /// Área organizacional o equipo relacionado con el WorkItem.
        /// Describe la unidad organizacional o el área técnica asociada al trabajo.
        /// </summary>
        [JsonPropertyName("area")]
        public string? Area { get; set; }

        /// <summary>
        /// Tiempo estimado en horas para completar el WorkItem.
        /// Indica cuántas horas se estiman para completar el trabajo descrito en el WorkItem.
        /// </summary>
        [JsonPropertyName("scheduled_hours")]
        public string? ScheduledHours { get; set; }

        /// <summary>
        /// Nombre del proyecto asociado al WorkItem.
        /// Representa el proyecto dentro de Azure DevOps al que pertenece el WorkItem.
        /// </summary>
        [JsonPropertyName("project")]
        public string? Project { get; set; }

        /// <summary>
        /// Sistema o área técnica relacionada con el WorkItem.
        /// Describe el sistema o la división técnica en la que se está llevando a cabo el trabajo.
        /// </summary>
        [JsonPropertyName("system")]
        public string? System { get; set; }

        /// <summary>
        /// Tipo de WorkItem.
        /// Define el tipo de WorkItem, por ejemplo, Bug, Task, User Story, etc.
        /// </summary>
        [JsonPropertyName("workitem_type")]
        public string? WorkItemType { get; set; }

        /// <summary>
        /// Fecha de inicio planificada para el WorkItem.
        /// Representa la fecha en la que se tiene previsto iniciar el trabajo.
        /// </summary>
        [JsonPropertyName("start_date")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Fecha objetivo o deadline para el WorkItem.
        /// Define el momento en el que se espera que el trabajo esté completado.
        /// </summary>
        [JsonPropertyName("target_date")]
        public DateTime? TargetDate { get; set; }

        /// <summary>
        /// Empresa asociada al WorkItem.
        /// Representa el nombre de la empresa relacionada con el WorkItem.
        /// </summary>
        [JsonPropertyName("company")]
        public string? Company { get; set; }

        /// <summary>
        /// Usuario que crea el requerimiento.
        /// Es el usuario que origina el trabajo o la tarea asociada con el WorkItem.
        /// </summary>
        [JsonPropertyName("created_by")]
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Tipo de procesamiento del WorkItem.
        /// Describe el tipo de acción o procesamiento que debe llevarse a cabo en el WorkItem.
        /// </summary>
        [JsonPropertyName("processing_type")]
        public string? ProcessingType { get; set; }

        /// <summary>
        /// Tipo de reporte asociado al WorkItem.
        /// Indica el tipo de reporte o resultado que se debe generar a partir del WorkItem.
        /// </summary>
        [JsonPropertyName("report_type")]
        public string ReportType { get; set; } = string.Empty;

    }
}

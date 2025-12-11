using SgiAzure.Domain.Interfaces.Entities;

namespace SgiAzure.Domain.Entities
{
    /// <summary>
    /// Representa un WorkItemEntity en Azure DevOps.
    /// Contiene todas las propiedades necesarias para modelar un WorkItemEntity, incluyendo su identificación, detalles, asignaciones, y fechas clave.
    /// </summary>
    public class WorkItemEntity : IWorkItem
    {
        /// <summary>
        /// Identificador único del WorkItemEntity en Azure DevOps.
        /// </summary>
        public int? WorkItemId { get; set; }

        /// <summary>
        /// Número del requerimiento del workItem
        /// </summary>
        public int? RequirementId { get; set; }

        /// <summary>
        /// Titulo descriptivo del WorkItemEntity.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Estado del workItem
        /// </summary>
        public string? State { get; set; }

        /// <summary>
        /// Descripcion detallada del contenido o proposito del WorkItemEntity.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Usuario asignado al WorkItemEntity.
        /// </summary>
        public string? AssignedTo { get; set; }

        /// <summary>
        /// Usuario responsable del WorkItemEntity.
        /// </summary>
        public string ResponsibleUser { get; set; } = default!;

        /// <summary>
        /// Prioridad asignada al WorkItemEntity. Puede ser un valor num�rico o textual.
        /// </summary>
        public string Priority { get; set; } = default!;

        /// <summary>
        /// Fecha y hora en que se creó el WorkItemEntity.
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Fecha en la que el WorkItemEntity cambió a su estado actual.
        /// </summary>
        public DateTime? StateEndDate { get; set; }

        /// <summary>
        /// Fecha de inicio prevista para el WorkItemEntity.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Fecha objetivo para completar el WorkItemEntity.
        /// </summary>
        public DateTime? TargetDate { get; set; }

        /// <summary>
        /// área organizacional o técnica relacionada con el WorkItemEntity.
        /// </summary>
        public string? Area { get; set; }

        /// <summary>
        /// Tiempo programado o estimado para completar el WorkItemEntity, usualmente en horas.
        /// </summary>
        public string? ScheduledHours { get; set; }

        /// <summary>
        /// Nombre del proyecto al que pertenece el WorkItemEntity.
        /// </summary>
        public string? Project { get; set; }

        /// <summary>
        /// Sistema o área técnica relacionado con el WorkItemEntity.
        /// </summary>
        public string? System { get; set; }

        /// <summary>
        /// Tipo de WorkItemEntity, como Bug, Task, User Story, etc.
        /// </summary>
        public string? WorkItemType { get; set; }
        
        /// <summary>
        /// Empresa del workItem
        /// </summary>
        public string? Company { get; set; }

        /// <summary>
        /// Comentario a agregar.
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// Usuario que creó el requerimiento.
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Tipo de Requerimiento reportado Inicialmente
        /// </summary>
        public string ReportType { get; set; } = default!;
        
        /// <summary>
        /// Tipo de requerimiento a procesar en Trámite
        /// </summary>
        public string? ProcessingType { get; set; }
    }
}

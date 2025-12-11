namespace SgiAzure.Application.Interfaces.Dtos
{
    /// <summary>
    /// Interfaz que abstrae los miembros de un WorkItemEntity.
    /// </summary>
    public interface IWorkItemDto
    {
        /// <summary>
        /// Identificador único del WorkItemEntity.
        /// </summary>
        int? WorkItemId { get; set; }

        /// <summary>
        /// Número de requerimiento
        /// </summary>
        public int? RequirementId { get; set; }

        /// <summary>
        /// Título del WorkItemEntity.
        /// </summary>
        string? Title { get; set; }

        /// <summary>
        /// Descripción detallada del WorkItemEntity.
        /// </summary>
        string? Description { get; set; }

        /// <summary>
        /// Usuario asignado al WorkItemEntity.
        /// </summary>
        string? AssignedTo { get; set; }

        /// <summary>
        /// Usuario responsable del WorkItemEntity.
        /// </summary>
        string ResponsibleUser { get; set; }

        /// <summary>
        /// Prioridad del WorkItemEntity.
        /// </summary>
        string Priority { get; set; }

        /// <summary>
        /// Fecha de creación del WorkItemEntity.
        /// </summary>
        DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Fecha en la que el WorkItemEntity cambió a su estado actual.
        /// </summary>
        DateTime? StateEndDate { get; set; }

        /// <summary>
        /// Fecha de inicio de WorkItemEntity
        /// </summary>
        DateTime? StartDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        DateTime? TargetDate { get; set; }

        /// <summary>
        /// Área organizacional relacionada con el WorkItemEntity.
        /// </summary>
        string? Area { get; set; }

        /// <summary>
        /// Horas programadas para el WorkItemEntity.
        /// </summary>
        string? ScheduledHours { get; set; }

        /// <summary>
        /// Proyecto asociado al WorkItemEntity.
        /// </summary>
        string? Project { get; set; }

        /// <summary>
        /// Sistema al cual pertenece el WorkItemEntity.
        /// </summary>
        string? System { get; set; }

        /// <summary>
        /// Empresa del workItem
        /// </summary>
        string Company { get; set; }

        /// <summary>
        /// Tipo de WorkItemEntity.
        /// </summary>
        string? WorkItemType { get; set; }

        /// <summary>
        /// Usuario que creó el requerimiento.
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Tipo de requerimiento seleccionado para procedimiento o Trámite
        /// </summary>
        public string? ProcessingType { get; set; }

        /// <summary>
        /// Tipo de requerimiento reportado inicialmente
        /// </summary>
        public string ReportType { get; set; }
    }
}

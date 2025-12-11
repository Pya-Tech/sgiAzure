namespace ServiceHook.Application.Interfaces.Dto
{
    /// <summary>
    /// Interfaz que abstrae los miembros de un WorkItem.
    /// </summary>
    public interface IWorkItemDto
    {
        /// <summary>
        /// Identificador único del WorkItem.
        /// </summary>
        int? WorkItemId { get; set; }

        /// <summary>
        /// Número de requerimiento
        /// </summary>
        public int? RequerimentId { get; set; }

        /// <summary>
        /// Título del WorkItem.
        /// </summary>
        string? Title { get; set; }

        /// <summary>
        /// Descripción detallada del WorkItem.
        /// </summary>
        string? Description { get; set; }

        /// <summary>
        /// Usuario asignado al WorkItem.
        /// </summary>
        string? AssignedTo { get; set; }

        /// <summary>
        /// Usuario responsable del WorkItem.
        /// </summary>
        string? ResponsibleUser { get; set; }

        /// <summary>
        /// Prioridad del WorkItem.
        /// </summary>
        string? Priority { get; set; }

        /// <summary>
        /// Fecha de creación del WorkItem.
        /// </summary>
        DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Fecha en la que el WorkItem cambió a su estado actual.
        /// </summary>
        DateTime? StateEndDate { get; set; }

        /// <summary>
        /// Fecha de inicio de WorkItem
        /// </summary>
        DateTime? StartDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        DateTime? TargetDate { get; set; }

        /// <summary>
        /// Área organizacional relacionada con el WorkItem.
        /// </summary>
        string? Area { get; set; }

        /// <summary>
        /// Horas programadas para el WorkItem.
        /// </summary>
        string? ScheduledHours { get; set; }

        /// <summary>
        /// Proyecto asociado al WorkItem.
        /// </summary>
        string? Project { get; set; }

        /// <summary>
        /// Sistema al cual pertenece el WorkItem.
        /// </summary>
        string? System { get; set; }

        /// <summary>
        /// Empresa del workItem
        /// </summary>
        string? Company { get; set; }

        /// <summary>
        /// Tipo de WorkItem.
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

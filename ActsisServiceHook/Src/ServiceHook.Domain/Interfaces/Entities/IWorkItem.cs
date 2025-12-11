namespace ServiceHook.Domain.Interfaces.Entities
{
    /// <summary>
    /// Representa un WorkItem en el sistema de gestión, conteniendo información relevante
    /// sobre el trabajo, su estado, y los usuarios asignados o responsables de su seguimiento.
    /// </summary>
    public interface IWorkItem
    {
        /// <summary>
        /// Identificador único del WorkItem.
        /// <para>Este campo es opcional, ya que puede no ser asignado hasta que el WorkItem se cree en el sistema.</para>
        /// </summary>
        int? WorkItemId { get; set; }

        /// <summary>
        /// Número del requerimiento asociado al WorkItem.
        /// <para>Este campo permite identificar el requerimiento específico al que pertenece el WorkItem.</para>
        /// </summary>
        int? RequirementId { get; set; }

        /// <summary>
        /// Tipo de requerimiento reportado inicialmente.
        /// <para>Define el tipo de requerimiento relacionado con el WorkItem, como una incidencia, tarea o historia.</para>
        /// </summary>
        string ReportType { get; set; }

        /// <summary>
        /// Título del WorkItem.
        /// <para>Una breve descripción o título que resume el trabajo o la tarea del WorkItem.</para>
        /// </summary>
        string? Title { get; set; }

        /// <summary>
        /// Descripción detallada del WorkItem.
        /// <para>Proporciona una descripción completa y detallada sobre el propósito y los pasos asociados al WorkItem.</para>
        /// </summary>
        string? Description { get; set; }

        /// <summary>
        /// Usuario asignado al WorkItem.
        /// <para>Este es el usuario que está encargado de trabajar o supervisar el progreso del WorkItem.</para>
        /// </summary>
        string? AssignedTo { get; set; }

        /// <summary>
        /// Usuario responsable del WorkItem.
        /// <para>El responsable es quien tiene la responsabilidad general del WorkItem, a menudo diferente del usuario asignado.</para>
        /// </summary>
        string ResponsibleUser { get; set; }

        /// <summary>
        /// Prioridad del WorkItem.
        /// <para>Indica la prioridad del WorkItem (por ejemplo, baja, media, alta), que ayuda a determinar el orden de atención.</para>
        /// </summary>
        string Priority { get; set; }

        /// <summary>
        /// Fecha de creación del WorkItem.
        /// <para>Marca la fecha y hora en que el WorkItem fue creado en el sistema.</para>
        /// </summary>
        DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Fecha en la que el WorkItem cambió a su estado actual.
        /// <para>Esta fecha refleja la última vez que el WorkItem fue modificado, ya sea por un cambio de estado u otra acción importante.</para>
        /// </summary>
        DateTime? StateEndDate { get; set; }

        /// <summary>
        /// Fecha de inicio del WorkItem.
        /// <para>Indica la fecha en la que comenzó a trabajarse en el WorkItem o cuando se planea que comience.</para>
        /// </summary>
        DateTime? StartDate { get; set; }

        /// <summary>
        /// Fecha objetivo del WorkItem.
        /// <para>Representa la fecha estimada en la que el WorkItem debe completarse o entregarse.</para>
        /// </summary>
        DateTime? TargetDate { get; set; }

        /// <summary>
        /// Área organizacional relacionada con el WorkItem.
        /// <para>Define el área o equipo responsable del WorkItem dentro de la organización.</para>
        /// </summary>
        string? Area { get; set; }

        /// <summary>
        /// Horas programadas para el WorkItem.
        /// <para>Define la cantidad de horas estimadas para completar el trabajo del WorkItem.</para>
        /// </summary>
        string? ScheduledHours { get; set; }

        /// <summary>
        /// Proyecto asociado al WorkItem.
        /// <para>Indica el proyecto en el cual se encuentra el WorkItem, permitiendo una mejor gestión de los trabajos dentro del proyecto.</para>
        /// </summary>
        string? Project { get; set; }

        /// <summary>
        /// Sistema al cual pertenece el WorkItem.
        /// <para>El sistema hace referencia a la plataforma o módulo específico dentro de la organización que está gestionando el WorkItem.</para>
        /// </summary>
        string? System { get; set; }

        /// <summary>
        /// Empresa asociada al WorkItem.
        /// <para>Este campo indica la empresa o entidad que está involucrada o encargada del WorkItem.</para>
        /// </summary>
        string? Company { get; set; }

        /// <summary>
        /// Tipo de WorkItem.
        /// <para>Especifica el tipo de trabajo, como un "Bug", "Task", "Feature", etc., en el contexto de Azure DevOps o el sistema de gestión utilizado.</para>
        /// </summary>
        string? WorkItemType { get; set; }

        /// <summary>
        /// Usuario que creó el requerimiento.
        /// <para>Indica el usuario que originalmente creó el requerimiento que generó este WorkItem.</para>
        /// </summary>
        string? CreatedBy { get; set; }

        /// <summary>
        /// Tipo de requerimiento seleccionado para procedimiento o trámite.
        /// <para>Especifica el tipo de requerimiento basado en un proceso o trámite determinado, útil para gestionar diferentes tipos de procesos internos.</para>
        /// </summary>
        string? ProcessingType { get; set; }
    }
}

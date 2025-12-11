namespace SgiAzure.Domain.Interfaces.Entities
{
    /// <summary>
    /// Representa un WorkItemEntity en el sistema de gestión, conteniendo información relevante
    /// sobre el trabajo, su estado, y los usuarios asignados o responsables de su seguimiento.
    /// </summary>
    public interface IWorkItem
    {
        /// <summary>
        /// Identificador único del WorkItemEntity.
        /// <para>Este campo es opcional, ya que puede no ser asignado hasta que el WorkItemEntity se cree en el sistema.</para>
        /// </summary>
        int? WorkItemId { get; set; }

        /// <summary>
        /// Número del requerimiento asociado al WorkItemEntity.
        /// <para>Este campo permite identificar el requerimiento específico al que pertenece el WorkItemEntity.</para>
        /// </summary>
        int? RequirementId { get; set; }

        /// <summary>
        /// Tipo de requerimiento reportado inicialmente.
        /// <para>Define el tipo de requerimiento relacionado con el WorkItemEntity, como una incidencia, tarea o historia.</para>
        /// </summary>
        string ReportType { get; set; }

        /// <summary>
        /// Título del WorkItemEntity.
        /// <para>Una breve descripción o título que resume el trabajo o la tarea del WorkItemEntity.</para>
        /// </summary>
        string? Title { get; set; }


        /// <summary>
        /// Estado del workItem
        /// </summary>
        string? State { get; set; }

        /// <summary>
        /// Descripción detallada del WorkItemEntity.
        /// <para>Proporciona una descripción completa y detallada sobre el propósito y los pasos asociados al WorkItemEntity.</para>
        /// </summary>
        string? Description { get; set; }

        /// <summary>
        /// Usuario asignado al WorkItemEntity.
        /// <para>Este es el usuario que está encargado de trabajar o supervisar el progreso del WorkItemEntity.</para>
        /// </summary>
        string? AssignedTo { get; set; }

        /// <summary>
        /// Usuario responsable del WorkItemEntity.
        /// <para>El responsable es quien tiene la responsabilidad general del WorkItemEntity, a menudo diferente del usuario asignado.</para>
        /// </summary>
        string ResponsibleUser { get; set; }

        /// <summary>
        /// Prioridad del WorkItemEntity.
        /// <para>Indica la prioridad del WorkItemEntity (por ejemplo, baja, media, alta), que ayuda a determinar el orden de atención.</para>
        /// </summary>
        string Priority { get; set; }

        /// <summary>
        /// Fecha de creación del WorkItemEntity.
        /// <para>Marca la fecha y hora en que el WorkItemEntity fue creado en el sistema.</para>
        /// </summary>
        DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Fecha en la que el WorkItemEntity cambió a su estado actual.
        /// <para>Esta fecha refleja la última vez que el WorkItemEntity fue modificado, ya sea por un cambio de estado u otra acción importante.</para>
        /// </summary>
        DateTime? StateEndDate { get; set; }

        /// <summary>
        /// Fecha de inicio del WorkItemEntity.
        /// <para>Indica la fecha en la que comenzó a trabajarse en el WorkItemEntity o cuando se planea que comience.</para>
        /// </summary>
        DateTime? StartDate { get; set; }

        /// <summary>
        /// Fecha objetivo del WorkItemEntity.
        /// <para>Representa la fecha estimada en la que el WorkItemEntity debe completarse o entregarse.</para>
        /// </summary>
        DateTime? TargetDate { get; set; }

        /// <summary>
        /// Área organizacional relacionada con el WorkItemEntity.
        /// <para>Define el área o equipo responsable del WorkItemEntity dentro de la organización.</para>
        /// </summary>
        string? Area { get; set; }

        /// <summary>
        /// Horas programadas para el WorkItemEntity.
        /// <para>Define la cantidad de horas estimadas para completar el trabajo del WorkItemEntity.</para>
        /// </summary>
        string? ScheduledHours { get; set; }

        /// <summary>
        /// Proyecto asociado al WorkItemEntity.
        /// <para>Indica el proyecto en el cual se encuentra el WorkItemEntity, permitiendo una mejor gestión de los trabajos dentro del proyecto.</para>
        /// </summary>
        string? Project { get; set; }

        /// <summary>
        /// Sistema al cual pertenece el WorkItemEntity.
        /// <para>El sistema hace referencia a la plataforma o módulo específico dentro de la organización que está gestionando el WorkItemEntity.</para>
        /// </summary>
        string? System { get; set; }

        /// <summary>
        /// Empresa asociada al WorkItemEntity.
        /// <para>Este campo indica la empresa o entidad que está involucrada o encargada del WorkItemEntity.</para>
        /// </summary>
        string? Company { get; set; }

        /// <summary>
        /// Comentario del workItem
        /// </summary>
        string? Comment { get; set;}

        /// <summary>
        /// Tipo de WorkItemEntity.
        /// <para>Especifica el tipo de trabajo, como un "Bug", "Task", "Feature", etc., en el contexto de Azure DevOps o el sistema de gestión utilizado.</para>
        /// </summary>
        string? WorkItemType { get; set; }

        /// <summary>
        /// Usuario que creó el requerimiento.
        /// <para>Indica el usuario que originalmente creó el requerimiento que generó este WorkItemEntity.</para>
        /// </summary>
        string? CreatedBy { get; set; }

        /// <summary>
        /// Tipo de requerimiento seleccionado para procedimiento o trámite.
        /// <para>Especifica el tipo de requerimiento basado en un proceso o trámite determinado, útil para gestionar diferentes tipos de procesos internos.</para>
        /// </summary>
        string? ProcessingType { get; set; }
    }
}

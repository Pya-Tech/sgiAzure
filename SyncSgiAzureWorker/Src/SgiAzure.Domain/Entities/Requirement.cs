using SgiAzure.Domain.Interfaces.Entities;

namespace SgiAzure.Domain.Entities
{
    /// <summary>
    /// Clase encargada de abstraer los miembros de un Modelo Requirement.
    /// Representa un requerimiento en el sistema, almacenando detalles importantes como estado, usuario responsable, fechas, entre otros.
    /// </summary>
    public class Requirement : IRequirement
    {
        /// <summary>
        /// Identificador único del requerimiento.
        /// </summary>
        public int RequirementId { get; set; }

        /// <summary>
        /// Estado del requerimiento (ej. 'Nuevo', 'En Proceso', 'Cerrado').
        /// </summary>
        public string Status { get; set; } = default!;

        /// <summary>
        /// Usuario que creó el requerimiento.
        /// </summary>
        public string CreatedBy { get; set; } = default!;

        /// <summary>
        /// Fecha y hora de la creación del requerimiento.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Comentario asociado al reporte del requerimiento.
        /// </summary>
        public string ReportedComment { get; set; } = default!;

        /// <summary>
        /// Descripción del error, si aplica.
        /// </summary>
        public string? ErrorDescription { get; set; }

        /// <summary>
        /// Sistema al cual pertenece el requerimiento.
        /// </summary>
        public string System { get; set; } = default!;

        /// <summary>
        /// Programa relacionado con el requerimiento, si aplica.
        /// </summary>
        public string? Program { get; set; }

        /// <summary>
        /// Identificador del requerimiento relacionado, si existe.
        /// </summary>
        public long? RelatedRequirementId { get; set; }

        /// <summary>
        /// Tipo de solicitud del requerimiento.
        /// </summary>
        public string? ProcessRequirementType { get; set; }

        /// <summary>
        /// Horas programadas para la ejecución del requerimiento.
        /// </summary>
        public decimal? ScheduledHours { get; set; }

        /// <summary>
        /// Fecha programada para la ejecución del requerimiento.
        /// </summary>
        public DateTime? ScheduledDate { get; set; }

        /// <summary>
        /// Fecha ajustada para la ejecución del requerimiento, si aplica.
        /// </summary>
        public DateTime? AdjustedDate { get; set; }

        /// <summary>
        /// Usuario asignado para responder el requerimiento.
        /// </summary>
        public string? ResponseByUser { get; set; }

        /// <summary>
        /// Horas reales invertidas en el requerimiento.
        /// </summary>
        public decimal? ActualHours { get; set; }

        /// <summary>
        /// Tipo oficial del requerimiento, si aplica.
        /// </summary>
        public string? OfficialRequirementType { get; set; }

        /// <summary>
        /// Número de horas de trabajo por día asignadas al requerimiento.
        /// </summary>
        public decimal? HoursPerDay { get; set; }

        /// <summary>
        /// Fecha de inicio del requerimiento.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Nivel de prioridad del requerimiento.
        /// </summary>
        public int? Priority { get; set; }

        /// <summary>
        /// Nivel de satisfacción general del requerimiento, si aplica.
        /// </summary>
        public int? SatisfactionLevel { get; set; }

        /// <summary>
        /// Nivel de satisfacción técnica del requerimiento, si aplica.
        /// </summary>
        public int? TechnicalSatisfactionLevel { get; set; }

        /// <summary>
        /// Nivel de satisfacción con el servicio del requerimiento, si aplica.
        /// </summary>
        public int? ServiceSatisfactionLevel { get; set; }

        /// <summary>
        /// Nivel de satisfacción con el tiempo del requerimiento, si aplica.
        /// </summary>
        public int? TimeSatisfactionLevel { get; set; }

        /// <summary>
        /// Tipo de requerimiento reportado, si aplica.
        /// </summary>
        public string ReportedRequirementType { get; set; } = default!;

        /// <summary>
        /// Empresa asociada al requerimiento.
        /// </summary>
        public string? Company { get; set; }

        /// <summary>
        /// Proyecto relacionado con el requerimiento.
        /// </summary>
        public string? Project { get; set; }

        /// <summary>
        /// Módulo relacionado con el requerimiento.
        /// </summary>
        public string? Module { get; set; }

        /// <summary>
        /// Indica si el requerimiento ha sido desplazado.
        /// </summary>
        public string? IsDisplaced { get; set; }

        /// <summary>
        /// Indica si el requerimiento ha sido reprogramado.
        /// </summary>
        public string? IsReprogrammed { get; set; }

        /// <summary>
        /// Indica si se permite la programación del requerimiento en días festivos.
        /// </summary>
        public string? AllowsHolidayScheduling { get; set; }

        /// <summary>
        /// Fecha inicial programada para el requerimiento.
        /// </summary>
        public DateTime? InitialScheduledDate { get; set; }

        /// <summary>
        /// Etapa actual del requerimiento.
        /// </summary>
        public string? Stage { get; set; }

        /// <summary>
        /// Usuario que programó el requerimiento.
        /// </summary>
        public string? ProgrammedByUser { get; set; }

        /// <summary>
        /// Usuario responsable de ejecutar o resolver el requerimiento.
        /// </summary>
        public string? ResponsibleUser { get; set; }

        /// <summary>
        /// Comentario adicional relacionado al requerimiento.
        /// </summary>
        public string? AdditionalComment { get; set; }

        /// <summary>
        /// Horas iniciales programadas para la ejecución del requerimiento.
        /// </summary>
        public decimal? InitialScheduledHours { get; set; }

        /// <summary>
        /// Indica si el incidente relacionado con el requerimiento ha sido reportado.
        /// </summary>
        public string? IsIncidentReported { get; set; } = "N";

        /// <summary>
        /// Indica si el incidente relacionado con el requerimiento ha sido resuelto.
        /// </summary>
        public string? IsIncidentResolved { get; set; } = "N";

        /// <summary>
        /// Tipo de incidente relacionado con el requerimiento.
        /// </summary>
        public int? IncidentType { get; set; }

        /// <summary>
        /// Observación relacionada con el incidente del requerimiento.
        /// </summary>
        public string? IncidentObservation { get; set; }

        /// <summary>
        /// Identificador único de corrección asociada al requerimiento.
        /// </summary>
        public string? CorrectionId { get; set; }

        /// <summary>
        /// Orden de prioridad o de ejecución del requerimiento.
        /// </summary>
        public int? Order { get; set; }

        /// <summary>
        /// Identificador de la categoría del requerimiento.
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Identificador de la categoría de respuesta al requerimiento.
        /// </summary>
        public int? CategoryIdResponse { get; set; }

        /// <summary>
        /// Fecha de entrega del requerimiento.
        /// </summary>
        public DateTime? DeliveryDate { get; set; }

        /// <summary>
        /// Fecha de finalización del requerimiento.
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Horas adicionales requeridas para completar el requerimiento.
        /// </summary>
        public decimal? AdditionalHours { get; set; }

        /// <summary>
        /// Nivel de impacto del requerimiento.
        /// </summary>
        public int? ImpactLevel { get; set; }


        /// <summary>
        /// Tipo de solicitud relacionado al requerimiento.
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        /// Nivel de urgencia del requerimiento.
        /// </summary>
        public int? UrgencyLevel { get; set; }

        /// <summary>
        /// Periodo de validez del requerimiento, si aplica.
        /// </summary>
        public int? ValidityPeriod { get; set; }

        /// <summary>
        /// Identificador de la opción asociada al requerimiento.
        /// </summary>
        public long? OptionId { get; set; }

        /// <summary>
        /// Código de la empresa asociada al requerimiento.
        /// </summary>
        public int? CompanyCode { get; set; }

        /// <summary>
        /// Fecha en la que se registró el estado final del requerimiento.
        /// </summary>
        public DateTime FinalStatusDate { get; set; }

        /// <summary>
        /// Horas extras requeridas para completar el requerimiento.
        /// </summary>
        public decimal? OvertimeHours { get; set; }

        /// <summary>
        /// Comentario sobre la satisfacción técnica del requerimiento, si aplica.
        /// </summary>
        public string? TechnicalSatisfactionComment { get; set; }

        /// <summary>
        /// Comentario sobre la satisfacción con el servicio del requerimiento, si aplica.
        /// </summary>
        public string? ServiceSatisfactionComment { get; set; }

        /// <summary>
        /// Comentario sobre la satisfacción con el tiempo del requerimiento, si aplica.
        /// </summary>
        public string? TimeSatisfactionComment { get; set; }

        /// <summary>
        /// Tipo de presentación asociada al requerimiento.
        /// </summary>
        public string? PptType { get; set; }

        /// <summary>
        /// Área asociada al requerimiento, si aplica.
        /// </summary>
        public string? Area { get; set; }

        /// <summary>
        /// Subárea asociada al requerimiento, si aplica.
        /// </summary>
        public string? SubArea { get; set; }

        /// <summary>
        /// Tipo de requerimiento según el cliente, si aplica.
        /// </summary>
        public string? RequerimientTypeClient { get; set; }

        /// <summary>
        /// Tema relacionado con el requerimiento, si aplica.
        /// </summary>
        public string? Topic { get; set; }
        /// <summary>
        /// Representa la fase actual del proyecto. Se utiliza para indicar en qué etapa o fase del ciclo de vida se encuentra el proyecto.
        /// </summary>
        public string? ProjectStage { get; set; }

        /// <summary>
        /// Representa el contrato asociado al proyecto, si corresponde. Esta propiedad puede ser nula si el contrato no está disponible o no aplica.
        /// </summary>
        public string? Contract { get; set; }

        /// <summary>
        /// Representa un proyecto nuevo asociado al registro actual. Puede usarse para hacer referencia a una nueva instancia de un proyecto o una variante.
        /// Esta propiedad puede ser nula si no aplica o si no se ha asociado un proyecto nuevo.
        /// </summary>
        public string? ProjectNew { get; set; }

        /// <summary>
        /// Representa el sistema origen que crea el requerimiento
        /// </summary>
        public string? Origin { get; set; }
    }
}

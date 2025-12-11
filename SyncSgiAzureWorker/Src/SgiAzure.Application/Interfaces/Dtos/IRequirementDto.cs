using SgiAzure.Domain.Entities;

namespace SgiAzure.Application.Interfaces.Dtos
{
    /// <summary>
    /// Interface que define los miembros de un modelo de requerimiento, representando los datos y características principales de un requerimiento.
    /// </summary>
    public interface IRequirementDto
    {
        /// <summary>
        /// Número único de identificación del requerimiento.
        /// </summary>
        int RequirementId { get; set; }

        /// <summary>
        /// Estado actual del requerimiento, como "Abierto", "En proceso", o "Cerrado".
        /// </summary>
        string State { get; set; }

        /// <summary>
        /// Usuario que ha creado el requerimiento.
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Fecha y hora en que se creó el requerimiento.
        /// </summary>
        DateTime CreatedAt { get; set; }

        /// <summary>
        /// Descripción detallada del requerimiento.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Comentarios del requerimiento
        /// </summary>
        string? Comments { get; set; }

        /// <summary>
        /// Sistema o aplicación al cual está asociado el requerimiento.
        /// </summary>
        string System { get; set; }

        /// <summary>
        /// Tipo de trámite asociado al requerimiento, como incidente, solicitud, etc.
        /// </summary>
        string? ProcessingType { get; set; }

        /// <summary>
        /// Número de horas programadas para completar el requerimiento.
        /// </summary>
        string? ScheduledHours { get; set; }

        /// <summary>
        /// Fecha límite o de entrega programada para el requerimiento.
        /// </summary>
        DateTime? TargetDate { get; set; }

        /// <summary>
        /// Usuario encargado de responder al requerimiento.
        /// </summary>
        string? ResponseUser { get; set; }

        /// <summary>
        /// Número de horas reales invertidas en el requerimiento.
        /// </summary>
        string? ActualHours { get; set; }

        /// <summary>
        /// Tipo de respuesta asignada al requerimiento, como "Solución", "Escalado", etc.
        /// </summary>
        string? ResponseType { get; set; }

        /// <summary>
        /// Nivel de prioridad del requerimiento.
        /// </summary>
        int? Priority { get; set; }

        /// <summary>
        /// Nivel general de satisfacción del cliente o usuario.
        /// </summary>
        int? Satisfaction { get; set; }

        /// <summary>
        /// Nivel de satisfacción técnica respecto a la solución del requerimiento.
        /// </summary>
        int? TechnicalSatisfaction { get; set; }

        /// <summary>
        /// Nivel de satisfacción respecto al servicio brindado en la gestión del requerimiento.
        /// </summary>
        int? ServiceSatisfaction { get; set; }

        /// <summary>
        /// Nivel de satisfacción respecto al tiempo de respuesta del requerimiento.
        /// </summary>
        int? TimeSatisfaction { get; set; }

        /// <summary>
        /// Tipo de reporte que originó el requerimiento, como "Usuario", "Sistema", etc.
        /// </summary>
        string ReportType { get; set; }

        /// <summary>
        /// Compañía o cliente asociado al requerimiento.
        /// </summary>
        string Company { get; set; }

        /// <summary>
        /// Proyecto específico al cual está vinculado el requerimiento.
        /// </summary>
        string? Project { get; set; }

        /// <summary>
        /// Módulo o componente específico relacionado con el requerimiento.
        /// </summary>
        string? Module { get; set; }

        /// <summary>
        /// Fecha inicial programada para iniciar el trabajo en el requerimiento.
        /// </summary>
        DateTime? InitialScheduledDate { get; set; }

        /// <summary>
        /// Fecha de inicio para comenzar con el trámite del requerimiento
        /// </summary>
        DateTime? StartDate { get; set; }

        /// <summary>
        /// Usuario asignado para programar y coordinar la gestión del requerimiento.
        /// </summary>
        string? ScheduledUser { get; set; }

        /// <summary>
        /// Usuario responsable de llevar a cabo el requerimiento.
        /// </summary>
        string ResponsibleUser { get; set; }

        /// <summary>
        /// Fecha en la que el requerimiento alcanzó su estado final.
        /// </summary>
        DateTime? StateEndDate { get; set; }

        /// <summary>
        /// Horas extras dedicadas al requerimiento, si las hubiera.
        /// </summary>
        string? ExtraHours { get; set; }

        /// <summary>
        /// Área organizacional que reporta el requerimiento.
        /// </summary>
        string? Area { get; set; }

        /// <summary>
        /// Sub-área dentro de la organización que reporta el requerimiento.
        /// </summary>
        string? SubArea { get; set; }

        /// <summary>
        /// Tema o asunto principal relacionado con el requerimiento.
        /// </summary>
        string? Topic { get; set; }

        /// <summary>
        /// Sistema origen que genera el mensaje
        /// </summary>
        string? Origin { get; set; }

        /// <summary>
        /// Usuario que genera el mensaje
        /// </summary>
        string? User { get; set; }

        /// <summary>
        /// Método encargado de mapear
        /// </summary>
        /// <returns></returns>
        Requirement ToDomainEntity();

    }
}

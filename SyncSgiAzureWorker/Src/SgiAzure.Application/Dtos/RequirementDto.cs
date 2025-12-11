using SgiAzure.Application.Interfaces.Dtos;
using SgiAzure.Domain.Entities;
using System.Text.Json.Serialization;

namespace SgiAzure.Application.Dtos
{
    /// <summary>
    /// Clase encargada de abstraer los miembros de un Modelo Requirement.
    /// Representa un requerimiento en el sistema, almacenando detalles importantes como estado, usuario responsable, fechas, entre otros.
    /// </summary>
    public partial class RequirementDto : IRequirementDto
    {
        /// <summary>
        /// Número único del requerimiento.
        /// </summary>
        [JsonPropertyName("numero_requerimiento")]
        public int RequirementId { get; set; }

        /// <summary>
        /// Estado actual del requerimiento, puede ser "Pendiente", "En Proceso", "Cerrado", etc.
        /// </summary>
        [JsonPropertyName("estado")]
        public string State { get; set; } = default!;

        /// <summary>
        /// Nombre del usuario que creó el requerimiento.
        /// </summary>
        [JsonPropertyName("user_reporta")]
        public string CreatedBy { get; set; } = default!;

        /// <summary>
        /// Fecha y hora en la que se creó el requerimiento.
        /// </summary>
        [JsonPropertyName("fecha_reporta")]
        public DateTime CreatedAt { get; set; } = default!;

        /// <summary>
        /// Descripción detallada del requerimiento.
        /// </summary>
        [JsonPropertyName("comentario_reporta")]
        public string Description { get; set; } = default!;

        /// <summary>
        /// Sistema o módulo relacionado con el requerimiento.
        /// </summary>
        [JsonPropertyName("sistema")]
        public string System { get; set; } = default!;

        /// <summary>
        /// Tipo de trámite asociado al requerimiento, puede ser null.
        /// </summary>
        [JsonPropertyName("tipo_tramite")]
        public string? ProcessingType { get; set; }

        /// <summary>
        /// Horas programadas para completar el requerimiento, puede ser null.
        /// </summary>
        [JsonPropertyName("horas_programadas")]
        public string? ScheduledHours { get; set; }

        /// <summary>
        /// Fecha límite programada para el requerimiento, puede ser null.
        /// </summary>
        [JsonPropertyName("fecha_programada")]
        public DateTime? TargetDate { get; set; }

        /// <summary>
        /// Usuario encargado de responder al requerimiento, puede ser null.
        /// </summary>
        [JsonPropertyName("user_respuesta")]
        public string? ResponseUser { get; set; }

        /// <summary>
        /// Horas reales dedicadas al requerimiento, puede ser null.
        /// </summary>
        [JsonPropertyName("horas_reales")]
        public string? ActualHours { get; set; }

        /// <summary>
        /// Tipo de respuesta asociado al requerimiento, puede ser null.
        /// </summary>
        [JsonPropertyName("tipo_respuesta")]
        public string? ResponseType { get; set; }

        /// <summary>
        /// Nivel de prioridad del requerimiento, puede ser null.
        /// </summary>
        [JsonPropertyName("prioridad")]
        public int? Priority { get; set; }

        /// <summary>
        /// Nivel de satisfacción general del cliente con respecto al requerimiento, puede ser null.
        /// </summary>
        [JsonPropertyName("satisfaccion")]
        public int? Satisfaction { get; set; }

        /// <summary>
        /// Nivel de satisfacción técnica, puede ser null.
        /// </summary>
        [JsonPropertyName("sat_tecnica")]
        public int? TechnicalSatisfaction { get; set; }

        /// <summary>
        /// Nivel de satisfacción con el servicio brindado, puede ser null.
        /// </summary>
        [JsonPropertyName("sat_servicio")]
        public int? ServiceSatisfaction { get; set; }

        /// <summary>
        /// Nivel de satisfacción respecto al tiempo de respuesta, puede ser null.
        /// </summary>
        [JsonPropertyName("sat_tiempo")]
        public int? TimeSatisfaction { get; set; }

        /// <summary>
        /// Tipo de reporte que originó el requerimiento.
        /// </summary>
        [JsonPropertyName("tipo_reporta")]
        public string ReportType { get; set; } = default!;

        /// <summary>
        /// Empresa o cliente asociado al requerimiento, puede ser null.
        /// </summary>
        [JsonPropertyName("empresa")]
        public string Company { get; set; } = string.Empty;

        /// <summary>
        /// Proyecto relacionado con el requerimiento, puede ser null.
        /// </summary>
        [JsonPropertyName("proyecto")]
        public string? Project { get; set; }

        /// <summary>
        /// Módulo asociado al requerimiento, puede ser null.
        /// </summary>
        [JsonPropertyName("modulo")]
        public string? Module { get; set; }

        /// <summary>
        /// Fecha inicial programada para iniciar el requerimiento, puede ser null.
        /// </summary>
        [JsonPropertyName("fecha_programada_ini")]
        public DateTime? InitialScheduledDate { get; set; }

        /// <summary>
        /// Usuario encargado de programar el requerimiento, puede ser null.
        /// </summary>
        [JsonPropertyName("user_programado")]
        public string? ScheduledUser { get; set; }

        /// <summary>
        /// Usuario responsable actual del requerimiento.
        /// </summary>
        [JsonPropertyName("user_responsable")]
        public string? ResponsibleUser { get; set; } = default!;

        /// <summary>
        /// Fecha en la que el requerimiento cambió a su estado actual.
        /// </summary>
        [JsonPropertyName("fecha_fin_estado")]
        public DateTime? StateEndDate { get; set; }

        /// <summary>
        /// Horas adicionales dedicadas al requerimiento, puede ser null.
        /// </summary>
        [JsonPropertyName("horas_extras")]
        public string? ExtraHours { get; set; }

        /// <summary>
        /// Área organizacional relacionada con el requerimiento, puede ser null.
        /// </summary>
        [JsonPropertyName("area")]
        public string? Area { get; set; }

        /// <summary>
        /// Sub-área relacionada con el requerimiento, puede ser null.
        /// </summary>
        [JsonPropertyName("sub_area")]
        public string? SubArea { get; set; }

        /// <summary>
        /// Tema principal del requerimiento, puede ser null.
        /// </summary>
        [JsonPropertyName("tema")]
        public string? Topic { get; set; }

        /// <summary>
        /// Comentarios asociados a los cambios del requerimiento
        /// </summary>
        [JsonPropertyName("comentarios")]
        public string? Comments { get; set; }

        /// <summary>
        /// Fecha para iniciar desarrollo según lo programado.
        /// </summary>
        [JsonPropertyName("fecha_inicio")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Sistema origen que genera el mensaje
        /// </summary>
        [JsonPropertyName("origen")] 
        public string? Origin { get; set; }

        /// <summary>
        /// Usuario autenticado que crea el mensaje
        /// </summary>
        [JsonPropertyName("user")]
        public string? User { get; set; }

        public static RequirementDto FromDomainEntity(Requirement requirement)
        {
            return new RequirementDto
            {
                RequirementId = requirement.RequirementId,
                State = requirement.Status,
                CreatedBy = requirement.CreatedBy,
                CreatedAt = requirement.CreatedAt,
                Description = requirement.ReportedComment,
                Comments = requirement.AdditionalComment,
                System = requirement.System,
                ProcessingType = requirement.ProcessRequirementType,
                ScheduledHours = requirement.ScheduledHours?.ToString(),
                StartDate = requirement.StartDate,
                TargetDate = requirement.ScheduledDate,
                ResponseUser = requirement.ResponseByUser,
                ActualHours = requirement.ActualHours?.ToString(),
                ResponseType = requirement.OfficialRequirementType,
                Priority = requirement.Priority,
                Satisfaction = requirement.SatisfactionLevel,
                TechnicalSatisfaction = requirement.TechnicalSatisfactionLevel,
                ServiceSatisfaction = requirement.ServiceSatisfactionLevel,
                TimeSatisfaction = requirement.TimeSatisfactionLevel,
                ReportType = requirement.ReportedRequirementType,
                Company = requirement.Company ?? string.Empty,
                Project = requirement.Project,
                Module = requirement.Module,
                InitialScheduledDate = requirement.InitialScheduledDate,
                ScheduledUser = requirement.ProgrammedByUser,
                ResponsibleUser = requirement.ResponsibleUser,
                StateEndDate = requirement.EndDate,
                ExtraHours = requirement.AdditionalHours?.ToString(),
                Area = requirement.Area,
                SubArea = requirement.SubArea,
                Topic = requirement.Topic
            };
        }

        /// <summary>
        /// Convierte el DTO en una entidad de dominio `Requirement`.
        /// </summary>
        /// <returns>Instancia de Requirement con valores del DTO.</returns>
        public Requirement ToDomainEntity()
        {
            return new Requirement
            {
                RequirementId = RequirementId,
                Status = State,
                CreatedBy = CreatedBy,
                CreatedAt = CreatedAt,
                StartDate = StartDate,
                AdditionalComment = Comments,
                ReportedComment = Description,
                System = System,
                OfficialRequirementType = ResponseType,
                ScheduledHours = decimal.TryParse(ScheduledHours, out var scheduledHours) ? (decimal?)scheduledHours : null,
                ScheduledDate = TargetDate,
                ResponseByUser = ResponseUser,
                ActualHours = decimal.TryParse(ActualHours, out var actualHours) ? (decimal?)actualHours : null,
                ProcessRequirementType = ResponseType,
                Priority = Priority,
                SatisfactionLevel = Satisfaction,
                TechnicalSatisfactionLevel = TechnicalSatisfaction,
                ServiceSatisfactionLevel = ServiceSatisfaction,
                TimeSatisfactionLevel = TimeSatisfaction,
                ReportedRequirementType = ReportType,
                Company = Company,
                Project = Project,
                Module = Module,
                InitialScheduledDate = InitialScheduledDate,
                ProgrammedByUser = ScheduledUser,
                ResponsibleUser = ResponsibleUser,
                EndDate = StateEndDate,
                AdditionalHours = decimal.TryParse(ExtraHours, out var extraHours) ? (decimal?)extraHours : null,
                Area = Area,
                SubArea = SubArea,
                Topic = Topic
            };
        }


        /// <summary>
        /// Sobrescribe el método ToString para mostrar todas las propiedades del requerimiento.
        /// </summary>
        /// <returns>String con todas las propiedades del objeto</returns>
        public override string ToString()
        {
            return $"RequirementId: {RequirementId}, " +
                   $"State: {State}, " +
                   $"CreatedBy: {CreatedBy}, " +
                   $"CreatedAt: {CreatedAt}, " +
                   $"Description: {Description}, " +
                   $"Comments: {Comments}, " +
                   $"System: {System}, " +
                   $"RequirementType: {ResponseType}, " +
                   $"ProcessType: {ProcessingType}, " +
                   $"ScheduledHours: {ScheduledHours}, " +
                   $"TargetDate: {TargetDate}, " +
                   $"ResponseUser: {ResponseUser}, " +
                   $"ActualHours: {ActualHours}, " +
                   $"ResponseType: {ResponseType}, " +
                   $"Priority: {Priority}, " +
                   $"Satisfaction: {Satisfaction}, " +
                   $"TechnicalSatisfaction: {TechnicalSatisfaction}, " +
                   $"ServiceSatisfaction: {ServiceSatisfaction}, " +
                   $"TimeSatisfaction: {TimeSatisfaction}, " +
                   $"ReportType: {ReportType}, " +
                   $"Company: {Company}, " +
                   $"Project: {Project}, " +
                   $"Module: {Module}, " +
                   $"InitialScheduledDate: {InitialScheduledDate}, " +
                   $"ScheduledUser: {ScheduledUser}, " +
                   $"ResponsibleUser: {ResponsibleUser}, " +
                   $"StateEndDate: {StateEndDate}, " +
                   $"ExtraHours: {ExtraHours}, " +
                   $"Area: {Area}, " +
                   $"SubArea: {SubArea}, " +
                   $"Topic: {Topic}";
        }
    }
}

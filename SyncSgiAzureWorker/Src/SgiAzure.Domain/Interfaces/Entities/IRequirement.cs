namespace SgiAzure.Domain.Interfaces.Entities
{
    /// <summary>
    /// Interface que define los miembros de un modelo de requerimiento, representando los datos y características principales de un requerimiento.
    /// </summary>
    public interface IRequirement
    {
        /// <summary>
        /// Identificador único del requerimiento. (Campo: NUMERO_REQUERIMIENTO)
        /// </summary>
        int RequirementId { get; set; }

        /// <summary>
        /// Estado del requerimiento. (Campo: ESTADO)
        /// </summary>
        string Status { get; set; }

        /// <summary>
        /// Usuario que creó el requerimiento. (Campo: USER_REPORTA)
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Fecha de creación del requerimiento. (Campo: FECHA_REPORTA)
        /// </summary>
        DateTime CreatedAt { get; set; }

        /// <summary>
        /// Comentarios proporcionados por quien reporta el requerimiento. (Campo: COMENTARIO_REPORTA)
        /// </summary>
        string ReportedComment { get; set; }

        /// <summary>
        /// Descripción de error asociado al requerimiento. (Campo: ERROR)
        /// </summary>
        string? ErrorDescription { get; set; }

        /// <summary>
        /// Sistema relacionado con el requerimiento. (Campo: SISTEMA)
        /// </summary>
        string System { get; set; }

        /// <summary>
        /// Programa o proyecto asociado al requerimiento. (Campo: PROGRAMA)
        /// </summary>
        string? Program { get; set; }

        /// <summary>
        /// Número de un requerimiento relacionado, si aplica. (Campo: REQUERIMIENTO_RELACIONADO)
        /// </summary>
        long? RelatedRequirementId { get; set; }

        /// <summary>
        /// Tipo de requerimiento en trámite. (Campo: TIPO_TRAMITE)
        /// </summary>
        string? ProcessRequirementType { get; set; }

        /// <summary>
        /// Horas programadas para el requerimiento. (Campo: HORAS_PROGRAMADAS)
        /// </summary>
        decimal? ScheduledHours { get; set; }

        /// <summary>
        /// Fecha programada para la ejecución del requerimiento. (Campo: FECHA_PROGRAMADA)
        /// </summary>
        DateTime? ScheduledDate { get; set; }

        /// <summary>
        /// Fecha ajustada para la ejecución del requerimiento. (Campo: FECHA_AJUSTADA)
        /// </summary>
        DateTime? AdjustedDate { get; set; }

        /// <summary>
        /// Usuario que dará respuesta al requerimiento. (Campo: USER_RESPONDERA)
        /// </summary>
        string? ResponseByUser { get; set; }

        /// <summary>
        /// Horas reales utilizadas para resolver el requerimiento. (Campo: HORAS_REALES)
        /// </summary>
        decimal? ActualHours { get; set; }

        /// <summary>
        /// Tipo de respuesta al requerimiento. (Campo: TIPO_RESPUESTA)
        /// </summary>
        string? OfficialRequirementType { get; set; }

        /// <summary>
        /// Horas por día estimadas para completar el requerimiento. (Campo: HORAS_POR_DIA)
        /// </summary>
        decimal? HoursPerDay { get; set; }

        /// <summary>
        /// Fecha de inicio del requerimiento. (Campo: FECHA_INICIO)
        /// </summary>
        DateTime? StartDate { get; set; }

        /// <summary>
        /// Prioridad del requerimiento. (Campo: PRIORIDAD)
        /// </summary>
        int? Priority { get; set; }

        /// <summary>
        /// Nivel de satisfacción con el requerimiento. (Campo: NIVEL_SATISFACCION)
        /// </summary>
        int? SatisfactionLevel { get; set; }

        /// <summary>
        /// Nivel de satisfacción técnica con el requerimiento. (Campo: NIVEL_SATISFACCION_TECNICA)
        /// </summary>
        int? TechnicalSatisfactionLevel { get; set; }

        /// <summary>
        /// Nivel de satisfacción con el servicio proporcionado. (Campo: NIVEL_SATISFACCION_SERVICIO)
        /// </summary>
        int? ServiceSatisfactionLevel { get; set; }

        /// <summary>
        /// Nivel de satisfacción con el tiempo de respuesta. (Campo: NIVEL_SATISFACCION_TIEMPO)
        /// </summary>
        int? TimeSatisfactionLevel { get; set; }

        /// <summary>
        /// Tipo de quien reporta el requerimiento. (Campo: TIPO_REPORTA)
        /// </summary>
        string ReportedRequirementType { get; set; }

        /// <summary>
        /// Nombre de la empresa que reporta el requerimiento. (Campo: EMPRESA)
        /// </summary>
        string? Company { get; set; }

        /// <summary>
        /// Nombre del proyecto al que está relacionado el requerimiento. (Campo: PROYECTO)
        /// </summary>
        string? Project { get; set; }

        /// <summary>
        /// Módulo relacionado al requerimiento. (Campo: MODULO)
        /// </summary>
        string? Module { get; set; }

        /// <summary>
        /// Indicador si el requerimiento está desplazado. (Campo: DESPLAZADO)
        /// </summary>
        string? IsDisplaced { get; set; }

        /// <summary>
        /// Indicador si el requerimiento está reprogramado. (Campo: REPROGRAMADO)
        /// </summary>
        string? IsReprogrammed { get; set; }

        /// <summary>
        /// Indicador si se permite programación en días festivos. (Campo: PERMITE_PROGRAMACION_FESTIVOS)
        /// </summary>
        string? AllowsHolidayScheduling { get; set; }

        /// <summary>
        /// Fecha de inicio de la programación inicial. (Campo: FECHA_PROGRAMADA_INICIAL)
        /// </summary>
        DateTime? InitialScheduledDate { get; set; }

        /// <summary>
        /// Etapa del requerimiento. (Campo: ETAPA)
        /// </summary>
        string? Stage { get; set; }

        /// <summary>
        /// Etapa del proyecto. (Campo: ETAPA_PROYECTO)
        /// </summary>
        string? ProjectStage { get; set; }


        /// <summary>
        /// Usuario que programó el requerimiento. (Campo: USER_PROGRAMADO)
        /// </summary>
        string? ProgrammedByUser { get; set; }

        /// <summary>
        /// Usuario responsable de la ejecución del requerimiento. (Campo: USER_RESPONSABLE)
        /// </summary>
        string? ResponsibleUser { get; set; }

        /// <summary>
        /// Comentario adicional relacionado al requerimiento. (Campo: COMENTARIO)
        /// </summary>
        string? AdditionalComment { get; set; }

        /// <summary>
        /// Horas programadas iniciales para el requerimiento. (Campo: HORAS_PROGRAMADAS_INICIALES)
        /// </summary>
        decimal? InitialScheduledHours { get; set; }

        /// <summary>
        /// Contrato del requerimiento. (Campo: CONTRATO)
        /// </summary>
        string? Contract { get; set; }

        /// <summary>
        /// Projecto nuevo (Campo: PROJECT_NEW)
        /// </summary>
        string? ProjectNew { get; set; }

        /// <summary>
        /// Indicador si el requerimiento está asociado a un incidente. (Campo: INCIDENTE_REPORTA)
        /// </summary>
        string? IsIncidentReported { get; set; }

        /// <summary>
        /// Indicador si el incidente ha sido resuelto. (Campo: INCIDENTE_RESUELTO)
        /// </summary>
        string? IsIncidentResolved { get; set; }

        /// <summary>
        /// Tipo de incidente asociado al requerimiento. (Campo: TIPO_INCIDENTE)
        /// </summary>
        int? IncidentType { get; set; }

        /// <summary>
        /// Observaciones relacionadas al incidente. (Campo: OBSERVACION_INCIDENTE)
        /// </summary>
        string? IncidentObservation { get; set; }

        /// <summary>
        /// Identificador de corrección. (Campo: ID_CORRECCION)
        /// </summary>
        string? CorrectionId { get; set; }

        /// <summary>
        /// Orden del requerimiento. (Campo: ORDEN)
        /// </summary>
        int? Order { get; set; }

        /// <summary>
        /// Categoría del requerimiento. (Campo: CATEGORIA_ID)
        /// </summary>
        int? CategoryId { get; set; }

        /// <summary>
        /// Categoría del tipo de requerimiento. (Campo: CATEGORIA_ID_TRAMITE)
        /// </summary>
        int? CategoryIdResponse { get; set; }

        /// <summary>
        /// Fecha de entrega del requerimiento. (Campo: FECHA_ENTREGA)
        /// </summary>
        DateTime? DeliveryDate { get; set; }

        /// <summary>
        /// Fecha de finalización del requerimiento. (Campo: FECHA_FIN)
        /// </summary>
        DateTime? EndDate { get; set; }

        /// <summary>
        /// Horas adicionales asociadas al requerimiento. (Campo: HORAS_ADICIONALES)
        /// </summary>
        decimal? AdditionalHours { get; set; }

        /// <summary>
        /// Nivel de impacto del requerimiento. (Campo: NIVEL_IMPACTO)
        /// </summary>
        int? ImpactLevel { get; set; }

        /// <summary>
        /// Tipo de requerimiento. (Campo: TIPO)
        /// </summary>
        string? Type { get; set; }

        /// <summary>
        /// Nivel de urgencia del requerimiento. (Campo: NIVEL_URGENCIA)
        /// </summary>
        int? UrgencyLevel { get; set; }

        /// <summary>
        /// Periodo de validez del requerimiento. (Campo: VIGENCIA)
        /// </summary>
        int? ValidityPeriod { get; set; }

        /// <summary>
        /// Identificador de opción asociada al requerimiento. (Campo: OPCION_ID)
        /// </summary>
        long? OptionId { get; set; }

        /// <summary>
        /// Código de la empresa asociada al requerimiento. (Campo: CODIGO_EMPRESA)
        /// </summary>
        int? CompanyCode { get; set; }

        /// <summary>
        /// Fecha de la última actualización del estado del requerimiento. (Campo: FECHA_FIN_ESTADO)
        /// </summary>
        DateTime FinalStatusDate { get; set; }

        /// <summary>
        /// Horas extras asociadas al requerimiento. (Campo: HORAS_EXTRAS)
        /// </summary>
        decimal? OvertimeHours { get; set; }

        /// <summary>
        /// Comentario sobre la satisfacción técnica. (Campo: COMENTARIO_SATISFACCION_TECNICA)
        /// </summary>
        string? TechnicalSatisfactionComment { get; set; }

        /// <summary>
        /// Comentario sobre la satisfacción del servicio. (Campo: COMENTARIO_SATISFACCION_SERVICIO)
        /// </summary>
        string? ServiceSatisfactionComment { get; set; }

        /// <summary>
        /// Comentario sobre la satisfacción del tiempo de respuesta. (Campo: COMENTARIO_SATISFACCION_TIEMPO)
        /// </summary>
        string? TimeSatisfactionComment { get; set; }

        /// <summary>
        /// Tipo de presentación. (Campo: TIPO_PPT)
        /// </summary>
        string? PptType { get; set; }

        /// <summary>
        /// Área relacionada al requerimiento. (Campo: AREA)
        /// </summary>
        string? Area { get; set; }

        /// <summary>
        /// Subárea relacionada al requerimiento. (Campo: SUBAREA)
        /// </summary>
        string? SubArea { get; set; }

        /// <summary>
        /// Tipo de solicitud del cliente. (Campo: TIPO_REQUERIMIENTO_CLIENTE)
        /// </summary>
        string? RequerimientTypeClient { get; set; }

        /// <summary>
        /// Tema del requerimiento. (Campo: TEMA)
        /// </summary>
        string? Topic { get; set; }
        
        /// <summary>
        /// Origen del sistema que crea el requerimiento. (Campo: ORIGIN)
        /// </summary>
        string? Origin { get; set; }
    }
}

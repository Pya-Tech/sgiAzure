using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SgiAzure.Domain.Entities;

namespace SgiAzure.Infrastructure.Databases.Sgi.Configurations
{
    public class RequirementConfiguration : IEntityTypeConfiguration<Requirement>
    {
        public void Configure(EntityTypeBuilder<Requirement> builder)
        {
            builder.ToTable("REQUERIMIENTOS", "SGI");

            builder.Property(r => r.RequirementId)
                .HasColumnName("NUMERO_REQUERIMIENTO")
                .IsRequired();

            builder.Property(r => r.Status)
                .HasColumnName("ESTADO")
                .IsRequired();

            builder.Property(r => r.CreatedBy)
                .HasColumnName("USER_REPORTA")
                .IsRequired();

            builder.Property(r => r.CreatedAt)
                .HasColumnName("FECHA_REPORTA")
                .IsRequired();

            builder.Property(r => r.ReportedComment)
                .HasColumnName("COMENTARIO_REPORTA")
                .IsRequired();

            builder.Property(r => r.ErrorDescription)
                .HasColumnName("ERROR")
                .IsRequired(false);

            builder.Property(r => r.System)
                .HasColumnName("SISTEMA")
                .IsRequired();

            builder.Property(r => r.Program)
                .HasColumnName("PROGRAMA")
                .IsRequired(false);

            builder.Property(r => r.RelatedRequirementId)
                .HasColumnName("REQUERIMIENTO_RELACIONADO")
                .HasPrecision(6, 1)
                .IsRequired(false);

            builder.Property(r => r.ProcessRequirementType)
                .HasColumnName("TIPO_TRAMITE")
                .IsRequired(false);

            builder.Property(r => r.ScheduledHours)
                .HasColumnName("HORAS_PROGRAMADAS")
                .HasColumnType("NUMBER(6,1)")
                .IsRequired(false);

            builder.Property(r => r.ScheduledDate)
                .HasColumnName("FECHA_PROGRAMADA")
                .IsRequired(false);

            builder.Property(r => r.AdjustedDate)
                .HasColumnName("FECHA_AJUSTADA")
                .IsRequired(false);

            builder.Property(r => r.ResponseByUser)
                .HasColumnName("USER_RESPUESTA")
                .IsRequired(false);

            builder.Property(r => r.ActualHours)
                .HasColumnName("HORAS_REALES")
                .HasColumnType("NUMBER(6,1)")
                .IsRequired(false);

            builder.Property(r => r.OfficialRequirementType)
                .HasColumnName("TIPO_RESPUESTA")
                .IsRequired(false);

            builder.Property(r => r.HoursPerDay)
                .HasColumnName("HORAS_DIA")
                .HasColumnType("NUMBER(2)")
                .IsRequired(false);

            builder.Property(r => r.StartDate)
                .HasColumnName("FECHA_INICIO")
                .IsRequired(false);

            builder.Property(r => r.Priority)
                .HasColumnName("PRIORIDAD")
                .IsRequired(false);

            builder.Property(r => r.SatisfactionLevel)
                .HasColumnName("SATISFACCION")
                .IsRequired(false);

            builder.Property(r => r.TechnicalSatisfactionLevel)
                .HasColumnName("SAT_TECNICA")
                .IsRequired(false);

            builder.Property(r => r.ServiceSatisfactionLevel)
                .HasColumnName("SAT_SERVICIO")
                .IsRequired(false);

            builder.Property(r => r.TimeSatisfactionLevel)
                .HasColumnName("SAT_TIEMPO")
                .IsRequired(false);

            builder.Property(r => r.ReportedRequirementType)
                .HasColumnName("TIPO_REPORTA")
                .IsRequired();

            builder.Property(r => r.Company)
                .HasColumnName("EMPRESA")
                .IsRequired(false);

            builder.Property(r => r.Project)
                .HasColumnName("PROYECTO")
                .IsRequired(false);

            builder.Property(r => r.Module)
                .HasColumnName("MODULO")
                .IsRequired(false);

            builder.Property(r => r.IsDisplaced)
                .HasColumnName("DESPLAZAR")
                .IsRequired(false);

            builder.Property(r => r.IsReprogrammed)
                .HasColumnName("REPROGRAMAR")
                .IsRequired(false);

            builder.Property(r => r.AllowsHolidayScheduling)
                .HasColumnName("PRG_FESTIVOS")
                .IsRequired(false);

            builder.Property(r => r.InitialScheduledDate)
                .HasColumnName("FECHA_PROGRAMADA_INI")
                .HasColumnType("DATE")
                .IsRequired(false);

            builder.Property(r => r.Stage)
                .HasColumnName("ETAPA")
                .IsRequired(false);

            builder.Property(r => r.ProgrammedByUser)
                .HasColumnName("USER_PROGRAMADO")
                .IsRequired(false);

            builder.Property(r => r.ResponsibleUser)
                .HasColumnName("USER_RESPONSABLE")
                .IsRequired(false);

            builder.Property(r => r.AdditionalComment)
                .HasColumnName("COMENTARIO")
                .IsRequired(false);

            builder.Property(r => r.InitialScheduledHours)
                .HasColumnName("HORAS_PROGRAMADAS_INI")
                .HasColumnType("NUMBER(6,1)")
                .IsRequired(false);

            builder.Property(r => r.ProjectStage)
                .HasColumnName("ETAPA_PROYECTO")
                .IsRequired(false);

            builder.Property(r => r.Contract)
                .HasColumnName("CONTRATO")
                .IsRequired(false);

            builder.Property(r => r.ProjectNew)
                .HasColumnName("PROYECTO_NEW")
                .IsRequired(false);

            builder.Property(r => r.IsIncidentReported)
                .HasColumnName("INCIDENTE_REPORTA")
                .IsRequired(false)
                .HasDefaultValue("N");

            builder.Property(r => r.IsIncidentResolved)
                .HasColumnName("INCIDENTE_RESPUESTA")
                .IsRequired(false)
                .HasDefaultValue("N");

            builder.Property(r => r.IncidentType)
                .HasColumnName("TIPO_INCIDENTE")
                .IsRequired(false);

            builder.Property(r => r.IncidentObservation)
                .HasColumnName("OBSERVACION_INCIDENTE")
                .IsRequired(false);

            builder.Property(r => r.CorrectionId)
                .HasColumnName("ID_CORRECCION")
                .IsRequired(false);

            builder.Property(r => r.Order)
                .HasColumnName("ORDEN")
                .IsRequired(false);

            builder.Property(r => r.CategoryId)
                .HasColumnName("CATEGORIA_ID")
                .IsRequired(false);

            builder.Property(r => r.CategoryIdResponse)
                .HasColumnName("CATEGORIA_ID_TRAMITE")
                .IsRequired(false);

            builder.Property(r => r.DeliveryDate)
                .HasColumnName("FECHA_ENTREGA")
                .IsRequired(false);

            builder.Property(r => r.EndDate)
                .HasColumnName("FECHA_FIN")
                .IsRequired(false);

            builder.Property(r => r.AdditionalHours)
                .HasColumnName("HORAS_ADICIONALES")
                .HasColumnType("NUMBER(6,1)")
                .IsRequired(false);

            builder.Property(r => r.ImpactLevel)
                .HasColumnName("IMPACTO")
                .IsRequired(false);

            builder.Property(r => r.Type)
                .HasColumnName("TIPO")
                .IsRequired(false);

            builder.Property(r => r.UrgencyLevel)
                .HasColumnName("URGENCIA")
                .IsRequired(false);


            builder.Property(r => r.ValidityPeriod)
                .HasColumnName("VIGENCIA");

            builder.Property(r => r.OptionId)
                .HasColumnName("OPCION_ID")
                .IsRequired(false);

            builder.Property(r => r.CompanyCode)
                .HasColumnName("EMPRESA_CODIGO")
                .IsRequired(false);

            builder.Property(r => r.FinalStatusDate)
                .HasColumnName("FECHA_FIN_ESTADO")
                .IsRequired();

            builder.Property(r => r.OvertimeHours)
                .HasColumnName("HORAS_EXTRAS")
                .HasColumnType("NUMBER(4,1)")
                .IsRequired(false);

            builder.Property(r => r.TechnicalSatisfactionComment)
                .HasColumnName("SAT_COM_TECNICA")
                .IsRequired(false);

            builder.Property(r => r.ServiceSatisfactionComment)
                .HasColumnName("SAT_COM_SERVICIO")
                .IsRequired(false);

            builder.Property(r => r.TimeSatisfactionComment)
                .HasColumnName("SAT_COM_TIEMPO")
                .IsRequired(false);

            builder.Property(r => r.PptType)
                .HasColumnName("PPT_TIPO")
                .IsRequired(false);

            builder.Property(r => r.Area)
                .HasColumnName("AREA")
                .IsRequired(false);

            builder.Property(r => r.SubArea)
                .HasColumnName("SUB_AREA")
                .IsRequired(false);

            builder.Property(r => r.RequerimientTypeClient)
                .HasColumnName("TIPO_REQ_CLIENTE")
                .IsRequired(false);

            builder.Property(r => r.Topic)
                .HasColumnName("TEMA")
                .IsRequired(false);

            builder.Property(r => r.Origin)
                .HasColumnName("ORIGIN")
                .IsRequired(false);

        }
    }
}

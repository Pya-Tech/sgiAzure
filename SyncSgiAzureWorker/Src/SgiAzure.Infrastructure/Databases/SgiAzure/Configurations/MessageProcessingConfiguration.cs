using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Enum;

namespace SgiAzure.Infrastructure.Databases.SgiAzure.Configurations
{
    /// <summary>
    /// Configuración de la entidad MessageProcessing para Entity Framework Core.
    /// </summary>
    public class MessageProcessingConfiguration : IEntityTypeConfiguration<MessageProcessing>
    {
        /// <summary>
        /// Configura la entidad <see cref="MessageProcessing"/> mapeando las propiedades a las columnas de la base de datos.
        /// </summary>
        /// <param name="builder">El configurador para la entidad <see cref="MessageProcessing"/>.</param>
        public void Configure(EntityTypeBuilder<MessageProcessing> builder)
        {
            builder.ToTable("message_processing");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.MessageId)
                .HasColumnName("message_id")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(m => m.Queue)
                .HasColumnName("queue")
                .IsRequired()
                .HasMaxLength(45);

            builder.Property(m => m.RequirementId)
                .HasColumnName("requirement_id")
                .IsRequired(false);

            builder.Property(m => m.WorkItemId)
                .HasColumnName("work_item_id")
                .IsRequired(false);

            builder.Property(m => m.Status)
                .HasColumnName("status")
                .HasConversion<string>()
                .IsRequired()
                .HasDefaultValue(MessageProcessingStatus.Pending);

            builder.Property(m => m.ErrorMessage)
                .HasColumnName("error_message")
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(m => m.Attempts)
                .HasColumnName("attempts")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(m => m.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(m => m.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired(false)
                .HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP");

            builder.Property(m => m.RequirementWorkItemId)
                .HasColumnName("requirement_work_item_id")
                .IsRequired();

            builder.HasOne(r => r.RequirementWorkItem)
                .WithMany()
                .HasForeignKey(m => m.RequirementWorkItemId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

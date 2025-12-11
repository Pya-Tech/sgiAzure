using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Enum;

namespace SgiAzure.Infrastructure.Databases.SgiAzure.Configurations
{
    /// <summary>
    /// Configuración de la entidad RequirementWorkItem para Entity Framework Core.
    /// </summary>
    public class RequirementWorkItemConfiguration : IEntityTypeConfiguration<RequirementWorkItem>
    {
        /// <summary>
        /// Configura la entidad <see cref="RequirementWorkItem"/> mapeando las propiedades a las columnas de la base de datos.
        /// </summary>
        /// <param name="builder">El configurador para la entidad <see cref="RequirementWorkItem"/>.</param>
        public void Configure(EntityTypeBuilder<RequirementWorkItem> builder)
        {
            builder.ToTable("requirements_workitems");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.RequirementId)
                .HasColumnName("requirement_id")
                .IsRequired();

            builder.Property(r => r.Customer)
                .HasColumnName("customer")
                .IsRequired();

            builder.Property(r => r.Status)
                .HasColumnName("status")
                .IsRequired()
                .HasConversion(
                    v => v == Status.Enabled ? "E" : "D",
                    v => v == "E" ? Status.Enabled : Status.Disabled
                ).HasDefaultValue(Status.Enabled);

            builder.Property(r => r.WorkItemId)
                .HasColumnName("workitem_id")
                .IsRequired();

            builder.Property(r => r.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(r => r.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP");

            builder.Property(c => c.CustomerId)
                .IsRequired()
                .HasColumnName("customers_id");
        }
    }
}

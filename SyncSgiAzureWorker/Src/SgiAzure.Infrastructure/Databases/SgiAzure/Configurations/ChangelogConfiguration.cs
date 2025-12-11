using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SgiAzure.Domain.Entities;

namespace SgiAzure.Infrastructure.Databases.SgiAzure.Configurations
{
    /// <summary>
    /// Configuración de la entidad Changelog para Entity Framework Core.
    /// </summary>
    internal class ChangelogConfiguration : IEntityTypeConfiguration<Changelog>
    {
        /// <summary>
        /// Configura la entidad <see cref="Changelog"/> mapeando las propiedades a las columnas de la base de datos.
        /// </summary>
        /// <param name="builder">El configurador para la entidad <see cref="Changelog"/>.</param>
        public void Configure(EntityTypeBuilder<Changelog> builder)
        {
            builder.ToTable("changelogs");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(c => c.Origin)
                .HasColumnName("origin")
                .IsRequired()
                .HasMaxLength(45);

            builder.Property(c => c.ChangeDescription)
                .HasColumnName("chage_description")
                .IsRequired()
                .HasMaxLength(3000);

            builder.Property(c => c.ChangeType)
                .HasColumnName("change_type")
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(45);

            builder.Property(c => c.ChangeAt)
                .HasColumnName("change_at")
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(c => c.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(c => c.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired(false)
                .HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP");

            builder.Property(c => c.RequirementWorkItemId)
                .HasColumnName("requirements_workitems_id")
                .IsRequired();

            builder.HasOne(r => r.RequirementWorkItem)
                .WithMany()
                .HasForeignKey(c => c.RequirementWorkItemId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

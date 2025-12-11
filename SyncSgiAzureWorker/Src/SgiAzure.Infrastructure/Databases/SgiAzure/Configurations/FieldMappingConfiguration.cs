using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SgiAzure.Domain.Entities;

namespace SgiAzure.Infrastructure.Databases.SgiAzure.Configurations
{
    public class FieldMappingConfiguration : IEntityTypeConfiguration<FieldMapping>
    {
        public void Configure(EntityTypeBuilder<FieldMapping> builder)
        {
            builder.ToTable("field_mappings");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.FieldSourceId)
                .IsRequired()
                .HasColumnName("field_source");

            builder.Property(c => c.FieldMappedId)
                .IsRequired()
                .HasColumnName("field_mapped");

            builder.Property(c => c.CustomerId)
                .IsRequired()
                .HasColumnName("customers_id");

            builder.Property(c => c.Enabled)
                .IsRequired()
                .HasColumnType("TINYINT(1)")
                .HasColumnName("enabled");

            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasColumnName("created_at");

            builder.Property(c => c.UpdatedAt)
                .HasColumnName("updated_at");

            builder.HasOne(f => f.FieldMapped)
                .WithMany()
                .HasForeignKey(f => f.FieldMappedId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(f => f.FieldSource)
                .WithMany()
                .HasForeignKey(f => f.FieldSourceId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(f => f.Customer)
                .WithMany()
                .HasForeignKey(f => f.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}

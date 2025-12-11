using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SgiAzure.Domain.Entities;

namespace SgiAzure.Infrastructure.Databases.SgiAzure.Configurations
{
    public class FieldValueParameterConfiguration : IEntityTypeConfiguration<FieldValueParameter>
    {
        public void Configure(EntityTypeBuilder<FieldValueParameter> builder)
        {
            builder.ToTable("field_value_parameters");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.ValueCode)
                .IsRequired()
                .HasColumnName("value_code");

            builder.Property(f => f.ValueDescription)
                .IsRequired()
                .HasColumnName("value_description");

            builder.Property(f => f.IsActive)
                .IsRequired()
                .HasColumnName("is_active");

            builder.Property(f => f.FieldParameterId)
                .IsRequired()
                .HasColumnName("field_parameters_id");

            builder.Property(f => f.CreatedAt)
                .IsRequired()
                .HasColumnName("created_at");

            builder.Property(f => f.UpdatedAt)
                .HasColumnName("updated_at");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Enum;

namespace SgiAzure.Infrastructure.Databases.SgiAzure.Configurations
{
    public class FieldParameterConfiguration : IEntityTypeConfiguration<FieldParameter>
    {
        public void Configure(EntityTypeBuilder<FieldParameter> builder)
        {
            builder.ToTable("field_parameters");

            builder.HasKey(c => c.Id);

            builder.Property(f => f.Code)
                .IsRequired()
                .HasColumnName("code");

            builder.Property(f => f.CodeValue)
                .IsRequired(false)
                .HasColumnName("code_value");

            builder.Property(f => f.Description)
                .IsRequired(false)
                .HasColumnName("description");

            builder.Property(f => f.IsActive)
                .IsRequired()
                .HasColumnName("is_active");

            builder.Property(f => f.SourceType)
                .IsRequired()
                .HasConversion<string>()
                .HasColumnName("source_type");

            builder.Property(f => f.DataType)
                .IsRequired()
                .HasColumnName("data_type")
                .HasConversion<string>()
                .HasDefaultValue(SgiAzureDataType.String);

            builder.Property( f=> f.CreatedAt)
                .IsRequired()
                .HasColumnName("created_at");

            builder.Property (f => f.UpdatedAt)
                .IsRequired(false)
                .HasColumnName ("updated_at");
        }
    }
}

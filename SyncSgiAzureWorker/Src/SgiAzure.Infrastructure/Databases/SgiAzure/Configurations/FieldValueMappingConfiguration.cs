using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SgiAzure.Domain.Entities;

namespace SgiAzure.Infrastructure.Databases.SgiAzure.Configurations
{
    public class FieldValueMappingConfiguration : IEntityTypeConfiguration<FieldValueMapping>
    {
        public void Configure(EntityTypeBuilder<FieldValueMapping> builder)
        {
            builder.ToTable("field_value_mappings");

            builder.HasKey(c => c.Id);

            builder.Property(f => f.FieldParameterId)
                .HasColumnName("field_parameters_id");

            builder.Property(f => f.CustomerId)
                .IsRequired()
                .HasColumnName("customers_id");

            builder.Property(f => f.CreatedAt)
                .IsRequired()
                .HasColumnName("created_at");

            builder.Property(f => f.UpdatedAt)
                .HasColumnName("updated_at");

            builder.Property(f => f.LocalValueId)
                .IsRequired()
                .HasColumnName("local_value_id");

            builder.Property(f => f.EquivalentValueId)
                .IsRequired()
                .HasColumnName("equivalent_value_id");

            builder.Property(f => f.TargetSystem)
                .HasColumnName("target_system");

            builder.HasOne(f => f.Customer)
                .WithMany()
                .HasForeignKey(f => f.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(f => f.FieldParameter)
                .WithMany()
                .HasForeignKey(f => f.FieldParameterId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(f => f.EquivalentValue)
                .WithMany()
                .HasForeignKey(f => f.EquivalentValueId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(f => f.LocalValue)
                .WithMany()
                .HasForeignKey (f => f.LocalValueId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

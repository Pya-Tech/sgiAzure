using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SgiAzure.Domain.Entities;

namespace SgiAzure.Infrastructure.Databases.SgiAzure.Configurations
{
    public class WorkArtifactMappingConfiguration : IEntityTypeConfiguration<WorkArtifactMapping>
    {
        public void Configure(EntityTypeBuilder<WorkArtifactMapping> builder)
        {
            builder.ToTable("work_artifacts_mappings");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Enabled)
                .IsRequired()
                .HasColumnName("enabled")
                .HasDefaultValue(true);

            builder.Property(f => f.CustomerId)
                .IsRequired()
                .HasColumnName("customers_id");

            builder.Property(f => f.RequirementArtifactId)
                .IsRequired()
                .HasColumnName("requirement_artifact_id");
            
            builder.Property(f => f.WorkitemArtifactId)
                .IsRequired()
                .HasColumnName("workitem_artifact_id");

            builder.Property(f => f.CreatedAt)
                .IsRequired()
                .HasColumnName("created_at");

            builder.Property(f => f.UpdatedAt)
                .IsRequired(false)
                .HasColumnName("updated_at");

            builder.HasOne(f => f.RequirementArtifact)
                .WithMany()
                .HasForeignKey(f => f.RequirementArtifactId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(f => f.Customer)
                .WithMany()
                .HasForeignKey(f => f.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(f => f.WorkitemArtifact)
                .WithMany()
                .HasForeignKey(f => f.WorkitemArtifactId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

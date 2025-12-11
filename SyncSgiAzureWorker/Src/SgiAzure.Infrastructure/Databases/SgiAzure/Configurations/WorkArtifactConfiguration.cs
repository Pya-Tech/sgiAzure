using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SgiAzure.Domain.Entities;

namespace SgiAzure.Infrastructure.Databases.SgiAzure.Configurations
{
    public class WorkArtifactConfiguration : IEntityTypeConfiguration<WorkArtifact>
    {
        public void Configure(EntityTypeBuilder<WorkArtifact> builder)
        {
            builder.ToTable("work_artifacts");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Name)
                .IsRequired()
                .HasColumnName("name");

            builder.Property( f=> f.Description)
                .IsRequired()
                .HasColumnName("description");

            builder.Property(f => f.Type)
                .IsRequired()
                .HasColumnName("type")
                .HasConversion<string>();

            builder.Property(f => f.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(f => f.UpdatedAt)
                .HasColumnName("updated_at");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SgiAzure.Domain.Entities;

namespace SgiAzure.Infrastructure.Databases.Sgi.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToView("REQ_EMPRESA_CTOS_SISTEMAS", "SGI").HasNoKey();

            builder.Property(r => r.CompanyId)
                .HasColumnName("EMPRESA");

            builder.Property(r => r.Validity)
                .HasColumnName("VIGENCIA");

            builder.Property(r => r.Contract)
                .HasColumnName("CONTRATO");

            builder.Property(r => r.Description)
                .HasColumnName("DESCRIPCION");

            builder.Property(r => r.System)
                .HasColumnName("SISTEMA");

        }
    }
}

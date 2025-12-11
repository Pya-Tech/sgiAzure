using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SgiAzure.Domain.Entities;

namespace SgiAzure.Infrastructure.Databases.Sgi.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToView("V_EMPRESAS_USU", "GEN").HasNoKey();

            builder.Property(r => r.CompanyId)
                .HasColumnName("EMPRESA");

            builder.Property(r => r.Name)
                .HasColumnName("DESCRIPCION");

            builder.Property(r => r.Department)
                .HasColumnName("DEPARTAMENTO");

            builder.Property(r => r.Municipality)
                .HasColumnName("MUNICIPIO");

            builder.Property(r => r.CreatedBy)
                .HasColumnName("USER_SISTEMA");

            builder.Property(r => r.IsPrimary)
                .HasColumnName("PRINCIPAL");

        }
    }
}

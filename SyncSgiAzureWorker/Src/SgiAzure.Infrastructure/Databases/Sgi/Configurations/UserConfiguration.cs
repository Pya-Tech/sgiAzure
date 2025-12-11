using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SgiAzure.Domain.Entities;

namespace SgiAzure.Infrastructure.Databases.Sgi.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("USUARIOS");

            builder.Property(u => u.UserSystem)
                .HasColumnName("USER_SISTEMA")
                .IsRequired();

            builder.Property(u => u.IdCard)
                .HasColumnName("CEDULA")
                .IsRequired();

            builder.Property(u => u.FirstName)
                .HasColumnName("NOMBRE")
                .IsRequired();

            builder.Property(u => u.Zone)
                .HasColumnName("ZONA");

            builder.Property(u => u.Printer)
                .HasColumnName("IMPRESORA")
                .IsRequired(false);

            builder.Property(u => u.Status)
                .HasColumnName("ESTADO")
                .IsRequired();

            builder.Property(u => u.MaxSessions)
                .HasColumnName("SESIONES")
                .IsRequired(false);

            builder.Property(u => u.Email)
                .HasColumnName("MAIL")
                .IsRequired(false);

            builder.Property(u => u.AuxiliaryPrinter)
                .HasColumnName("IMPRESORA_AUX")
                .IsRequired(false);

            builder.Property(u => u.MobilePhone)
                .HasColumnName("TELEFONO_CELULAR")
                .IsRequired(false);

            builder.Property(u => u.SupervisorUser)
                .HasColumnName("USER_JEFE")
                .IsRequired(false);

            builder.Property(u => u.IdCardIssuedCity)
                .HasColumnName("EXPEDICION_CEDULA")
                .IsRequired(false);

            builder.Property(u => u.Password)
                .HasColumnName("PASSWORD")
                .IsRequired(false);

            builder.Property(u => u.UserType)
                .HasColumnName("TIPO")
                .IsRequired(false);

            builder.Property(u => u.DeactivationDate)
                .HasColumnName("FECHA_DESACTIVA")
                .HasColumnType("DATE")
                .IsRequired(false);

            builder.Property(u => u.ProfilePicture)
                .HasColumnName("FOTO")
                .IsRequired(false);

            builder.Property(u => u.Office)
                .HasColumnName("OFICINA")
                .IsRequired();

            builder.Property(u => u.Position)
                .HasColumnName("CARGO")
                .IsRequired(false);

            builder.Property(u => u.Dependency)
                .HasColumnName("DEPENDENCIA")
                .IsRequired(false);

            builder.Property(u => u.Extension)
                .HasColumnName("EXTENSION")
                .IsRequired(false);

            builder.Property(u => u.CreationDate)
                .HasColumnName("FECHA_CREACION")
                .HasColumnType("DATE");

            builder.HasKey(u => u.IdCard);
        }
    }

}


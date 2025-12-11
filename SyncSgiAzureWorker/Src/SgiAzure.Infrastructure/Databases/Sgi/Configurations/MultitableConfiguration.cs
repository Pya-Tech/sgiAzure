using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SgiAzure.Domain.Entities;

namespace SgiAzure.Infrastructure.Databases.Sgi.Configurations
{
    public class MultitableConfiguration : IEntityTypeConfiguration<Multitable>
    {
        public void Configure(EntityTypeBuilder<Multitable> builder)
        {
            builder.ToView("V_MULTITABLA", "GEN").HasNoKey();

            builder.Property(m => m.TableName)
                .HasColumnName("TABLA");

            builder.Property(m => m.TableDescription)
                .HasColumnName("D_TABLA");

            builder.Property(m => m.TableType)
                .HasColumnName("TIPO_TABLA");

            builder.Property(m => m.CodeId)
                .HasColumnName("CODIGO_ID");

            builder.Property(m => m.Code)
                .HasColumnName("CODIGO");

            builder.Property(m => m.CodeDescription)
                .HasColumnName("D_CODIGO");

            builder.Property(m => m.AuxiliaryCode)
                .HasColumnName("CODIGO_AUX");

            builder.Property(m => m.CharacterCode)
                .HasColumnName("CODIGO_CAR");

            builder.Property(m => m.NumericCode)
                .HasColumnName("CODIGO_NUM");

            builder.Property(m => m.CharacterValue)
                .HasColumnName("VALOR_CAR");

            builder.Property(m => m.NumericValue)
                .HasColumnName("VALOR_NUM")
                .HasPrecision(20, 6);

            builder.Property(m => m.Value1)

                .HasColumnName("VALOR_1");

            builder.Property(m => m.Value2)
                .HasColumnName("VALOR_2")
                .IsRequired(false);

            builder.Property(m => m.Value3)
                .HasColumnName("VALOR_3");

            builder.Property(m => m.Value4)
                .HasColumnName("VALOR_4");

            builder.Property(m => m.Value5)
                .HasColumnName("VALOR_5");

            builder.Property(m => m.Value6)
                .HasColumnName("VALOR_6");

            builder.Property(m => m.Indicators)
                .HasColumnName("INDICADORES");

            builder.Property(m => m.DeactivationDate)
                .HasColumnName("FECHA_DESACTIVACION");

            builder.Property(m => m.DeactivationDateJulian)
                .HasColumnName("FECHA_DESACTIVACION_J");

            builder.Property(m => m.System)
                .HasColumnName("SISTEMA");

            builder.Property(m => m.Module)
                .HasColumnName("MODULO");

            builder.Property(m => m.Submodule)
                .HasColumnName("SUBMODULO");

            builder.Property(m => m.IsActive)
                .HasColumnName("ACTIVO");

            builder.Property(m => m.Key)
                .HasColumnName("LLAVE");

            builder.Property(m => m.RowId)
                .HasColumnName("ROW_ID");
        }
    }
}

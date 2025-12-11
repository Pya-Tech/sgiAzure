using Microsoft.EntityFrameworkCore;
using SgiAzure.Domain.Entities;
using SgiAzure.Infrastructure.Databases.SgiAzure.Configurations;

namespace SgiAzure.Infrastructure.Databases.SgiAzure
{
    /// <summary>
    /// Clase encargada de gestionar la conexión con entity a la base de datos de MySql.
    /// </summary>
    public class SgiAzureDbContext : DbContext
    {
        public SgiAzureDbContext(DbContextOptions<SgiAzureDbContext> options) : base(options) { }

        /// <summary>Tabla que relaciona requerimientos del SGI con work items de Azure.</summary>
        public DbSet<RequirementWorkItem> RequirementWorkItems { get; set; }

        /// <summary>Tabla de auditoría de cambios sobre los requerimientos.</summary>
        public DbSet<Changelog> Changelogs { get; set; }

        /// <summary>Control y trazabilidad de mensajes procesados.</summary>
        public DbSet<MessageProcessing> MessageProcessings { get; set; }

        /// <summary>Clientes configurados en el sistema SGI-Azure.</summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>Valores permitidos para un parámetro (ej.: Estados, prioridades).</summary>
        public DbSet<FieldValueParameter> FieldValues { get; set; }

        /// <summary>Parámetros que definen campos del SGI o Azure DevOps.</summary>
        public DbSet<FieldParameter> FieldParameters { get; set; }

        /// <summary>Mapeo entre valores de SGI ↔ Azure.</summary>
        public DbSet<FieldValueMapping> FieldValueMappings { get; set; }

        /// <summary>Mapeo entre campos de SGI ↔ Azure.</summary>
        public DbSet<FieldMapping> FieldMappings { get; set; }

        /// <summary>Tipos de artefactos disponibles (requirement, workitem).</summary>
        public DbSet<WorkArtifact> WorkArtifacts { get; set; }

        /// <summary>Relaciones entre artefactos de SGI y artefactos de Azure.</summary>
        public DbSet<WorkArtifactMapping> WorkArtifactsMapping { get; set; }

        /// <summary>
        /// Aplica las configuraciones de mapeo para cada entidad utilizando
        /// las clases que implementan <c>IEntityTypeConfiguration</c>.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RequirementWorkItemConfiguration());
            modelBuilder.ApplyConfiguration(new MessageProcessingConfiguration());
            modelBuilder.ApplyConfiguration(new ChangelogConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new FieldValueMappingConfiguration());
            modelBuilder.ApplyConfiguration(new FieldParameterConfiguration());
            modelBuilder.ApplyConfiguration(new FieldValueParameterConfiguration());
            modelBuilder.ApplyConfiguration(new FieldMappingConfiguration());
            modelBuilder.ApplyConfiguration(new WorkArtifactConfiguration());
            modelBuilder.ApplyConfiguration(new WorkArtifactMappingConfiguration());

        }
    }
}

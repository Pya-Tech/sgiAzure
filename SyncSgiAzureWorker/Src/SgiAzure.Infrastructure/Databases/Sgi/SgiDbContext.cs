using Microsoft.EntityFrameworkCore;
using SgiAzure.Domain.Entities;
using SgiAzure.Infrastructure.Databases.Sgi.Configurations;

namespace SgiAzure.Infrastructure.Databases.Sgi
{
    public class SgiDbContext : DbContext
    {
        public SgiDbContext(DbContextOptions<SgiDbContext> options) : base(options) { }

        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Multitable> Multitables { get; set; }
        public DbSet<Project> Projects  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RequirementConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new MultitableConfiguration());
        }
    }
}

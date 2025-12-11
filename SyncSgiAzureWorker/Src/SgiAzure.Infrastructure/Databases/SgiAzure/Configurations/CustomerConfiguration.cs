using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SgiAzure.Domain.Entities;

namespace SgiAzure.Infrastructure.Databases.SgiAzure.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customers");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("name");

            builder.Property(c => c.Domain)
                .IsRequired()
                .HasColumnName("domain");

            builder.Property(c => c.Project)
                .IsRequired()
                .HasColumnName("project");

            builder.Property(c => c.AccessToken)
                .IsRequired()
                .HasColumnName("access_token");

            builder.Property(c => c.Organization)
                .IsRequired()
                .HasColumnName("organization");

            builder.Property(c => c.UserName)
                .IsRequired()
                .HasColumnName("username");

            builder.Property(c => c.Email)
                .HasColumnName("email");

            builder.Property(m => m.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(m => m.UpdatedAt)
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP");

        }
    }
}

using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Interfaces.Repositories;
using SgiAzure.Infrastructure.Repositories;
using Src.SgiAzure.Infrastructure.Repositories;

namespace SgiAzure.Worker.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRequirementRepository<Requirement>, RequirementsRepository>();
            services.AddScoped<IRequirementWorkItemRepository<RequirementWorkItem>, RequirementWorkItemRepository>();
            services.AddScoped<IUserRepository<User>, UsersRepository>();
            services.AddScoped<IRequirementParameterRepository<Multitable>, RequirementParameterRepository>();
            services.AddScoped<IProjectRepository<Project>, ProjectRepository>();
            services.AddScoped<ICompanyRepository<Company>, CompanyRepository>();
            services.AddScoped<IChangelogRepository<Changelog>, ChangelogRepository>();
            services.AddScoped<ICustomerRepository<Customer>, CustomerRepository>();

            services.AddScoped<IFieldParameterRepository<FieldParameter>, FieldParameterRepository>();
            services.AddScoped<IFieldValueParameterRepository<FieldValueParameter>, FieldValueParameterRepository>();
            services.AddScoped<IFieldMappingRepository<FieldMapping>, FieldMappingRepository>();
            services.AddScoped<IFieldValueMappingRepository<FieldValueMapping>, FieldValueMappingRepository>();
            services.AddScoped<IWorkArtifactRepository<WorkArtifact>, WorkArtifactRepository>();
            services.AddScoped<IWorkArtifactMappingRepository<WorkArtifactMapping>, WorkArtifactMappingRepository>();

            return services;
        }
    }
}

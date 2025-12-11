using SgiAzure.Application.Dtos;
using SgiAzure.Application.Interfaces.Services;
using SgiAzure.Application.Services;
using SgiAzure.Application.UseCases;
using SgiAzure.Domain.Interfaces.Factories.SgiAzure.Domain.Factories;
using SgiAzure.Infrastructure.Factory;

namespace SgiAzure.Worker.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService<UserDto>, UserService>();
            services.AddScoped<IRequirementService<RequirementDto>, RequirementService>();
            services.AddScoped<IRequirementWorkItemService<RequirementWorkItemDto>, RequirementWorkItemService>();
            services.AddScoped<IRequirementToWorkItemMapperService, RequirementWorkItemMappingService>();
            services.AddScoped<IChangeLogService, ChangeLogService>();
            services.AddScoped<WorkItemValidatorService>();

            services.AddSingleton<AzureWorkItemProviderFactory>();
            services.AddScoped<IAzureWorkItemServiceFactory, AzureWorkItemProviderFactory>();

            services.AddScoped<CreateWorkItemUseCase>();
            services.AddScoped<UpdateWorkItemFromRequirementUseCase>();
            services.AddScoped<CreateRequirementUseCase>();
            services.AddScoped<UpdateWorkItemUseCase>();

            return services;
        }
    }
}

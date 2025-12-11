using SgiAzure.Application.Interfaces.Mappings;
using SgiAzure.Application.Mappings;
using SgiAzure.Application.Mappings.Strategies;

namespace SgiAzure.Worker.Extensions
{
    public static class StrategyExtension
    {
        public static IServiceCollection AddFieldMappings(this IServiceCollection services)
        {
            services.AddScoped<IFieldMappingStrategy, PriorityMappingStrategy>();
            services.AddScoped<IFieldMappingStrategy, SystemMappingStrategy>();
            services.AddScoped<IFieldMappingStrategy, RequirementTypeMappingStrategy>();
            services.AddScoped<IFieldMappingStrategy, ProcessingTypeMappingStrategy>();
            services.AddScoped<IFieldMappingStrategy, WorkItemTypeMappingStrategy>();
            services.AddScoped<IFieldMappingStrategy, StatusMappingStrategy>();
            services.AddScoped<IFieldMappingContext,  FieldMappingContext>();

            return services;
        }
    }
}

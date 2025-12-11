using SgiAzure.Application.Dtos;
using SgiAzure.Application.Interfaces.Mappers;
using SgiAzure.Application.Mappers;

namespace SgiAzure.Worker.Extensions
{
    public static class MappersExtensions
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            //services.AddScoped<IMapper<RequirementCreatedDto, WorkItemCreatedDto>, RequirementToWorkItemCreatedMapper>();
            services.AddScoped<IMapper<RequirementCreatedDto, WorkItemCreatedDto>, WorkItemCreateMapper>();
            //services.AddScoped<IMapper<RequirementUpdatedDto, WorkItemUpdatedDto>, RequirementToWorkItemUpdatedMapper>();
            services.AddScoped<IMapper<RequirementUpdatedDto, WorkItemUpdatedDto>, WorkItemUpdateMapper>();
            services.AddScoped<IMapper<WorkItemCreatedDto, RequirementCreatedDto>, WorkItemToRequirementCreatedMapper>();
            services.AddScoped<IMapper<WorkItemUpdatedMessageDto, RequirementUpdatedDto>, WorkItemToRequirementUpdatedMapper>();

            return services;
        }
    }
}

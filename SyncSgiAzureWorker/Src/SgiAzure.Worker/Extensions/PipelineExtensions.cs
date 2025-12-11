using SgiAzure.Application.Dtos;
using SgiAzure.Infrastructure.Messaging;

namespace SgiAzure.Worker.Extensions
{
    public static class PipelinesExtensions
    {
        public static IServiceCollection AddPipelines(this IServiceCollection services)
        {
            services.AddScoped<MessagePipeline<RequirementCreatedDto>>();
            services.AddScoped<MessagePipeline<RequirementUpdatedDto>>();
            services.AddScoped<MessagePipeline<WorkitemCreatedMessageDto>>();
            services.AddScoped<MessagePipeline<WorkItemUpdatedDto>>();

            return services;
        }
    }
}

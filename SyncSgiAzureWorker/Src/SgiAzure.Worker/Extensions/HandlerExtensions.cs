using Application.Messaging.Handlers;
using Application.Messaging.Interfaces;
using SgiAzure.Application.Dtos;

namespace SgiAzure.Worker.Extensions
{
    public static class HandlersExtensions
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddScoped<IMessageHandler<RequirementCreatedDto>, WorkItemCreateHandler>();
            services.AddScoped<IMessageHandler<RequirementUpdatedDto>, WorkItemUpdateHandler>();
            services.AddScoped<IMessageHandler<WorkitemCreatedMessageDto>, RequirementCreateHandler>();
            services.AddScoped<IMessageHandler<WorkItemUpdatedDto>, RequirementUpdateHandler>();

            return services;
        }
    }
}

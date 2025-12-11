using Infrastructure.Messaging.Models;
using Microsoft.Extensions.Options;
using SgiAzure.Application.Config;
using SgiAzure.Application.Interfaces.Config;
using SgiAzure.Infrastructure.Settings;

namespace SgiAzure.Worker.Extensions
{
    public static class ApplicationSettingsExtensions
    {
        public static IServiceCollection AddApplicationSettings(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<WorkItemMappings>(configuration.GetSection("WorkItemMappings"));
            services.AddScoped<IWorkItemMappingsConfig>(sp =>
                sp.GetRequiredService<IOptions<WorkItemMappings>>().Value);

            services.Configure<RabbitMQSettings>(configuration.GetSection("RabbitMQ"));

            services.Configure<AzureConnections>(configuration.GetSection("AzureDevopsConnections"));

            services.Configure<AzureConfigurations>(configuration.GetSection("AzureConfigurations"));

            return services;
        }
    }
}

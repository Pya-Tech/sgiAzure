using Infrastructure.Messaging.Interfaces;
using Infrastructure.Messaging.Models;
using Messaging.Dlq;
using Microsoft.Extensions.Options;
using SgiAzure.Infrastructure.Messaging;
using System.Text.Json;

namespace SgiAzure.Worker.Extensions
{
    public static class MessagingExtensions
    {
        public static IServiceCollection AddMessaging(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton(new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = false
            });

            services.AddSingleton<IMessageBroker>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<RabbitMqBroker>>();
                var options = sp.GetRequiredService<IOptions<RabbitMQSettings>>();

                return RabbitMqBroker.CreateAsync(options, logger)
                    .GetAwaiter()
                    .GetResult();
            });

            services.AddSingleton<IDlqPublisher, DlqPublisher>();

            return services;
        }
    }
}

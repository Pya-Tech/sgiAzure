using ServiceHook.Application.Interfaces.Config;
using System.Text.Json.Serialization;

namespace ServiceHook.Application.Configuration
{
    public class QueueConfiguration
    {
        [JsonPropertyName("RoutingKey")]
        public required string RoutingKey { get; set; }

        [JsonPropertyName("QueueName")]
        public required string QueueName { get; set; }

    }
}

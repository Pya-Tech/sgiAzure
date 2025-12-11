using ServiceHook.Application.Interfaces.Config;
using System.Text.Json.Serialization;

namespace ServiceHook.Application.Configuration
{
    public class BrokerMessageConfiguration
    {

        [JsonPropertyName("Exchange")]
        public required string Exchange { get; set; }

        [JsonPropertyName("Queues")]
        public required Dictionary<string, QueueConfiguration> Queues { get; set; }

        [JsonPropertyName("Users")]
        public required List<string> Users { get; set; }

        [JsonPropertyName("IterationPath")]
        public required List<string> IterationPath { get; set; }
        
    }
}

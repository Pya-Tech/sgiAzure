using SgiAzure.Application.Interfaces.Config;
using System.Text.Json.Serialization;

namespace SgiAzure.Application.Config
{
    public class WorkItemMappings : IWorkItemMappingsConfig
    {
        [JsonPropertyName("Types")]
        public Dictionary<string, string> Types { get; set; } = default!;

        [JsonPropertyName("Priorities")]
        public Dictionary<int, string> Priorities { get; set; } = default!;

        [JsonPropertyName("Statuses")]
        public Dictionary<string, string> Statuses { get; set; } = default!;
    }
}

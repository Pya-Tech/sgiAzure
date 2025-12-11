using System.Text.Json.Serialization;

namespace ServiceHook.Api.Models
{
    public partial class CreatedBy
    {
        [JsonPropertyName("displayName")]
        public required string DisplayName { get; set; }

        [JsonPropertyName("url")]
        public required Uri Url { get; set; }

        [JsonPropertyName("_links")]
        public required SystemChangedByLinks Links { get; set; }

        [JsonPropertyName("id")]
        public required Guid Id { get; set; }

        [JsonPropertyName("uniqueName")]
        public required string UniqueName { get; set; }

        [JsonPropertyName("imageUrl")]
        public required Uri ImageUrl { get; set; }

        [JsonPropertyName("descriptor")]
        public required string Descriptor { get; set; }
    }
}
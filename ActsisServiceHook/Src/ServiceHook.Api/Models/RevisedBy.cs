using System.Text.Json.Serialization;

namespace ServiceHook.Api.Models
{
    public partial class RevisedBy
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("displayName")]
        public string? DisplayName { get; set; }

        [JsonPropertyName("url")]
        public Uri? Url { get; set; }

        [JsonPropertyName("_links")]
        public RevisedByLinks? Links { get; set; }

        [JsonPropertyName("uniqueName")]
        public string? UniqueName { get; set; }

        [JsonPropertyName("imageUrl")]
        public Uri? ImageUrl { get; set; }

        [JsonPropertyName("descriptor")]
        public string? Descriptor { get; set; }
    }
}

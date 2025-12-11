using System.Text.Json.Serialization;

namespace ServiceHook.Api.Models
{
    public class Revision
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("rev")]
        public long Rev { get; set; }

        [JsonPropertyName("fields")]
        public RevisionFields? Fields { get; set; }

        [JsonPropertyName("_links")]
        public RevisionLinks? Links { get; set; }

        [JsonPropertyName("url")]
        public Uri? Url { get; set; }
    }
}

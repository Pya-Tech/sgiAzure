using System.Text.Json.Serialization;

namespace ServiceHook.Api.Models
{
    public partial class Resource
    {
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        [JsonPropertyName("workItemId")]
        public long? WorkItemId { get; set; }

        [JsonPropertyName("rev")]
        public long? Rev { get; set; }

        [JsonPropertyName("revisedBy")]
        public RevisedBy? RevisedBy { get; set; }

        [JsonPropertyName("revisedDate")]
        public DateTimeOffset RevisedDate { get; set; }

        [JsonPropertyName("fields")]
        public ResourceFields? Fields { get; set; }

        [JsonPropertyName("_links")]
        public ResourceLinks? Links { get; set; }

        [JsonPropertyName("url")]
        public Uri? Url { get; set; }

        [JsonPropertyName("revision")]
        public Revision? Revision { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace ServiceHook.Api.Models
{
    public class ResourceLinks
    {
        [JsonPropertyName("self")]
        public HtmlClass? Self { get; set; }

        [JsonPropertyName("workItemUpdates")]
        public  HtmlClass? WorkItemUpdates { get; set; }

        [JsonPropertyName("workItemRevisions")]
        public HtmlClass? WorkItemRevisions { get; set; }

        [JsonPropertyName("workItemType")]
        public HtmlClass? WorkItemType { get; set; }

        [JsonPropertyName("fields")]
        public HtmlClass? Fields { get; set; }
    }

}
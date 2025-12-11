using System.Text.Json.Serialization;

namespace ServiceHook.Api.Models
{
    public class RevisionLinks
    {
        [JsonPropertyName("self")]
        public HtmlClass? Self { get; set; }

        [JsonPropertyName("workItemRevisions")]
        public HtmlClass? WorkItemRevisions { get; set; }

        [JsonPropertyName("parent")]
        public HtmlClass? Parent { get; set; }
    }

}

using System.Text.Json.Serialization;

namespace ServiceHook.Api.Models
{
    public class RevisedByLinks
    {
        [JsonPropertyName("avatar")]
        public required HtmlClass Avatar { get; set; }
    }
}

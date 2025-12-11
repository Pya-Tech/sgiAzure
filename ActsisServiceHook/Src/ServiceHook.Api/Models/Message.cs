using System.Text.Json.Serialization;

namespace ServiceHook.Api.Models
{
    public partial class Message
    {
        [JsonPropertyName("text")]
        public required string Text { get; set; }

        [JsonPropertyName("html")]
        public required string Html { get; set; }

        [JsonPropertyName("markdown")]
        public required string Markdown { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace ServiceHook.Api.Models
{
    public partial class HtmlClass
    {
        [JsonPropertyName("href")]
        public required Uri Href { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace ServiceHook.Api.Models
{
    public partial class SystemChangedByLinks
    {
        [JsonPropertyName("avatar")]
        public  HtmlClass Avatar { get; set; }
    }
}
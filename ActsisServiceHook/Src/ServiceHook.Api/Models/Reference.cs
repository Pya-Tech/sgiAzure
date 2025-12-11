using System.Text.Json.Serialization;

namespace ServiceHook.Api.Models
{
    public partial class Reference
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("baseUrl")]
        public Uri? BaseUrl { get; set; }
    }
}
using System.Text.Json.Serialization;

namespace ServiceHook.Api.Models
{
    public partial class ResourceContainers
    {
        [JsonPropertyName("collection")]
        public  Reference? Collection { get; set; }

        [JsonPropertyName("account")]
        public  Reference? Account { get; set; }

        [JsonPropertyName("project")]
        public  Reference? Project { get; set; }

        [JsonPropertyName("server")]
        public Reference? Server { get; set; }
    }

}
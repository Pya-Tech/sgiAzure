using System.Text.Json.Serialization;

namespace SgiAzure.Infrastructure.Settings
{
    public class AzureConnections
    {
        /// <summary>
        /// Lista de configuraciones de servidores de Azure DevOps.
        /// </summary>
        [JsonPropertyName("Servers")]
        public List<AzureDevopsServerSettings> Servers { get; set; } = new();
    }
}

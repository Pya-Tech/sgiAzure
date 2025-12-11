using System.Text.Json.Serialization;

namespace SgiAzure.Infrastructure.Settings
{
    /// <summary>
    /// Representa la configuración general de Azure DevOps utilizada por la aplicación.
    /// Esta configuración incluye detalles específicos sobre los campos personalizados 
    /// que se sincronizan entre los sistemas.
    /// </summary>
    public class AzureConfigurations
    {
        /// <summary>
        /// Obtiene o establece la configuración de los campos personalizados de Azure DevOps.
        /// Esta sección contiene los mapeos de los campos utilizados en los procesos
        /// de sincronización entre SGI y Azure Boards.
        /// </summary>
        [JsonPropertyName("Fields")]
        public AzureFieldsConfiguration Fields { get; set; } = default!;
    }
}

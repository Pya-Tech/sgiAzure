using System.Text.Json.Serialization;

namespace SgiAzure.Infrastructure.Settings
{
    /// <summary>
    /// Configuración para la integración con Azure DevOps.
    /// Esta clase encapsula las propiedades necesarias para establecer una conexión con un servidor de Azure DevOps, incluyendo el token de acceso personal, dominio, organización y proyecto.
    /// </summary>
    /// <remarks>
    /// Inicializa una nueva instancia de la clase <see cref="AzureDevopsServerSettings"/>.
    /// </remarks>
    public class AzureDevopsServerSettings
    {

        /// <summary>
        /// Nombre de la empresa a la cual pertenece la conexión
        /// </summary>
        [JsonPropertyName("Name")]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Token de acceso personal utilizado para autenticar las solicitudes al servidor de Azure DevOps.
        /// </summary>
        [JsonPropertyName("Token")]
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// Token de acceso personal utilizado para autenticar las solicitudes al servidor de Azure DevOps.
        /// </summary>
        [JsonPropertyName("User")]
        public string User { get; set; } = string.Empty;

        /// <summary>
        /// Dominio del servidor de Azure DevOps (por ejemplo, "https://dev.azure.com").
        /// </summary>
        [JsonPropertyName("Domain")]
        public string Domain { get; set; } = default!;

        /// <summary>
        /// Organización de Azure DevOps asociada a las solicitudes.
        /// </summary>
        [JsonPropertyName("Organization")]
        public string Organization { get; set; } = default!;

        /// <summary>
        /// URI completo del servidor de Azure DevOps, compuesto por el dominio y la organización.
        /// Este URI puede utilizarse para construir solicitudes a las APIs de Azure DevOps.
        /// </summary>
        public Uri Uri => new($"{Domain}/{Organization}");

        /// <summary>
        /// Nombre del proyecto dentro de la organización de Azure DevOps.
        /// </summary>
        [JsonPropertyName("Project")]
        public string Project { get; set; } = default!;

        /// <summary>
        /// Representación en cadena de la configuración del servidor de Azure DevOps.
        /// </summary>
        /// <returns>Cadena que contiene los valores de las propiedades de la instancia.</returns>
        public override string ToString()
        {
            return $"Company: {Name}, Domain: {Domain}, Org: {Organization}, Project: {Project}, Uri: {Uri}";
        }
    }
}

using System.Text.Json.Serialization;

namespace SgiAzure.Application.Dtos
{
    public class WorkItemUpdatedMessageDto
    {
        /// <summary>
        /// Origen del evento de actualización.
        /// </summary>
        [JsonPropertyName("origin")]
        public required string Origin { get; set; }

        /// <summary>
        /// Información del WorkItem antes de la actualización.
        /// </summary>
        [JsonPropertyName("old_work_item")]
        public required WorkItemUpdatedDto OldWorkItem { get; set; }

        /// <summary>
        /// Información del WorkItem después de la actualización.
        /// </summary>
        [JsonPropertyName("new_work_item")]
        public required WorkItemUpdatedDto NewWorkItem { get; set; }

        /// <summary>
        /// URL del proyecto asociado.
        /// </summary>
        [JsonPropertyName("project_url")]
        public required string ProjectUrl { get; set; }

        /// <summary>
        /// ID de la revisión.
        /// </summary>
        [JsonPropertyName("revision_id")]
        public int RevisionId { get; set; }

        /// <summary>
        /// Número de revisión actual.
        /// </summary>
        [JsonPropertyName("revision")]
        public int Revision { get; set; }

        /// <summary>
        /// Usuario que revisó el WorkItem.
        /// </summary>
        [JsonPropertyName("revised_by")]
        public required string RevisedBy { get; set; }

        /// <summary>
        /// Fecha y hora de la última actualización.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// ID del publicador del evento.
        /// </summary>
        [JsonPropertyName("publisher_id")]
        public required string PublisherId { get; set; }

        /// <summary>
        /// Dirección del servidor asociado.
        /// </summary>
        [JsonPropertyName("server")]
        public required string Server { get; set; }
    }
}

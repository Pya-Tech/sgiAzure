using System.Text.Json.Serialization;

namespace ServiceHook.Api.Models
{

    public class WorkItemEvent
    {
        [JsonPropertyName("subscriptionId")]
        public Guid SubscriptionId { get; set; }

        [JsonPropertyName("notificationId")]
        public long NotificationId { get; set; }

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("eventType")]
        public required string EventType { get; set; }

        [JsonPropertyName("publisherId")]
        public required string PublisherId { get; set; }

        [JsonPropertyName("message")]
        public required Message Message { get; set; }

        [JsonPropertyName("detailedMessage")]
        public required Message DetailedMessage { get; set; }

        [JsonPropertyName("resource")]
        public required Resource Resource { get; set; }

        [JsonPropertyName("resourceVersion")]
        public required string ResourceVersion { get; set; }

        [JsonPropertyName("resourceContainers")]
        public required ResourceContainers ResourceContainers { get; set; }

        [JsonPropertyName("createdDate")]
        public DateTimeOffset CreatedDate { get; set; }
    }
}
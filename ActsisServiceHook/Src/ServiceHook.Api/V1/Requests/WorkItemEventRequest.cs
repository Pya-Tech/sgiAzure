using ServiceHook.Api.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ServiceHook.Api.V1.Requests
{
    /// <summary>
    /// Representa un evento WorkItem request desde el api de Azure
    /// </summary>
    public class WorkItemEventRequest
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

        /// <summary>
        /// Validates the current request object.
        /// </summary>
        /// <exception cref="ValidationException">Thrown when validation fails.</exception>
        public void Validate()
        {
            Validator.ValidateObject(this, new ValidationContext(this), validateAllProperties: true);
        }

        /// <summary>
        /// Creates a shallow copy of the current request.
        /// </summary>
        /// <returns>A cloned instance of the request.</returns>
        public WorkItemEventRequest Clone()
        {
            return (WorkItemEventRequest)MemberwiseClone();
        }

    }
}
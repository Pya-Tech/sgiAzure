using ServiceHook.Application.Interfaces.Dto;
using System.Text.Json.Serialization;

namespace ServiceHook.Application.Dto
{
    public class WorkItemCreatedMessageDto: ICreatedWorkItemDto
    {

        [JsonPropertyName("work_item")]
        public required WorkItemDto WorkItem { get; set; }

        [JsonPropertyName("iteration-path")]
        public required string IterationPath { get; set; }

        [JsonPropertyName("project_url")]
        public required string ProjectUrl { get; set; }

        [JsonPropertyName("work_item_fields_url")]
        public required string WorkItemFieldsUrl { get; set; }

        [JsonPropertyName("work_item_url")]
        public required string WorkItemUrl { get; set; }

        [JsonPropertyName("work_item_type_url")]
        public required string WorkItemTypeUrl { get; set; }

        [JsonPropertyName("revision_id")]
        public int RevisionId { get; set; }

        [JsonPropertyName("revision")]
        public int Revision { get; set; }

        [JsonPropertyName("revised_by")]
        public required string RevisedBy { get; set; }

        [JsonPropertyName("origin")]
        public required string Origin { get; set; }

        [JsonPropertyName("server")]
        public required string Server { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("publisher_id")]
        public required string PublisherId { get; set; }
    }
}

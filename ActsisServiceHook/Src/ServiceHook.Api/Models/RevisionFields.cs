using ServiceHook.Api.Common.Serializations;
using System.Text.Json.Serialization;

namespace ServiceHook.Api.Models
{
    public class RevisionFields
    {
        [JsonPropertyName("System.AreaPath")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? SystemAreaPath { get; set; }

        [JsonPropertyName("System.TeamProject")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? SystemTeamProject { get; set; }

        [JsonPropertyName("System.IterationPath")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? SystemIterationPath { get; set; }

        [JsonPropertyName("System.WorkItemType")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? SystemWorkItemType { get; set; }

        [JsonPropertyName("System.State")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? SystemState { get; set; }

        [JsonPropertyName("System.Reason")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? SystemReason { get; set; }

        [JsonPropertyName("System.AssignedTo")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? SystemAssignedTo { get; set; }

        [JsonPropertyName("System.CreatedDate")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? SystemCreatedDate { get; set; }

        [JsonPropertyName("System.CreatedBy")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? SystemCreatedBy { get; set; }

        [JsonPropertyName("System.ChangedDate")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? SystemChangedDate { get; set; }

        [JsonPropertyName("System.ChangedBy")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? SystemChangedBy { get; set; }

        [JsonPropertyName("System.CommentCount")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? SystemCommentCount { get; set; }

        [JsonPropertyName("System.Title")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? SystemTitle { get; set; }

        [JsonPropertyName("Microsoft.VSTS.Common.StateChangeDate")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? MicrosoftVstsCommonStateChangeDate { get; set; }

        [JsonPropertyName("Microsoft.VSTS.Common.Priority")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? MicrosoftVstsCommonPriority { get; set; }

        [JsonPropertyName("Microsoft.VSTS.Common.ValueArea")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? MicrosoftVstsCommonValueArea { get; set; }

        [JsonPropertyName("Microsoft.VSTS.Scheduling.TargetDate")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? MicrosoftVstsSchedulingTargetDate { get; set; }

        [JsonPropertyName("Microsoft.VSTS.Scheduling.StartDate")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? MicrosoftVstsSchedulingStartDate { get; set; }

        [JsonPropertyName("Custom.Requirement")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? CustomRequirement { get; set; }

        [JsonPropertyName("Custom.CreatedBy")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? CustomCreatedBy { get; set; }

        [JsonPropertyName("Custom.Company")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? CustomCompany { get; set; }

        [JsonPropertyName("Custom.AssignedUser")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? CustomAssignedUser { get; set; }

        [JsonPropertyName("Custom.System")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? CustomSystem { get; set; }

        [JsonPropertyName("Custom.ProcessingType")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? CustomProcessingType { get; set; }

        [JsonPropertyName("Custom.EpicType")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? CustomEpicType { get; set; }

        [JsonPropertyName("System.Description")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? SystemDescription { get; set; }


        [JsonPropertyName("System.History")]
        [JsonConverter(typeof(FieldSerialization))]
        public Field? SystemHistory { get; set; }
    }

}

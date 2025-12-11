using ServiceHook.Api.Common;
using ServiceHook.Api.Models;
using ServiceHook.Application.Dto;
using System.Text.RegularExpressions;

namespace ServiceHook.Api.V1.Mappers
{
    public static class WorkItemUpdatedMapper
    {
        private static WorkItemDto MapNewWorkItem(WorkItemEvent workItemEvent)
        {
            return new WorkItemDto
            {
                WorkItemId = (int?)workItemEvent.Resource.WorkItemId,
                RequerimentId = workItemEvent.Resource?.Fields?.CustomRequirement?.NewValue != null ? int.Parse(workItemEvent.Resource!.Fields!.CustomRequirement!.NewValue) : null,
                Title = workItemEvent.Resource?.Fields?.SystemTitle?.NewValue,
                Description = WorkItemMapper.RemoveDivTags(workItemEvent.Resource?.Fields?.SystemDescription?.NewValue ?? string.Empty),
                AssignedTo = workItemEvent.Resource?.Fields?.CustomAssignedUser?.NewValue,
                CreatedAt = workItemEvent.CreatedDate,
                Priority = workItemEvent.Resource?.Fields?.MicrosoftVstsCommonPriority?.NewValue ?? string.Empty,
                Company = workItemEvent.Resource?.Fields?.CustomCompany?.NewValue,
                Project = workItemEvent.Resource?.Fields?.SystemTeamProject?.NewValue,
                System = WorkItemMapper.RemoveSystemDescription(workItemEvent.Resource?.Fields?.CustomSystem?.NewValue ?? string.Empty),
                WorkItemType = workItemEvent.Resource?.Fields?.SystemWorkItemType?.NewValue,
                StartDate = WorkItemMapper.ConvertToDateTime(workItemEvent.Resource?.Fields?.MicrosoftVstsSchedulingStartDate?.NewValue),
                TargetDate = WorkItemMapper.ConvertToDateTime(workItemEvent.Resource?.Fields?.MicrosoftVstsSchedulingTargetDate?.NewValue),
                CreatedBy = workItemEvent.Resource?.Fields?.SystemCreatedBy?.NewValue,
                ProcessingType = workItemEvent.Resource?.Fields?.CustomProcessingType?.NewValue,
                ResponsibleUser = workItemEvent.Resource?.Fields?.CustomCreatedBy?.NewValue,
                ReportType = workItemEvent.Resource?.Fields?.CustomEpicType?.NewValue ??
                            workItemEvent.Resource?.Fields?.CustomTaskType?.NewValue ??
                            workItemEvent.Resource?.Fields?.CustomFeatureType?.NewValue ??
                            string.Empty
            };

        }

        private static WorkItemDto MapOldWorkItem(WorkItemEvent workItemEvent) => new()
        {
            RequerimentId = workItemEvent.Resource?.Fields?.CustomRequirement?.OldValue != null ? int.Parse(workItemEvent.Resource!.Fields!.CustomRequirement!.OldValue) : null,
            WorkItemId = (int?)workItemEvent.Resource?.Revision?.Id,
            Title = workItemEvent.Resource?.Fields?.SystemTitle?.OldValue,
            Description = WorkItemMapper.RemoveDivTags(workItemEvent.Resource?.Fields?.SystemDescription?.OldValue ?? string.Empty),
            AssignedTo = workItemEvent.Resource?.Fields?.CustomAssignedUser?.OldValue,
            CreatedAt = workItemEvent.CreatedDate,
            Priority = workItemEvent.Resource?.Fields?.MicrosoftVstsCommonPriority?.OldValue ?? string.Empty,
            Company = workItemEvent.Resource?.Fields?.CustomCompany?.OldValue,
            Project = workItemEvent.Resource?.Fields?.SystemTeamProject?.OldValue,
            System = WorkItemMapper.RemoveSystemDescription(workItemEvent.Resource?.Fields?.CustomSystem?.OldValue ?? string.Empty),
            WorkItemType = workItemEvent.Resource?.Fields?.SystemWorkItemType?.OldValue,
            StartDate = WorkItemMapper.ConvertToDateTime(workItemEvent.Resource?.Fields?.MicrosoftVstsSchedulingStartDate?.OldValue),
            TargetDate = WorkItemMapper.ConvertToDateTime(workItemEvent.Resource?.Fields?.MicrosoftVstsSchedulingTargetDate?.OldValue),
            CreatedBy = workItemEvent.Resource?.Fields?.SystemCreatedBy?.OldValue,
            ProcessingType = workItemEvent.Resource?.Fields?.CustomProcessingType?.OldValue,
            ResponsibleUser = workItemEvent.Resource?.Fields?.CustomCreatedBy?.OldValue,
            ReportType = workItemEvent.Resource?.Fields?.CustomEpicType?.OldValue ??
                            workItemEvent.Resource?.Fields?.CustomTaskType?.OldValue ??
                            workItemEvent.Resource?.Fields?.CustomFeatureType?.OldValue ??
                            string.Empty
        };

        /// <summary>
        /// Mapea una instancia de WorkItemEvent a un WorkItemDto.
        /// </summary>
        /// <param name="workItemEvent">La instancia de WorkItemEvent a mapear.</param>
        /// <returns>Un WorkItemDto con los valores extraídos de WorkItemEvent.</returns>
        public static WorkItemUpdatedMessageDto ToWorkItemUpdatedDto(this WorkItemEvent workItemEvent)
        {
            ArgumentNullException.ThrowIfNull(workItemEvent);
            return new WorkItemUpdatedMessageDto()
            {
                Origin = WorkItemMapper.MapCollection(workItemEvent.ResourceContainers?.Collection?.BaseUrl?.OriginalString) ?? string.Empty,
                IterationPath = workItemEvent.Resource?.Fields?.SystemIterationPath?.NewValue ?? string.Empty,
                ProjectUrl = workItemEvent.ResourceContainers?.Project?.BaseUrl?.OriginalString ?? string.Empty,
                PublisherId = workItemEvent.PublisherId,
                RevisedBy = workItemEvent.Resource?.RevisedBy?.Name ?? string.Empty,
                Revision = (int?)workItemEvent!.Resource!.Id ?? throw new InvalidOperationException("No puede ser nula la revisión global"),
                RevisionId = (int?)workItemEvent.Resource!.Rev ?? throw new InvalidOperationException("No puede ser nula la revisión"),
                Server = workItemEvent.ResourceContainers?.Server?.BaseUrl?.OriginalString ?? string.Empty,
                OldWorkItem = MapOldWorkItem(workItemEvent),
                NewWorkItem = MapNewWorkItem(workItemEvent)
            };
        }

    }
}

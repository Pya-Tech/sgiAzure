using ServiceHook.Api.Common;
using ServiceHook.Api.Models;
using ServiceHook.Api.V1.Requests;
using ServiceHook.Application.Dto;

namespace ServiceHook.Api.V1.Mappers
{
    public static class WorkItemCreatedMapper
    {
        /// <summary>
        /// Mapea una instancia de WorkItemEvent a un WorkItemDto.
        /// </summary>
        /// <param name="workItemEvent">La instancia de WorkItemEvent a mapear.</param>
        /// <returns>Un WorkItemDto con los valores extraídos de WorkItemEvent.</returns>
        public static WorkItemCreatedMessageDto ToWorkItemCreatedDto(this WorkItemEventRequest workItemEvent)
        {
            ArgumentNullException.ThrowIfNull(workItemEvent);
            var workItem = new WorkItemDto
            {
                WorkItemId = (int?)workItemEvent.Resource.Id,
                Title = workItemEvent.Resource.Fields?.SystemTitle?.NewValue,
                Description = WorkItemMapper.RemoveDivTags(workItemEvent.Resource.Fields?.SystemDescription?.NewValue ?? string.Empty),
                AssignedTo = workItemEvent.Resource.Fields?.CustomAssignedUser?.NewValue,
                CreatedAt = workItemEvent.CreatedDate,
                Priority = workItemEvent.Resource.Fields?.MicrosoftVstsCommonPriority?.NewValue ?? string.Empty,
                Company = workItemEvent.Resource.Fields?.CustomCompany?.NewValue ?? workItemEvent.Resource?.Revision?.Fields?.CustomCompany?.NewValue,
                Project = workItemEvent.Resource?.Fields?.SystemTeamProject?.NewValue,
                System = WorkItemMapper.RemoveSystemDescription(workItemEvent.Resource?.Fields?.CustomSystem?.NewValue ?? string.Empty),
                WorkItemType = workItemEvent.Resource?.Fields?.SystemWorkItemType?.NewValue ?? workItemEvent.Resource?.Revision?.Fields?.SystemWorkItemType?.NewValue,
                StartDate = WorkItemMapper.ConvertToDateTime(workItemEvent.Resource?.Fields?.MicrosoftVstsSchedulingStartDate?.NewValue),
                TargetDate = WorkItemMapper.ConvertToDateTime(workItemEvent.Resource?.Fields?.MicrosoftVstsSchedulingTargetDate?.NewValue),
                CreatedBy = workItemEvent.Resource?.Fields?.SystemCreatedBy?.NewValue,
                ProcessingType = workItemEvent.Resource?.Fields?.CustomProcessingType?.NewValue,
                ResponsibleUser = workItemEvent.Resource?.Fields?.CustomCreatedBy?.NewValue,
                ReportType = workItemEvent.Resource?.Fields?.CustomEpicType?.NewValue ??
                            workItemEvent.Resource?.Fields?.CustomTaskType?.NewValue ??
                            workItemEvent.Resource?.Fields?.CustomFeatureType?.NewValue ??
                            workItemEvent.Resource?.Fields?.CustomReportType?.NewValue ??
                            string.Empty,
            };

            return new WorkItemCreatedMessageDto()
            {
                Origin = WorkItemMapper.MapCollection(workItemEvent.ResourceContainers?.Collection?.BaseUrl?.OriginalString) ?? string.Empty,
                IterationPath = workItemEvent.Resource?.Fields?.SystemIterationPath?.NewValue ?? string.Empty,
                ProjectUrl = workItemEvent.ResourceContainers?.Project?.BaseUrl?.OriginalString ?? string.Empty,
                PublisherId = workItemEvent.PublisherId,
                RevisedBy = workItemEvent.Resource?.RevisedBy?.Name ?? workItemEvent.Resource?.Fields?.SystemChangedBy?.NewValue ?? string.Empty,
                Server = workItemEvent.ResourceContainers?.Server?.BaseUrl?.OriginalString ?? string.Empty,
                Revision = (int?)workItemEvent!.Resource!.Id ?? 0,
                CreatedAt = workItemEvent.CreatedDate.Date,
                RevisionId = (int?)workItemEvent.Resource!.Rev ?? 0,
                WorkItem = workItem,
                WorkItemFieldsUrl = workItemEvent.Resource?.Links?.Fields?.Href.OriginalString ?? string.Empty,
                WorkItemTypeUrl = workItemEvent.Resource?.Links?.WorkItemType?.Href.OriginalString ?? string.Empty,
                WorkItemUrl = workItemEvent.Resource?.Url?.OriginalString ?? string.Empty,
            };
        }

    }
}

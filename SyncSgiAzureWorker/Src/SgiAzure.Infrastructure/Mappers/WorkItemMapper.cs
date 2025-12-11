using SgiAzure.Domain.Entities;
using SgiAzure.Infrastructure.Settings;
using WorkItem = Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItem;

namespace SgiAzure.Infrastructure.Mappers
{
    public class WorkItemMapper
    {
        private readonly AzureFieldsConfiguration _fieldsConfiguration;

        public WorkItemMapper(AzureFieldsConfiguration fieldsConfiguration)
        {
            _fieldsConfiguration = fieldsConfiguration;
        }

        public WorkItemEntity MapToWorkItemEntity(WorkItem workItem)
        {
            return new WorkItemEntity()
            {
                WorkItemId = workItem.Id,
                RequirementId = ConvertToRequirementId(workItem),
                Title = ConvertToString(workItem, _fieldsConfiguration.TitleFieldName),
                Description = ConvertToString(workItem, _fieldsConfiguration.DescriptionFieldName),
                AssignedTo = ConvertToString(workItem, _fieldsConfiguration.AssignedUserFieldName),
                ResponsibleUser = ConvertToString(workItem, _fieldsConfiguration.CreatedByFieldName),
                Priority = ConvertToString(workItem, _fieldsConfiguration.PriorityFieldName),
                CreatedAt = ConvertToDateTimeOffset(workItem, _fieldsConfiguration.CreatedBy),
                StateEndDate = ConvertToNullableDateTime(workItem, _fieldsConfiguration.TargetDateFieldName),
                StartDate = ConvertToNullableDateTime(workItem, _fieldsConfiguration.StartDateFieldName),
                TargetDate = ConvertToNullableDateTime(workItem, _fieldsConfiguration.TargetDateFieldName),
                Area = ConvertToString(workItem, _fieldsConfiguration.SystemFieldName),
                ScheduledHours = ConvertToString(workItem, _fieldsConfiguration.SystemFieldName),
                Project = ConvertToString(workItem, _fieldsConfiguration.SystemFieldName),
                System = ConvertToString(workItem, _fieldsConfiguration.SystemFieldName),
                WorkItemType = ConvertToString(workItem, _fieldsConfiguration.ReportTypeFieldName),
                Company = ConvertToString(workItem, _fieldsConfiguration.CompanyFieldName),
                ReportType = ConvertToString(workItem, _fieldsConfiguration.ReportTypeFieldName),
                ProcessingType = ConvertToString(workItem, _fieldsConfiguration.ProcessingTypeFieldName),
            };
        }


        private int? ConvertToRequirementId(WorkItem workItem)
        {
            var fieldValue = ConvertToString(workItem, _fieldsConfiguration.RequirementField);
            return int.TryParse(fieldValue, out var requirementId) ? requirementId : (int?)null;
        }

        private string? ConvertToString(WorkItem workItem, string fieldName)
        {
            return workItem.Fields.ContainsKey(fieldName) ? workItem.Fields[fieldName]?.ToString() : null;
        }

        private DateTimeOffset ConvertToDateTimeOffset(WorkItem workItem, string fieldName)
        {
            var fieldValue = ConvertToString(workItem, fieldName);
            return DateTimeOffset.TryParse(fieldValue, out var dateTime) ? dateTime : default;
        }

        private DateTime? ConvertToNullableDateTime(WorkItem workItem, string fieldName)
        {
            var fieldValue = ConvertToString(workItem, fieldName);
            return DateTime.TryParse(fieldValue, out var dateTime) ? (DateTime?)dateTime : null;
        }
    }
}

using System.Text.Json.Serialization;

namespace SgiAzure.Infrastructure.Settings
{
    /// <summary>
    /// Configuración de los campos personalizados de Azure DevOps.
    /// </summary>
    public class AzureFieldsConfiguration
    {
        [JsonPropertyName("titleField")]
        public string TitleField { get; set; } = default!;

        public string TitleFieldName => ExtractFieldName(TitleField);

        [JsonPropertyName("descriptionField")]
        public string DescriptionField { get; set; } = default!;

        public string DescriptionFieldName => ExtractFieldName(DescriptionField);

        [JsonPropertyName("requirementField")]
        public string RequirementField { get; set; } = default!;

        public string RequirementFieldName => ExtractFieldName(RequirementField);

        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; } = default!;

        public string CreatedByFieldName => ExtractFieldName(CreatedBy);

        [JsonPropertyName("Reason")]
        public string Reason { get; set; } = default!;

        public string ReasonFieldName => ExtractFieldName(Reason);

        [JsonPropertyName("State")]
        public string State { get; set; } = default!;

        public string StateFieldName => ExtractFieldName(Reason);

        [JsonPropertyName("CommentCount")]
        public string CommentCount { get; set; } = default!;

        public string CommentCountFieldName => ExtractFieldName(CommentCount);

        [JsonPropertyName("reportType")]
        public string ReportType { get; set; } = default!;

        public string ReportTypeFieldName => ExtractFieldName(ReportType);

        [JsonPropertyName("processingType")]
        public string ProcessingType { get; set; } = default!;

        public string ProcessingTypeFieldName => ExtractFieldName(ProcessingType);

        [JsonPropertyName("companyField")]
        public string CompanyField { get; set; } = default!;

        public string CompanyFieldName => ExtractFieldName(CompanyField);

        [JsonPropertyName("systemField")]
        public string SystemField { get; set; } = default!;

        public string SystemFieldName => ExtractFieldName(SystemField);

        [JsonPropertyName("assignedUserField")]
        public string AssignedUserField { get; set; } = default!;

        public string AssignedUserFieldName => ExtractFieldName(AssignedUserField);

        [JsonPropertyName("assignToField")]
        public string AssignToField { get; set; } = default!;

        public string AssignToFieldName => ExtractFieldName(AssignToField);

        [JsonPropertyName("priorityField")]
        public string PriorityField { get; set; } = default!;

        public string PriorityFieldName => ExtractFieldName(PriorityField);

        [JsonPropertyName("startDateField")]
        public string StartDateField { get; set; } = default!;

        public string StartDateFieldName => ExtractFieldName(StartDateField);

        [JsonPropertyName("requiredField")]
        public string RequiredField { get; set; } = default!;

        public string RequiredFieldName => ExtractFieldName(RequiredField);

        [JsonPropertyName("targetDateField")]
        public string TargetDateField { get; set; } = default!;

        public string TargetDateFieldName => ExtractFieldName(TargetDateField);


        [JsonPropertyName("CommentField")]
        public string CommentField { get; set; } = default!;

        public string CommentFieldName => ExtractFieldName(CommentField);

        /// <summary>
        /// Extrae el nombre del campo del valor completo.
        /// </summary>
        /// <param name="fieldPath">Ruta completa del campo (por ejemplo, /fields/System.Title).</param>
        /// <returns>El nombre del campo (por ejemplo, System.Title).</returns>
        private static string ExtractFieldName(string fieldPath)
        {
            if (string.IsNullOrWhiteSpace(fieldPath))
            {
                return string.Empty;
            }
            var segments = fieldPath.Split('/');
            return segments.Length > 0 ? segments[^1] : fieldPath;
        }
    }
}

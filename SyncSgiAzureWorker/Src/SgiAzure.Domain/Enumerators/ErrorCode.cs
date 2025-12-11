using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SgiAzure.Domain.Enumerators
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ErrorCode
    {
        [EnumMember(Value ="ENTITY_NOT_FOUND")]
        EntityNotFound,

        [EnumMember(Value = "UNKNOWN")]
        Unknown = 0,

        [EnumMember(Value ="AZURE_NOT_AUTHORIZED")]
        AzureNotAuthorized,

        [EnumMember(Value ="AZURE_NOT_AUTHENTICATED")]
        AzureNotAuthenticated,

        [EnumMember(Value = "VALIDATION_FIELD")]
        ValidationField,

        [EnumMember(Value = "NOT_AUTHORIZD")]
        NotAuthorized,

        [EnumMember(Value = "EXTERNAL_SERVICE_ERROR")]
        ExternalServiceError,

        [EnumMember(Value = "INTERNAL_SERVICE_ERROR")]
        InternalServiceError,

        [EnumMember(Value ="AZURE_WORK_ITEM_DELETE_FAILED")]
        AzureWorkItemDeleteFailed,

        [EnumMember(Value ="AZURE_WORK_ITEM_NOT_FOUND")]
        AzureWorkItemNotFound
    }
}

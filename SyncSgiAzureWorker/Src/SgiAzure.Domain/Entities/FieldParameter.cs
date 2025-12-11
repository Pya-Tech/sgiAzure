using SgiAzure.Domain.Enum;
using SgiAzure.Domain.Interfaces.Entities;

namespace SgiAzure.Domain.Entities
{
    public class FieldParameter : IFieldParameter
    {
        public int? Id { get; set; }
        public required string Code { get; set; }
        public string? CodeValue { get; set; }
        public string? Description { get; set; }
        public Source SourceType { get; set; }
        public SgiAzureDataType DataType { get; set; } = SgiAzureDataType.String;
        public bool IsActive { get; set; } = true;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}

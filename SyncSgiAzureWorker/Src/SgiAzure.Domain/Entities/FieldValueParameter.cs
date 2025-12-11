using SgiAzure.Domain.Interfaces.Entities;

namespace SgiAzure.Domain.Entities
{
    public class FieldValueParameter : IFieldValueParameter
    {
        public int? Id { get; set; }
        public required string ValueCode { get; set; }
        public required string ValueDescription { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public int FieldParameterId { get; set; }
        public FieldParameter? FieldParameter { get; set; }
    }
}

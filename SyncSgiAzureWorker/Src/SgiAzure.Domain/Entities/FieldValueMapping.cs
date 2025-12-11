using SgiAzure.Domain.Interfaces.Entities;

namespace SgiAzure.Domain.Entities
{
    public class FieldValueMapping : IFieldValueMapping
    {
        public int? Id { get; set; }
        public int LocalValueId { get; set; }
        public int EquivalentValueId { get; set; }
        public int FieldParameterId { get; set; }
        public string? TargetSystem { get; set; }
        public int CustomerId { get; set; }
        public FieldParameter? FieldParameter { get; set; }
        public FieldValueParameter? LocalValue { get; set; }
        public FieldValueParameter? EquivalentValue { get; set; }
        public Customer? Customer { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}

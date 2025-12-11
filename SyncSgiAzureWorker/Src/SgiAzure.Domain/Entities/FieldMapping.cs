using SgiAzure.Domain.Interfaces.Entities;

namespace SgiAzure.Domain.Entities
{
    public class FieldMapping : IFieldMapping
    {
        public int? Id { get; set; }
        public int FieldSourceId { get; set; }
        public int FieldMappedId { get; set; }
        public int CustomerId { get; set; }
        public FieldParameter? FieldSource { get; set; }
        public FieldParameter? FieldMapped { get; set; }
        public Customer? Customer { get; set; }
        public bool Enabled { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}

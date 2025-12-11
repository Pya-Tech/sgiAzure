using SgiAzure.Domain.Interfaces.Entities;

namespace SgiAzure.Domain.Entities
{
    public class WorkArtifactMapping : IWorkArtifactMapping
    {
        public int? Id { get; set; }
        public bool Enabled { get; set; } = true;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? UpdatedAt { get; set; }
        public int CustomerId { get; set; }
        public int RequirementArtifactId { get; set; }
        public int WorkitemArtifactId { get; set; }
        public Customer? Customer { get; set; }
        public WorkArtifact? RequirementArtifact { get; set; }
        public WorkArtifact? WorkitemArtifact { get; set; }
    }
}

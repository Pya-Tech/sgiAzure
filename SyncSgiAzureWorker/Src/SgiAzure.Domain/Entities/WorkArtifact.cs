using SgiAzure.Domain.Enum;
using SgiAzure.Domain.Interfaces.Entities;

namespace SgiAzure.Domain.Entities
{
    public class WorkArtifact : IWorkArtifact
    {
        public int? Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public WorkArtifactType Type { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}

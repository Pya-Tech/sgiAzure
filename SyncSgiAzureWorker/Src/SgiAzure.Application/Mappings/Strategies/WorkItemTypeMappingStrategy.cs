using SgiAzure.Application.Interfaces.Mappings;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Exceptions;
using SgiAzure.Domain.Interfaces.Repositories;

namespace SgiAzure.Application.Mappings.Strategies
{
    /// <summary>
    /// Estrategia para mapear el tipo de Work Item a partir
    /// del tipo de reporte del SGI.
    /// </summary>
    public class WorkItemTypeMappingStrategy : IFieldMappingStrategy
    {
        public string FieldCode => "WorkItemType";

        private readonly IWorkArtifactMappingRepository<WorkArtifactMapping> _workArtifactMappingRepository;

        public WorkItemTypeMappingStrategy(
            IWorkArtifactMappingRepository<WorkArtifactMapping> workArtifactMappingRepository)
        {
            _workArtifactMappingRepository = workArtifactMappingRepository;
        }

        public async Task<string> MapAsync(string? value, int customerId, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            var mapping = await _workArtifactMappingRepository.GetByRequirementArtifactNameAsync(
                value,
                customerId,
                ct);

            if (mapping.WorkitemArtifact is null)
                throw new SgiAzureException("El mapeo de WorkItemType no contiene WorkitemArtifact.");

            return mapping.WorkitemArtifact.Name;
        }
    }
}

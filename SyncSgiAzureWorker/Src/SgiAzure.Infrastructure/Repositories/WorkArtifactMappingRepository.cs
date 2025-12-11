using Microsoft.EntityFrameworkCore;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Enumerators;
using SgiAzure.Domain.Exceptions;
using SgiAzure.Domain.Interfaces.Repositories;
using SgiAzure.Infrastructure.Databases.SgiAzure;
using System.Xml;

namespace SgiAzure.Infrastructure.Repositories
{
    public class WorkArtifactMappingRepository : IWorkArtifactMappingRepository<WorkArtifactMapping>
    {
        private readonly SgiAzureDbContext _context;

        public WorkArtifactMappingRepository(SgiAzureDbContext context)
        {
            _context = context;
        }

        public async Task<WorkArtifactMapping> CreateAsync(WorkArtifactMapping entity, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(entity);

            var created = await _context.WorkArtifactsMapping.AddAsync(entity, ct);
            await _context.SaveChangesAsync(ct);

            return created.Entity;
        }


        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            var mapping = await _context.WorkArtifactsMapping.FindAsync([id], ct)
                ?? throw new SgiAzureException(
                    $"No existe WorkArtifactMapping con el id '{id}'",
                    ErrorCode.EntityNotFound);

            _context.WorkArtifactsMapping.Remove(mapping);
            await _context.SaveChangesAsync(ct);
        }

        public async Task DisableAsync(int id, CancellationToken ct = default)
        {
            var mapping = await _context.WorkArtifactsMapping.FindAsync([id], ct)
                ?? throw new SgiAzureException(
                    $"No existe WorkArtifactMapping con el id '{id}'",
                    ErrorCode.EntityNotFound);

            mapping.Enabled = false;
            mapping.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.SaveChangesAsync(ct);
        }

        public async Task<IEnumerable<WorkArtifactMapping>> GetByCustomerIdAsync(int customerId, CancellationToken ct = default)
        {
            var mappings = await _context.WorkArtifactsMapping
                .AsNoTracking()
                .Where(x => x.CustomerId == customerId && x.Enabled)
                .OrderBy(x => x.RequirementArtifactId)
                .ToListAsync(ct);

            return mappings;
        }
        public async Task<WorkArtifactMapping> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var mapping = await _context.WorkArtifactsMapping.FindAsync([id], ct);

            return mapping is null
                ? throw new SgiAzureException(
                    $"No existe WorkArtifactMapping con id '{id}'",
                    ErrorCode.EntityNotFound)
                : mapping;
        }

        public async Task<WorkArtifactMapping> GetByRequirementArtifactIdAsync(
            int requirementArtifactId,
            int customerId,
            CancellationToken ct = default)
        {
            var mapping = await _context.WorkArtifactsMapping
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.RequirementArtifactId == requirementArtifactId &&
                    x.CustomerId == customerId &&
                    x.Enabled,
                    ct);

            return mapping is null
                ? throw new SgiAzureException(
                    $"No existe mapeo para RequirementArtifactId '{requirementArtifactId}' y CustomerId '{customerId}'",
                    ErrorCode.EntityNotFound)
                : mapping;
        }


        public async Task<WorkArtifactMapping> GetByWorkItemArtifactIdAsync(
            int workItemArtifactId,
            int customerId,
            CancellationToken ct = default)
        {
            var mapping = await _context.WorkArtifactsMapping
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.WorkitemArtifactId == workItemArtifactId &&
                    x.CustomerId == customerId &&
                    x.Enabled,
                    ct);

            return mapping is null
                ? throw new SgiAzureException(
                    $"No existe mapeo para WorkItemArtifactId '{workItemArtifactId}' y CustomerId '{customerId}'",
                    ErrorCode.EntityNotFound)
                : mapping;
        }

        public async Task<WorkArtifactMapping> GetByRequirementArtifactNameAsync(string artifactName, int customerId, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(nameof(artifactName));

            WorkArtifactMapping workArtifact = await _context.WorkArtifactsMapping
                .Include(x => x.RequirementArtifact)
                .Include(x => x.Customer)
                .Include(x => x.WorkitemArtifact)
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.RequirementArtifact != null &&
                    x.RequirementArtifact.Name == artifactName &&
                    x.CustomerId == customerId &&
                    x.Enabled)
                ?? throw new SgiAzureException($"No existe un mapeo para el artefacto de nombre '{artifactName}'");

            return workArtifact;
        }

        public async Task<WorkArtifactMapping> GetByWorkItemArtifactNameAsync(string artifactName, int customerId, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(nameof(artifactName));

            WorkArtifactMapping workArtifact = await _context.WorkArtifactsMapping
                .Include(x => x.RequirementArtifact)
                .Include(x => x.Customer)
                .Include(x => x.WorkitemArtifact)
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.WorkitemArtifact != null &&
                    x.WorkitemArtifact.Name == artifactName &&
                    x.CustomerId == customerId &&
                    x.Enabled)
                ?? throw new SgiAzureException($"No existe un mapeo para el artefacto de nombre '{artifactName}'");

            return workArtifact;
        }

        public async Task UpdateAsync(WorkArtifactMapping entity, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(entity);

            var existing = await _context.WorkArtifactsMapping.FindAsync([entity.Id], ct)
                ?? throw new SgiAzureException(
                    $"No se puede actualizar. No existe WorkArtifactMapping con id '{entity.Id}'",
                    ErrorCode.EntityNotFound);

            existing.Enabled = entity.Enabled;
            existing.CustomerId = entity.CustomerId;
            existing.RequirementArtifactId = entity.RequirementArtifactId;
            existing.WorkitemArtifactId = entity.WorkitemArtifactId;
            existing.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.SaveChangesAsync(ct);
        }
    }
}

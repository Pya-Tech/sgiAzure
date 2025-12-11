using Microsoft.EntityFrameworkCore;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Enum;
using SgiAzure.Domain.Enumerators;
using SgiAzure.Domain.Exceptions;
using SgiAzure.Domain.Interfaces.Repositories;
using SgiAzure.Infrastructure.Databases.SgiAzure;

namespace SgiAzure.Infrastructure.Repositories
{
    public class WorkArtifactRepository : IWorkArtifactRepository<WorkArtifact>
    {
        private readonly SgiAzureDbContext _context;

        public WorkArtifactRepository(SgiAzureDbContext context)
        {
            _context = context;
        }

        public async Task<WorkArtifact> CreateAsync(WorkArtifact entity, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(entity);

            var created = await _context.WorkArtifacts.AddAsync(entity, ct);
            await _context.SaveChangesAsync(ct);

            return created.Entity;
        }
        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            var artifact = await _context.WorkArtifacts.FindAsync(new object?[] { id }, ct)
                ?? throw new SgiAzureException(
                    $"No existe WorkArtifact con id '{id}'",
                    ErrorCode.EntityNotFound);

            _context.WorkArtifacts.Remove(artifact);
            await _context.SaveChangesAsync(ct);
        }

        public async Task<IEnumerable<WorkArtifact>> GetAllAsync(CancellationToken ct = default)
        {
            var artifacts = await _context.WorkArtifacts
                .AsNoTracking()
                .OrderBy(x => x.Type)
                .ThenBy(x => x.Name)
                .ToListAsync(ct);

            return artifacts;
        }

        public async Task<WorkArtifact> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var artifact = await _context.WorkArtifacts.FindAsync(new object?[] { id }, ct);

            return artifact is null
                ? throw new SgiAzureException(
                    $"No existe WorkArtifact con id '{id}'",
                    ErrorCode.EntityNotFound)
                : artifact;
        }
        public async Task<WorkArtifact> GetByNameAsync(string name, CancellationToken ct = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            var artifact = await _context.WorkArtifacts
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Name == name, ct);

            return artifact is null
                ? throw new SgiAzureException(
                    $"No existe WorkArtifact con el nombre '{name}'",
                    ErrorCode.EntityNotFound)
                : artifact;
        }

        public async Task<IEnumerable<WorkArtifact>> GetByTypeAsync(int type, CancellationToken ct = default)
        {
            if (!Enum.IsDefined(typeof(WorkArtifactType), type))
                throw new SgiAzureException(
                    $"Tipo '{type}' no es un valor válido de WorkArtifactType",
                    ErrorCode.ValidationField);

            var typed = await _context.WorkArtifacts
                .AsNoTracking()
                .Where(x => x.Type == (WorkArtifactType)type)
                .OrderBy(x => x.Name)
                .ToListAsync(ct);

            return typed;
        }

        public async Task UpdateAsync(WorkArtifact entity, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(entity);

            var existing = await _context.WorkArtifacts.FindAsync(new object?[] { entity.Id }, ct)
                ?? throw new SgiAzureException(
                    $"No se puede actualizar. No existe WorkArtifact con id '{entity.Id}'",
                    ErrorCode.EntityNotFound);

            existing.Name = entity.Name;
            existing.Description = entity.Description;
            existing.Type = entity.Type;
            existing.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.SaveChangesAsync(ct);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Enumerators;
using SgiAzure.Domain.Exceptions;
using SgiAzure.Domain.Interfaces.Repositories;
using SgiAzure.Infrastructure.Databases.SgiAzure;

namespace SgiAzure.Infrastructure.Repositories
{
    public class FieldValueMappingRepository : IFieldValueMappingRepository<FieldValueMapping>
    {
        private readonly SgiAzureDbContext _context;

        public FieldValueMappingRepository(SgiAzureDbContext context)
        {
            _context = context;
        }

        public async Task<FieldValueMapping> CreateAsync(FieldValueMapping entity, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(entity);

            var created = await _context.FieldValueMappings.AddAsync(entity, ct);
            await _context.SaveChangesAsync(ct);

            return created.Entity;
        }

        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            var mapping = await _context.FieldValueMappings.FindAsync([id], ct)
                ?? throw new SgiAzureException(
                    $"No existe mapeo de valores con el identificador '{id}'",
                    ErrorCode.EntityNotFound
                );

            _context.FieldValueMappings.Remove(mapping);
            await _context.SaveChangesAsync(ct);
        }

        public async Task<FieldValueMapping> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var mapping = await _context.FieldValueMappings.FindAsync([id], ct);

            return mapping is null
                ? throw new SgiAzureException($"No existe mapeo para el id '{id}'", ErrorCode.EntityNotFound)
                : mapping;
        }

        public async Task<FieldValueMapping> GetMappingByLocalValueAsync(
            int localValueId,
            int fieldParameterId,
            int customerId,
            CancellationToken ct = default)
        {
            var mapping = await _context.FieldValueMappings
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    x => x.LocalValueId == localValueId &&
                         x.FieldParameterId == fieldParameterId &&
                         x.CustomerId == customerId,
                    ct);

            return mapping is null
                ? throw new SgiAzureException(
                    $"No existe mapeo para LocalValueId='{localValueId}', FieldParameterId='{fieldParameterId}', Customer='{customerId}'",
                    ErrorCode.EntityNotFound)
                : mapping;
        }

        public async Task<FieldValueMapping> GetMappingByEquivalentValueAsync(
            int equivalentValueId,
            int fieldParameterId,
            int customerId,
            CancellationToken ct = default)
        {
            var mapping = await _context.FieldValueMappings
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    x => x.EquivalentValueId == equivalentValueId &&
                         x.FieldParameterId == fieldParameterId &&
                         x.CustomerId == customerId,
                    ct);

            return mapping is null
                ? throw new SgiAzureException(
                    $"No existe mapeo para EquivalentValueId='{equivalentValueId}', FieldParameterId='{fieldParameterId}', Customer='{customerId}'",
                    ErrorCode.EntityNotFound)
                : mapping;
        }

        public async Task<IEnumerable<FieldValueMapping>> GetMappingsByFieldParameterAsync(
            int fieldParameterId,
            int customerId,
            CancellationToken ct = default)
        {
            var mappings = await _context.FieldValueMappings
                .AsNoTracking()
                .Where(x =>
                    x.FieldParameterId == fieldParameterId &&
                    x.CustomerId == customerId)
                .ToListAsync(ct);

            return mappings;
        }


        public async Task UpdateAsync(FieldValueMapping entity, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(entity);

            var existing = await _context.FieldValueMappings.FindAsync(new object?[] { entity.Id }, ct)
                ?? throw new SgiAzureException(
                    $"No existe mapeo con el Id '{entity.Id}'",
                    ErrorCode.EntityNotFound);

            existing.LocalValueId = entity.LocalValueId;
            existing.EquivalentValueId = entity.EquivalentValueId;
            existing.FieldParameterId = entity.FieldParameterId;
            existing.CustomerId = entity.CustomerId;
            existing.TargetSystem = entity.TargetSystem;
            existing.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.SaveChangesAsync(ct);
        }

        public async Task<FieldValueMapping> GetMappingByLocalValueCodeAsync(
            string localValueCode,
            int fieldParameterId,
            int customerId,
            CancellationToken ct = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(localValueCode);

            var mapping = await _context.FieldValueMappings
                .Include(x => x.LocalValue)
                .Include(x => x.EquivalentValue)
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.LocalValue != null &&
                    x.CustomerId == customerId &&
                    x.FieldParameterId == fieldParameterId &&
                    x.LocalValue.ValueCode == localValueCode,
                    ct);

            if (mapping is null)
                throw new SgiAzureException(
                    $"No existe mapeo SGI-Azure para el código local '{localValueCode}', parámetro '{fieldParameterId}' y cliente '{customerId}'.",
                    ErrorCode.EntityNotFound);

            return mapping;
        }

        public async Task<FieldValueMapping> GetMappingByEquivalentValueCodeAsync(
            string equivalentValueCode,
            int fieldParameterId,
            int customerId,
            CancellationToken ct = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(equivalentValueCode);

            var mapping = await _context.FieldValueMappings
                .Include(x => x.LocalValue)
                .Include(x => x.EquivalentValue)
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.EquivalentValue != null &&    
                    x.CustomerId == customerId &&
                    x.FieldParameterId == fieldParameterId &&
                    x.EquivalentValue.ValueCode == equivalentValueCode,
                    ct);

            if (mapping is null)
                throw new SgiAzureException(
                    $"No existe mapeo Azure → SGI para el código equivalente '{equivalentValueCode}', parámetro '{fieldParameterId}' y cliente '{customerId}'.",
                    ErrorCode.EntityNotFound);

            return mapping;
        }

    }
}

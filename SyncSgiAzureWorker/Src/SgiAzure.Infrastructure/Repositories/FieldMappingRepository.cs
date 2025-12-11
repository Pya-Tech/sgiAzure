using Microsoft.EntityFrameworkCore;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Enumerators;
using SgiAzure.Domain.Exceptions;
using SgiAzure.Domain.Interfaces.Repositories;
using SgiAzure.Infrastructure.Databases.SgiAzure;

namespace SgiAzure.Infrastructure.Repositories
{
    /// <summary>
    /// FieldMappingRepository
    /// </summary>
    public class FieldMappingRepository : IFieldMappingRepository<FieldMapping>
    {
        private readonly SgiAzureDbContext _sgiAzureDbContext;

        public FieldMappingRepository(SgiAzureDbContext sgiAzureDbContext) { 
            _sgiAzureDbContext = sgiAzureDbContext;
        }

        public async Task<FieldMapping> CreateAsync(FieldMapping entity, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(entity);
            var created = await _sgiAzureDbContext.FieldMappings.AddAsync(entity, cancellationToken:ct);
            await _sgiAzureDbContext.SaveChangesAsync(ct);
            return created.Entity;

        }
        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            var fieldMapping = await _sgiAzureDbContext.FieldMappings.FindAsync([id], ct) ?? 
                throw new SgiAzureException($"No existe registro con el identificador '{id}'", ErrorCode.EntityNotFound);

            _sgiAzureDbContext.FieldMappings.Remove(fieldMapping);
            await _sgiAzureDbContext.SaveChangesAsync(ct);
        }

        public async Task DisableAsync(int id, CancellationToken ct = default)
        {
            FieldMapping fieldMapping = await _sgiAzureDbContext.FieldMappings.FindAsync([id], ct) ??
                throw new SgiAzureException($"No existe registro con el identificador '{id}'", ErrorCode.EntityNotFound);
            fieldMapping.Enabled = false;
            fieldMapping.UpdatedAt = DateTimeOffset.UtcNow;

            await _sgiAzureDbContext.SaveChangesAsync(ct);
            
        }

        public async Task<IEnumerable<FieldMapping>> GetByCustomerIdAsync(int customerId, CancellationToken ct = default)
        {
            IEnumerable<FieldMapping> fieldMapping = await _sgiAzureDbContext.FieldMappings
                .AsNoTracking()
                .Where(x => x.CustomerId == customerId && x.Enabled)
                .ToListAsync(ct); 
            return fieldMapping;
        }

        public async Task<FieldMapping> GetByIdAsync(int id, CancellationToken ct = default)
        {
            FieldMapping? fieldMapping = await _sgiAzureDbContext.FieldMappings.FindAsync([id], ct);
            return fieldMapping is null
                ? throw new SgiAzureException($"No existe registro para el identificador '{id}'")
                : fieldMapping;
        }

        public async Task<FieldMapping> GetByMappedIdAsync(int mappedId, int customerId, CancellationToken ct = default)
        {
            var fieldMapping = await _sgiAzureDbContext.FieldMappings
                 .AsNoTracking()
                 .FirstOrDefaultAsync((x) => x.FieldMappedId == mappedId && x.CustomerId == customerId && x.Enabled, ct);

            return fieldMapping is null
                ? throw new SgiAzureException($"No existe registro para el identificador '{mappedId}' y cliente '{customerId}'")
                : fieldMapping;
        }

        public async Task<FieldMapping> GetBySourceIdAsync(int sourceId, int customerId, CancellationToken ct = default)
        {
            var fieldMapping = await _sgiAzureDbContext.FieldMappings
                .AsNoTracking()
                .FirstOrDefaultAsync((x)=>x.FieldSourceId == sourceId && x.CustomerId ==customerId && x.Enabled, ct);


            return fieldMapping is null
                ? throw new SgiAzureException($"No existe registro para el identificador '{sourceId}' y cliente '{customerId}'")
                : fieldMapping;
        }

        public async Task UpdateAsync(FieldMapping entity, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(entity);

            var existing = await _sgiAzureDbContext.FieldMappings.FindAsync(new object?[] { entity.Id }, ct)
                ?? throw new SgiAzureException(
                    $"No existe registro con el identificador '{entity.Id}'",
                    ErrorCode.EntityNotFound
                );

            existing.FieldSourceId = entity.FieldSourceId;
            existing.FieldMappedId = entity.FieldMappedId;
            existing.CustomerId = entity.CustomerId;
            existing.Enabled = entity.Enabled;
            existing.UpdatedAt = DateTimeOffset.UtcNow;

            await _sgiAzureDbContext.SaveChangesAsync(ct);
        }

    }
}

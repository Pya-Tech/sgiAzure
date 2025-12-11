using Microsoft.EntityFrameworkCore;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Enumerators;
using SgiAzure.Domain.Exceptions;
using SgiAzure.Domain.Interfaces.Repositories;
using SgiAzure.Infrastructure.Databases.SgiAzure;

namespace SgiAzure.Infrastructure.Repositories
{
    public class FieldValueParameterRepository : IFieldValueParameterRepository<FieldValueParameter>
    {
        private readonly SgiAzureDbContext _context;

        public FieldValueParameterRepository(SgiAzureDbContext context)
        {
            _context = context;
        }
        public async Task<FieldValueParameter> CreateAsync(FieldValueParameter entity, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(entity);

            var created = await _context.FieldValues.AddAsync(entity, ct);
            await _context.SaveChangesAsync(ct);

            return created.Entity;
        }

        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            var valueParameter = await _context.FieldValues.FindAsync([id], ct)
                ?? throw new SgiAzureException(
                    $"No existe registro en field_value_parameters con id '{id}'",
                    ErrorCode.EntityNotFound);

            _context.FieldValues.Remove(valueParameter);
            await _context.SaveChangesAsync(ct);
        }

        public async Task DisableAsync(int id, CancellationToken ct = default)
        {
            var entity = await _context.FieldValues.FindAsync([id], ct)
                ?? throw new SgiAzureException(
                    $"No existe registro con id '{id}'",
                    ErrorCode.EntityNotFound);

            entity.IsActive = false;
            entity.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.SaveChangesAsync(ct);
        }

        public async Task<FieldValueParameter> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var entity = await _context.FieldValues.FindAsync([id], ct);

            return entity is null
                ? throw new SgiAzureException(
                    $"No existe FieldValueParameter con id '{id}'",
                    ErrorCode.EntityNotFound)
                : entity;
        }

        public async Task<FieldValueParameter> GetByValueCodeAsync(
            string valueCode,
            int fieldParameterId,
            CancellationToken ct = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(valueCode);

            var value = await _context.FieldValues
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    x => x.ValueCode == valueCode &&
                         x.FieldParameterId == fieldParameterId &&
                         x.IsActive,
                    ct);

            return value is null
                ? throw new SgiAzureException(
                    $"No existe valor '{valueCode}' asignado al FieldParameter '{fieldParameterId}'",
                    ErrorCode.EntityNotFound)
                : value;
        }

        public async Task<IEnumerable<FieldValueParameter>> GetByFieldParameterIdAsync(
            int fieldParameterId,
            CancellationToken ct = default)
        {
            var values = await _context.FieldValues
                .AsNoTracking()
                .Where(x => x.FieldParameterId == fieldParameterId && x.IsActive)
                .ToListAsync(ct);

            return values;
        }

        public async Task UpdateAsync(FieldValueParameter entity, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(entity);

            var existing = await _context.FieldValues.FindAsync(new object?[] { entity.Id }, ct)
                ?? throw new SgiAzureException(
                    $"No existe registro para actualizar con id '{entity.Id}'",
                    ErrorCode.EntityNotFound);

            existing.ValueCode = entity.ValueCode;
            existing.ValueDescription = entity.ValueDescription;
            existing.FieldParameterId = entity.FieldParameterId;
            existing.IsActive = entity.IsActive;
            existing.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.SaveChangesAsync(ct);
        }
    }
}

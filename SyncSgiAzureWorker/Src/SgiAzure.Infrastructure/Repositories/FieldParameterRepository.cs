using Microsoft.EntityFrameworkCore;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Enumerators;
using SgiAzure.Domain.Exceptions;
using SgiAzure.Domain.Interfaces.Repositories;
using SgiAzure.Infrastructure.Databases.SgiAzure;

namespace SgiAzure.Infrastructure.Repositories
{
    public class FieldParameterRepository : IFieldParameterRepository<FieldParameter>
    {
        private readonly SgiAzureDbContext _context;

        public FieldParameterRepository(SgiAzureDbContext context)
        {
            _context = context;
        }

        public async Task<FieldParameter> CreateFieldParameter(FieldParameter entity, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(entity);

            var created = await _context.FieldParameters.AddAsync(entity, ct);
            await _context.SaveChangesAsync(ct);

            return created.Entity;
        }

        public async Task<FieldParameter> GetFieldParameterById(int id, CancellationToken ct = default)
        {
            var parameter = await _context.FieldParameters.FindAsync(new object?[] { id }, ct);

            return parameter is null
                ? throw new SgiAzureException($"No existe parámetro con el Id '{id}'", ErrorCode.EntityNotFound)
                : parameter;
        }

        public async Task<FieldParameter> GetFieldParameterByCode(string code, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new SgiAzureException("El código del parámetro no puede ser nulo o vacío", ErrorCode.ValidationField);

            var parameter = await _context.FieldParameters
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Code == code, ct);

            return parameter is null
                ? throw new SgiAzureException($"No existe FieldParameter con el código '{code}'", ErrorCode.EntityNotFound)
                : parameter;
        }

 
        public async Task<FieldParameter> GetFieldParameterByCodeValue(string codeValue, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(codeValue))
                throw new SgiAzureException("El CodeValue no puede ser nulo o vacío", ErrorCode.ValidationField);

            var parameter = await _context.FieldParameters
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.CodeValue == codeValue, ct);

            return parameter is null
                ? throw new SgiAzureException($"No existe FieldParameter con CodeValue '{codeValue}'", ErrorCode.EntityNotFound)
                : parameter;
        }

        public async Task<IEnumerable<FieldParameter>> GetAll()
        {
            return await _context.FieldParameters
                .AsNoTracking()
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task DisabledFieldParameter(int id, CancellationToken ct = default)
        {
            var parameter = await _context.FieldParameters.FindAsync(new object?[] { id }, ct)
                ?? throw new SgiAzureException($"No existe parámetro con Id '{id}'", ErrorCode.EntityNotFound);

            parameter.IsActive = false;
            parameter.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.SaveChangesAsync(ct);
        }


        public async Task EnabledFieldParameter(int id, CancellationToken ct = default)
        {
            var parameter = await _context.FieldParameters.FindAsync(new object?[] { id }, ct)
                ?? throw new SgiAzureException($"No existe parámetro con Id '{id}'", ErrorCode.EntityNotFound);

            parameter.IsActive = true;
            parameter.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.SaveChangesAsync(ct);
        }

        public async Task<FieldParameter> UpdateFieldParameter(int id, FieldParameter entity, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(entity);

            var existing = await _context.FieldParameters.FindAsync(new object?[] { id }, ct)
                ?? throw new SgiAzureException($"No existe parámetro con Id '{id}'", ErrorCode.EntityNotFound);

            existing.Code = entity.Code;
            existing.CodeValue = entity.CodeValue;
            existing.Description = entity.Description;
            existing.SourceType = entity.SourceType;
            existing.DataType = entity.DataType;
            existing.IsActive = entity.IsActive;
            existing.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.SaveChangesAsync(ct);

            return existing;
        }
    }
}

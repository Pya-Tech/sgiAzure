using SgiAzure.Application.Interfaces.Mappings;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Exceptions;
using SgiAzure.Domain.Interfaces.Repositories;

namespace SgiAzure.Application.Mappings.Strategies
{
    /// <summary>
    /// Estrategia para mapear el sistema (SGI, GEN, SAF, etc.)
    /// de SGI hacia Azure.
    /// </summary>
    public class SystemMappingStrategy : IFieldMappingStrategy
    {
        public string FieldCode => "System";

        private readonly IFieldValueMappingRepository<FieldValueMapping> _valueMappingRepository;
        private readonly IFieldParameterRepository<FieldParameter> _fieldParameterRepository;

        public SystemMappingStrategy(
            IFieldValueMappingRepository<FieldValueMapping> valueMappingRepository,
            IFieldParameterRepository<FieldParameter> fieldParameterRepository)
        {
            _valueMappingRepository = valueMappingRepository;
            _fieldParameterRepository = fieldParameterRepository;
        }

        public async Task<string> MapAsync(string? value, int customerId, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            var fieldParameter = await _fieldParameterRepository
                .GetFieldParameterByCode(FieldCode, ct);

            if (fieldParameter.Id is null)
                throw new SgiAzureException($"El parámetro '{FieldCode}' no tiene Id asignado.");

            var mapping = await _valueMappingRepository.GetMappingByLocalValueCodeAsync(
                value,
                fieldParameter.Id.Value,
                customerId,
                ct);

            if (mapping.EquivalentValue is null)
                throw new SgiAzureException("El mapeo de sistema no contiene EquivalentValue.");

            return $"{mapping.EquivalentValue.ValueCode} - {mapping.EquivalentValue.ValueDescription}";
        }
    }
}

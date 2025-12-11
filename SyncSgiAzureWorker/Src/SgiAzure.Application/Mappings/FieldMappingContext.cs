using SgiAzure.Application.Interfaces.Mappings;

namespace SgiAzure.Application.Mappings
{
    /// <summary>
    /// Implementación por defecto del contexto de mapeo de campos.
    /// Resuelve dinámicamente la estrategia apropiada según el código del campo.
    /// </summary>
    public class FieldMappingContext : IFieldMappingContext
    {
        private readonly IReadOnlyDictionary<string, IFieldMappingStrategy> _strategies;

        public FieldMappingContext(IEnumerable<IFieldMappingStrategy> strategies)
        {
            _strategies = strategies
                .ToDictionary(s => s.FieldCode, s => s, StringComparer.OrdinalIgnoreCase);
        }

        public Task<string> MapAsync(string fieldCode, string? value, int customerId, CancellationToken ct = default)
        {
            if (!_strategies.TryGetValue(fieldCode, out var strategy))
            {
                throw new InvalidOperationException(
                    $"No existe una estrategia de mapeo registrada para el campo '{fieldCode}'.");
            }

            return strategy.MapAsync(value, customerId, ct);
        }
    }
}

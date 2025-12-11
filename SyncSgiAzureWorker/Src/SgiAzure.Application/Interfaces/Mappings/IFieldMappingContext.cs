namespace SgiAzure.Application.Interfaces.Mappings
{
    /// <summary>
    /// Orquesta las distintas estrategias de mapeo de campos.
    /// Permite resolver el valor equivalente dado un código de campo.
    /// </summary>
    public interface IFieldMappingContext
    {
        /// <summary>
        /// Resuelve el mapeo para un campo dado.
        /// </summary>
        /// <param name="fieldCode">Código del campo (Priority, System, etc.).</param>
        /// <param name="value">Valor local a mapear.</param>
        /// <param name="customerId">Cliente al que pertenece la configuración.</param>
        /// <param name="ct">Token de cancelación.</param>
        /// <returns>Valor mapeado.</returns>
        Task<string> MapAsync(string fieldCode, string? value, int customerId, CancellationToken ct = default);
    }
}

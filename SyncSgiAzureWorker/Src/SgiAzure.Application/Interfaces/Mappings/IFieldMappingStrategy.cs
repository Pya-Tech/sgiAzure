namespace SgiAzure.Application.Interfaces.Mappings
{
    /// <summary>
    /// Define una estrategia de mapeo para un campo específico
    /// (Priority, System, ReportType, etc.).
    /// </summary>
    public interface IFieldMappingStrategy
    {
        /// <summary>
        /// Código lógico del campo al que aplica esta estrategia.
        /// Ejemplos: "Priority", "System", "ReportedRequirementType", "ProcessRequirementType", "WorkItemType".
        /// </summary>
        string FieldCode { get; }

        /// <summary>
        /// Ejecuta el mapeo del valor local al valor equivalente,
        /// en función del cliente.
        /// </summary>
        /// <param name="value">Valor local (por ejemplo, código en SGI).</param>
        /// <param name="customerId">Identificador del cliente.</param>
        /// <param name="ct">Token de cancelación opcional.</param>
        /// <returns>Cadena representando el valor mapeado para el destino (Azure).</returns>
        Task<string> MapAsync(string? value, int customerId, CancellationToken ct = default);
    }
}

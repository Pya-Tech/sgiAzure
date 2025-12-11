namespace SgiAzure.Domain.Interfaces.Database
{
    public interface IDatabaseTransactionManager
    {
        /// <summary>
        /// Inicia una nueva transacción de la base de datos Sgi
        /// </summary>
        /// <returns>Una instancia de IDatabaseTransaction.</returns>
        Task<IDatabaseTransaction> BeginSgiTransactionAsync(CancellationToken ct = default);

        /// <summary>
        /// Inicia una nueva transacción de la base de datos SgiAzure
        /// </summary>
        /// <returns>Una instancia de IDatabaseTransaction.</returns>
        Task<IDatabaseTransaction> BeginSgiAzureTransactionAsync(CancellationToken ct = default);
    }
}

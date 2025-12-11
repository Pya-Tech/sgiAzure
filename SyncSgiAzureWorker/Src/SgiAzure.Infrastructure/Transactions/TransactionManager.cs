using SgiAzure.Domain.Interfaces.Database;
using SgiAzure.Infrastructure.Databases.Sgi;
using SgiAzure.Infrastructure.Databases.SgiAzure;

namespace SgiAzure.Infrastructure.Transactions
{
    /// <summary>
    /// Clase responsable de gestionar las transacciones de base de datos para los contextos de SGI y SGI Azure.
    /// Implementa la interfaz IDatabaseTransactionManager para proporcionar métodos de inicio de transacciones.
    /// </summary>
    public class TransactionManager : IDatabaseTransactionManager
    {
        /// <summary>
        /// Contexto de la base de datos del SGI
        /// </summary>
        private readonly SgiDbContext _sgiContext;

        /// <summary>
        /// Contexto de la base de datos interna del worker
        /// </summary>
        private readonly SgiAzureDbContext _sgiAzureContext;

        /// <summary>
        /// Constructor de la clase TransactionManager.
        /// Inicializa los contextos de base de datos necesarios para gestionar las transacciones.
        /// </summary>
        /// <param name="sgiContext">Contexto de base de datos para SGI.</param>
        /// <param name="sgiAzureContext">Contexto de base de datos para SGI Azure.</param>
        public TransactionManager(SgiDbContext sgiContext, SgiAzureDbContext sgiAzureContext)
        {
            _sgiContext = sgiContext ?? throw new ArgumentNullException(nameof(sgiContext));
            _sgiAzureContext = sgiAzureContext ?? throw new ArgumentNullException(nameof(sgiAzureContext));
        }

        /// <summary>
        /// Inicia una transacción asincrónica en el contexto de base de datos de SGI Azure.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica. El resultado es una interfaz IDatabaseTransaction que encapsula la transacción iniciada.</returns>
        public async Task<IDatabaseTransaction> BeginSgiAzureTransactionAsync(CancellationToken ct = default)
        {
            var transaction = await _sgiAzureContext.Database.BeginTransactionAsync(ct);
            return new DatabaseTransaction(transaction);
        }

        /// <summary>
        /// Inicia una transacción asincrónica en el contexto de base de datos de SGI.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica. El resultado es una interfaz IDatabaseTransaction que encapsula la transacción iniciada.</returns>
        public async Task<IDatabaseTransaction> BeginSgiTransactionAsync(CancellationToken ct = default)
        {
            var transaction = await _sgiContext.Database.BeginTransactionAsync(ct);
            return new DatabaseTransaction(transaction);
        }
    }
}
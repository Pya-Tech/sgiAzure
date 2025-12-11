using Microsoft.EntityFrameworkCore.Storage;
using SgiAzure.Domain.Interfaces.Database;

namespace SgiAzure.Infrastructure.Transactions
{
    public class DatabaseTransaction : IDatabaseTransaction
    {
        private readonly IDbContextTransaction _transaction;

        public DatabaseTransaction(IDbContextTransaction transaction)
        {
            _transaction = transaction;
        }

        public async Task CommitAsync(CancellationToken ct = default)
        {
            await _transaction.CommitAsync(ct);
        }

        public async Task RollbackAsync(CancellationToken ct = default)
        {
            await _transaction.RollbackAsync(ct);
        }

        public async ValueTask DisposeAsync()
        {
            await _transaction.DisposeAsync();
        }
    }
}

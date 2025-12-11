namespace SgiAzure.Domain.Interfaces.Database
{
    public interface IDatabaseTransaction: IAsyncDisposable
    {
        Task CommitAsync(CancellationToken ct = default);

        Task RollbackAsync(CancellationToken ct = default);
    }
}

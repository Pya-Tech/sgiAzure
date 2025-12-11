using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgiAzure.Domain.Interfaces.UnitOfWork
{
    public interface ISgiUnitOfWork: IAsyncDisposable
    {
        IRequirementRepository<Requirement> Requirements { get; }

        Task BeginAsync(CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);
    }
}

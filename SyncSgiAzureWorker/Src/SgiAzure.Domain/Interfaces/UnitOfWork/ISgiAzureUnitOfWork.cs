using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgiAzure.Domain.Interfaces.UnitOfWork
{
    public interface ISgiAzureUnitOfWork: IAsyncDisposable
    {
        /// <summary>
        /// Repositorio de la relación Requerimiento-WorkItem
        /// </summary>
        IRequirementWorkItemRepository<RequirementWorkItem> RequirementWorkItems { get; }

        /// <summary>
        /// Repositorio de clientes
        /// </summary>
        ICustomerRepository<Customer> CustomerRepository { get; }

        /// <summary>
        /// Repositorio de histórico de cambios
        /// </summary>
        IChangelogRepository<Changelog> ChangelogRepository { get; }

        Task BeginAsync(CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);

    }
}

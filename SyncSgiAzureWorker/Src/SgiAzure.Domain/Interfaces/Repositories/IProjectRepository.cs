using SgiAzure.Domain.Interfaces.Entities;

namespace SgiAzure.Domain.Interfaces.Repositories
{
    public interface IProjectRepository<T> where T : IProject
    {
        Task<IEnumerable<T>> GetAllProjects(CancellationToken ct = default);

        Task<T> GetProjectByCompany(int companyId, string system, CancellationToken ct = default);
    }
}
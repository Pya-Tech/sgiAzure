using Microsoft.EntityFrameworkCore;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Enumerators;
using SgiAzure.Domain.Exceptions;
using SgiAzure.Domain.Interfaces.Repositories;
using SgiAzure.Infrastructure.Databases.Sgi;

namespace SgiAzure.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository<Project>
    {
        private readonly SgiDbContext _context;

        public ProjectRepository(SgiDbContext context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Project>> GetAllProjects(CancellationToken ct = default)
        {
            return await _context.Projects.ToListAsync(ct);
        }

        public async Task<Project> GetProjectByCompany(int companyId, string system, CancellationToken ct = default)
        {
            var project = await _context.Projects.Where(project => project.CompanyId == companyId && project.System == system).FirstOrDefaultAsync(ct);
            return project ?? throw new SgiAzureException($"No existe projecto con los identificadores {companyId}{system}", ErrorCode.EntityNotFound);
        }
    }
}

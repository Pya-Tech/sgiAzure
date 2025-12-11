using Microsoft.EntityFrameworkCore;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Enumerators;
using SgiAzure.Domain.Exceptions;
using SgiAzure.Domain.Interfaces.Repositories;
using SgiAzure.Infrastructure.Databases.Sgi;

namespace SgiAzure.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository<Company>
    {
        private readonly SgiDbContext _context;

        public CompanyRepository(SgiDbContext context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Company>> GetAllCompanies(CancellationToken ct = default)
        {
            return await _context.Companies.ToListAsync(ct);
        }

        public async Task<Company> GetCompanyById(int companyId, CancellationToken ct = default)
        {
            var company = await _context.Companies.Where(company=> company.CompanyId == companyId).FirstOrDefaultAsync(ct);
            return company ?? throw new SgiAzureException($"No existe compañía con Id {companyId}", ErrorCode.EntityNotFound);
        }

        public async Task<Company> GetCompanyByName(string companyName, CancellationToken ct = default)
        {
            var company = await _context.Companies.Where(company => company.Name == companyName).FirstOrDefaultAsync(ct);
            return company ?? throw new SgiAzureException($"No existe compañía con nombre {companyName}", ErrorCode.EntityNotFound);
        }
    }
}
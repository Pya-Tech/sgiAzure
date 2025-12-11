using Microsoft.EntityFrameworkCore;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Enumerators;
using SgiAzure.Domain.Exceptions;
using SgiAzure.Domain.Interfaces.Repositories;
using SgiAzure.Infrastructure.Databases.SgiAzure;

namespace SgiAzure.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository<Customer>
    {
        private readonly SgiAzureDbContext _sgiAzureDbContext;
        public CustomerRepository(SgiAzureDbContext sgiAzureDbContext) {
            _sgiAzureDbContext = sgiAzureDbContext;
        }

        public async Task<Customer> CreateCustomer(Customer entity, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(entity);
            var customer = await _sgiAzureDbContext.Customers.AddAsync(entity, ct);
            await _sgiAzureDbContext.SaveChangesAsync(ct);
            return customer.Entity;
        }

        public async Task DeleteCustomer(int id, CancellationToken ct = default)
        {
            var customer = await _sgiAzureDbContext.Customers.FindAsync(id, ct);
            ArgumentNullException.ThrowIfNull(customer);
            _sgiAzureDbContext.Customers.Remove(customer);
            await _sgiAzureDbContext.SaveChangesAsync(ct);
        }

        public async Task<IEnumerable<Customer>> GetAll(CancellationToken ct = default)
        {
            return await _sgiAzureDbContext.Customers.ToListAsync(ct);
        }

        public async Task<Customer> GetByEmail(string email, CancellationToken ct = default)
        {
            var customer = await _sgiAzureDbContext.Customers.FirstOrDefaultAsync(c=> c.Email == email, cancellationToken: ct) ?? throw new SgiAzureException($"No existe cliente con email {email}", ErrorCode.EntityNotFound);
            return customer;
        }

        public async Task<Customer> GetById(int id, CancellationToken ct = default)
        {
            var customer = await _sgiAzureDbContext.Customers.FirstOrDefaultAsync(c=> c.Id == id, ct);
            return customer ?? throw new SgiAzureException($"No existe cliente con identificador {id}", ErrorCode.EntityNotFound);
        }

        public async Task<Customer> GetByName(string name, CancellationToken ct = default)
        {
            var customer = await _sgiAzureDbContext.Customers.FirstOrDefaultAsync(c=> c.Name == name, ct);
            return customer ?? throw new SgiAzureException($"No existe cliente con el nombre ${name}", ErrorCode.EntityNotFound );
        }

        public async Task<Customer> UpdateCustomer(int id, Customer entity, CancellationToken ct = default)
        {
            var customer = await _sgiAzureDbContext.Customers.FindAsync(id, ct) ?? throw new SgiAzureException($"No existe cliente con el identificador {id}", ErrorCode.EntityNotFound);
            
            if (!string.IsNullOrEmpty(customer.Domain))
            {
                customer.Domain = entity.Domain;
            }
            if (!string.IsNullOrEmpty(customer.Email))
            {
                customer.Email = entity.Email;
            }
            if(!string.IsNullOrEmpty(customer.UserName))
            {
                customer.UserName = entity.UserName;
            }
            if(!string.IsNullOrEmpty(customer.Project))
            {
                customer.Project = entity.Project;
            }

            await _sgiAzureDbContext.SaveChangesAsync(ct);

            return customer;

        }
    }
}

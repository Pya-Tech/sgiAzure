using SgiAzure.Domain.Entities;

namespace SgiAzure.Application.Interfaces.Services
{
    public interface ICustomerConfigService
    {
        Task<Customer> GetCustomer(string company);
    }
}

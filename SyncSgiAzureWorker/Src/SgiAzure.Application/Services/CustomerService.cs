using SgiAzure.Application.Interfaces.Services;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Interfaces.Repositories;

namespace SgiAzure.Application.Services
{
    public class CustomerService: ICustomerConfigService
    {
        private readonly ICustomerRepository<Customer> _customerRepository;

        public CustomerService(ICustomerRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> GetCustomer(string company)
        {
            var customer = await _customerRepository.GetByName(company);
            return customer;
        }
    }
}

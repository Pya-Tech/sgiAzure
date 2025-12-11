using Microsoft.Extensions.Logging;
using SgiAzure.Application.Services;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Exceptions;
using SgiAzure.Domain.Interfaces.Factories.SgiAzure.Domain.Factories;
using SgiAzure.Domain.Interfaces.Providers;
using SgiAzure.Domain.Interfaces.Repositories;

namespace SgiAzure.Application.UseCases
{
    /// <summary>
    /// Clase base para casos de uso relacionados con WorkItems.
    /// </summary>
    public abstract class BaseUseCase
    {
        private readonly IAzureWorkItemServiceFactory _azureWorkItemServiceFactory;
        protected readonly ILogger<BaseUseCase> _logger;
        private readonly ICustomerRepository<Customer> _customerRepository;

        protected BaseUseCase(
            IAzureWorkItemServiceFactory azureWorkItemServiceFactory,
            ILogger <BaseUseCase> logger,
            ICustomerRepository<Customer> customerRepository)
        {
            _azureWorkItemServiceFactory = azureWorkItemServiceFactory ?? throw new ArgumentNullException(nameof(azureWorkItemServiceFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task<Customer> GetCustomerConfig(string companyName, CancellationToken ct = default)
        {
            Customer customer = await _customerRepository.GetByName(companyName, ct) ?? throw new SgiAzureException($"No existe cliente con el nombre {companyName}");
            return customer;
        }


        /// <summary>
        /// Crea un servicio de WorkItem para una empresa específica.
        /// </summary>
        /// <param name="companyName">El nombre de la empresa.</param>
        /// <returns>El servicio de WorkItem creado.</returns>
        protected WorkItemService CreateWorkItemService(Customer customer)
        {
            IAzureWorkItemProvider<WorkItemEntity> workItemProvider = _azureWorkItemServiceFactory.Create(customer);
            _logger.LogInformation("Se crea conexión exitosa con la empresa {CompanyName}", customer.Name);
            return new WorkItemService(workItemProvider);
        }
    }
}

using Microsoft.Extensions.Logging;
using SgiAzure.Application.Interfaces.Services;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Interfaces.Factories.SgiAzure.Domain.Factories;
using SgiAzure.Domain.Interfaces.Providers;

namespace SgiAzure.Application.Services
{
    public class WorkItemCreationService : IWorkItemCreationService
    {
        private readonly IAzureWorkItemServiceFactory _azureWorkItemServiceFactory;
        private ILogger<WorkItemCreationService> _logger;

        public WorkItemCreationService(IAzureWorkItemServiceFactory azureWorkItemServiceFactory, ILogger<WorkItemCreationService> logger)
        {
            _azureWorkItemServiceFactory = azureWorkItemServiceFactory;
            _logger = logger;
        }

        public WorkItemService CreateWorkItemService(Customer customer)
        {
            IAzureWorkItemProvider<WorkItemEntity> workItemProvider = _azureWorkItemServiceFactory.Create(customer);
            _logger.LogInformation("Se crea conexión exitosa con la empresa {CompanyName}", customer.Name);
            return new WorkItemService(workItemProvider);
        }
    }
}

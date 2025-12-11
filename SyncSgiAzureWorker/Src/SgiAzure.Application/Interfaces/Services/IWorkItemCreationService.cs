using SgiAzure.Application.Services;
using SgiAzure.Domain.Entities;

namespace SgiAzure.Application.Interfaces.Services
{
    public interface IWorkItemCreationService
    {
        WorkItemService CreateWorkItemService(Customer customer);
    }
}

using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Interfaces.Providers;

namespace SgiAzure.Domain.Interfaces.Factories
{
    namespace SgiAzure.Domain.Factories
    {
        /// <summary>
        /// Define una fábrica para crear instancias de <see cref="AzureWorkItemService"/>.
        /// </summary>
        public interface IAzureWorkItemServiceFactory
        {
            /// <summary>
            /// Crea una instancia configurada de <see cref="AzureWorkItemService"/> para la empresa especificada.
            /// </summary>
            /// <param name="companyName">El nombre de la empresa para la que se configurará el servicio.</param>
            /// <returns>Una instancia de <see cref="AzureWorkItemService"/> configurada.</returns>
            IAzureWorkItemProvider<WorkItemEntity> Create(Customer customer);
        }
    }

}

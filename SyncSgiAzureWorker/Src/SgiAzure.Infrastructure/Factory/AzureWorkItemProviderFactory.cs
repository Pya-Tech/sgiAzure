using Microsoft.Extensions.Options;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Exceptions;
using SgiAzure.Domain.Interfaces.Factories.SgiAzure.Domain.Factories;
using SgiAzure.Domain.Interfaces.Providers;
using SgiAzure.Infrastructure.Providers;
using SgiAzure.Infrastructure.Services;
using SgiAzure.Infrastructure.Settings;

namespace SgiAzure.Infrastructure.Factory
{
    /// <summary>
    /// Fábrica para crear instancias del servicio <see cref="AzureWorkItemService"/> configuradas para empresas específicas.
    /// Proporciona un mecanismo centralizado para inicializar y configurar servicios de interacción con Azure DevOps.
    /// </summary>
    public class AzureWorkItemProviderFactory : IAzureWorkItemServiceFactory
    {
        /// <summary>
        /// Configuración de campos y parámetros adicionales para interactuar con los Work Items de Azure DevOps.
        /// Define qué campos se utilizan y cómo están parametrizados en el sistema.
        /// </summary>
        private readonly IOptions<AzureConfigurations> _azureConfigurations;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="AzureWorkItemServiceFactory"/>.
        /// </summary>
        /// <param name="azureDevopsConnectionsConfig">
        /// Configuración de las conexiones a los servidores de Azure DevOps, incluida la información necesaria para cada empresa.
        /// </param>
        /// <param name="azureConfigurations">
        /// Configuración de los campos y parámetros adicionales utilizados para interactuar con los Work Items de Azure DevOps.
        /// </param>
        public AzureWorkItemProviderFactory(
            IOptions<AzureConfigurations> azureConfigurations)
        {
            _azureConfigurations = azureConfigurations;
        }

        public IAzureWorkItemProvider<WorkItemEntity> Create(Customer customer)
        {
            if (customer == null)
            {
                throw new SgiAzureException($"La configuración de cliente no puede ser nula.");
            }

            if (_azureConfigurations.Value == null)
            {
                throw new SgiAzureException(
                    "No hay parametrización de campos declarada en la configuración de Azure.");
            }

            var azureDevopsServerSettings = new AzureDevopsServerSettings() { Domain = customer.Domain, Organization = customer.Organization, Name = customer.Name, Project = customer.Project, Token = customer.AccessToken, User = customer.UserName };

            return new AzureWorkItemProvider(_azureConfigurations.Value, azureDevopsServerSettings);
        }
    }
}
using Microsoft.Extensions.Logging;
using ServiceHook.Application.Configuration;
using ServiceHook.Application.Dto;
using ServiceHook.Application.Interfaces.Dto;
using ServiceHook.Application.Interfaces.Services;
using ServiceHook.Domain.Interfaces.Providers;
using System.Text.Json;

namespace ServiceHook.Application.Services
{
    /// <summary>
    /// Servicio para publicar mensajes de WorkItem en RabbitMQ utilizando un proveedor de mensajería.
    /// </summary>
    /// <typeparam name="T">
    /// Tipo genérico que representa el DTO del WorkItem. 
    /// Debe implementar la interfaz <see cref="IWorkItemDto"/>.
    /// </typeparam>
    /// <remarks>
    /// Constructor que inicializa el servicio con un proveedor de mensajería.
    /// </remarks>
    /// <param name="brokerMessageProvider">
    /// Proveedor de mensajería que se utiliza para publicar mensajes en RabbitMQ.
    /// </param>
    public class RabbitMQWorkItemMessagingService(IBrokerMessageProvider brokerMessageProvider,
        BrokerMessageConfiguration brokerMessageConfiguration, ILogger<RabbitMQWorkItemMessagingService> logger) : IWorkItemMessagingService
    {

        /// <summary>
        /// Proveedor de Mensajería
        /// </summary>s
        private readonly IBrokerMessageProvider _brokerMessageProvider = brokerMessageProvider;

        /// <summary>
        /// Configuración de Broker de Mensajería
        /// </summary>
        private readonly BrokerMessageConfiguration _brokerMessageConfiguration = brokerMessageConfiguration;

        /// <summary>
        /// Logger para proveedor de broker de mensajería
        /// </summary>
        private readonly ILogger<RabbitMQWorkItemMessagingService> _logger = logger;


        /// <summary>
        /// Publica un WorkItem en la cola de RabbitMQ.
        /// </summary>
        /// <param name="workItemDto">
        /// Instancia del tipo <typeparamref name="WorkItemCreatedMessageDto"/> que representa el WorkItem a publicar.
        /// </param>
        /// <returns>
        /// Una tarea que representa la operación asíncrona de publicación del mensaje.
        /// </returns>
        public async Task PublishWorkItemCreated(WorkItemCreatedMessageDto workItemDto)
        {
            var message = JsonSerializer.Serialize(workItemDto);
            if (_brokerMessageConfiguration.Users.Contains(workItemDto.RevisedBy))
            {
                return;
            }
            if (!_brokerMessageConfiguration.IterationPath.Contains(workItemDto.IterationPath))
            {
                return;
            }
            ArgumentNullException.ThrowIfNull(workItemDto);

            if (_brokerMessageConfiguration.Queues.TryGetValue("Insert", out var queue))
            {
                await _brokerMessageProvider.PublishAsync(queue.RoutingKey, message, _brokerMessageConfiguration.Exchange);
                return;
            }
            throw new KeyNotFoundException($"No se encontró la clave 'Insert' en el diccionario de colas.");

        }

        public async Task PublishWorkItemUpdated(WorkItemUpdatedMessageDto updatedWorkItemDto)
        {
            var message = JsonSerializer.Serialize(updatedWorkItemDto);
            _logger.LogInformation(_brokerMessageConfiguration.Exchange);
            if (_brokerMessageConfiguration.Users.Contains(updatedWorkItemDto.RevisedBy))
            {
                return;
            }
            if (!_brokerMessageConfiguration.IterationPath.Contains(updatedWorkItemDto.IterationPath))
            {
                return;
            }

            ArgumentNullException.ThrowIfNull(updatedWorkItemDto);

            if (_brokerMessageConfiguration.Queues.TryGetValue("Update", out var queue))
            {
                await _brokerMessageProvider.PublishAsync(queue.RoutingKey, message, _brokerMessageConfiguration.Exchange);
                return;
            }
            throw new KeyNotFoundException($"No se encontró la clave 'Insert' en el diccionario de colas.");

        }
    }
}

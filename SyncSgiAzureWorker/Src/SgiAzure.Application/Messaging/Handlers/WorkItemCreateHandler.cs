using Application.Messaging.Interfaces;
using Microsoft.Extensions.Logging;
using SgiAzure.Application.Dtos;
using SgiAzure.Application.UseCases;

namespace Application.Messaging.Handlers
{
    /// <summary>
    /// 
    /// </summary>
    public class WorkItemCreateHandler : IMessageHandler<RequirementCreatedDto>
    {
        /// <summary>
        /// Inyección del caso de uso para crear WorkItem a partir de requerimiento
        /// </summary>
        private readonly CreateWorkItemUseCase _createWorkItemUseCase;

        /// <summary>
        /// Logger para información de ejecución en el aplicativo
        /// </summary>
        private readonly ILogger<WorkItemCreateHandler> _logger;

        public WorkItemCreateHandler(CreateWorkItemUseCase createWorkItemUseCase, ILogger<WorkItemCreateHandler> logger) {

            _createWorkItemUseCase = createWorkItemUseCase;
            _logger = logger;
        }

        public async Task HandleAsync(RequirementCreatedDto message, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Se inicia caso de uso para creación de WorkItem a partir de un requerimiento en SGI");
            await _createWorkItemUseCase.ExecuteAsync(message);
        }
    }
}

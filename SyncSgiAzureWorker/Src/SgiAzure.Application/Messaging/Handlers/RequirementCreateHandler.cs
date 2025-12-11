using Application.Messaging.Interfaces;
using Microsoft.Extensions.Logging;
using SgiAzure.Application.Dtos;
using SgiAzure.Application.UseCases;

namespace Application.Messaging.Handlers
{

    /// <summary>
    /// Handler que orquesta el caso de uso de crear un requerimiento a partir de un WorkItem
    /// </summary>
    public class RequirementCreateHandler : IMessageHandler<WorkitemCreatedMessageDto>
    {
        /// <summary>
        /// Caso de uso que realizar la creación de un requerimiento a partir de un WorkItem
        /// </summary>
        private readonly CreateRequirementUseCase _createRequirementUseCase;
        private readonly ILogger<RequirementCreateHandler> _logger;

        public RequirementCreateHandler(CreateRequirementUseCase createRequirementUseCase, ILogger<RequirementCreateHandler> logger) {
            _createRequirementUseCase = createRequirementUseCase;
            _logger = logger;
        }
        public async Task HandleAsync(WorkitemCreatedMessageDto message, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Se procesa mensaje {Message}", message);
            await _createRequirementUseCase.ExecuteAsync(message);
        }
    }
}

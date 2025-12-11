using Application.Messaging.Interfaces;
using SgiAzure.Application.Dtos;
using SgiAzure.Application.UseCases;

namespace Application.Messaging.Handlers
{
    /// <summary>
    /// Handler para mensajes de creación de requerimientos en SGI
    /// que deben traducirse a Work Items en Azure DevOps.
    /// </summary>
    public class WorkItemUpdateHandler : IMessageHandler<RequirementUpdatedDto>
    {
        private readonly UpdateWorkItemFromRequirementUseCase _createWorkItemFromRequirementUseCase;

        public WorkItemUpdateHandler(UpdateWorkItemFromRequirementUseCase createWorkItemFromRequirementUseCase)
        {
            _createWorkItemFromRequirementUseCase = createWorkItemFromRequirementUseCase;
        }

        /// <summary>
        /// Método encargado de ejecutar la acción del caso de uso
        /// </summary>
        /// <param name="message">Dto con la información a procesar en el caso de uso</param>
        /// <param name="cancellationToken">Token de cancelación de la acción en proceso</param>
        /// <returns>Tarea asíncrona</returns>
        public async Task HandleAsync(RequirementUpdatedDto message, CancellationToken cancellationToken)
        {
            await _createWorkItemFromRequirementUseCase.ExecuteAsync(message);
        }
    }
}

using Application.Messaging.Interfaces;
using SgiAzure.Application.Dtos;
using SgiAzure.Application.UseCases;

namespace Application.Messaging.Handlers
{
    /// <summary>
    /// 
    /// </summary>
    public class RequirementUpdateHandler : IMessageHandler<WorkItemUpdatedDto>
    {
        private readonly UpdateWorkItemUseCase _updateRequirementFromWorkItemUseCase;

        public RequirementUpdateHandler(UpdateWorkItemUseCase updateRequirementFromWorkItemUseCase) {
            _updateRequirementFromWorkItemUseCase = updateRequirementFromWorkItemUseCase;
        }
        public Task HandleAsync(WorkItemUpdatedDto message, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

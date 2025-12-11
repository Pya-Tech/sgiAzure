using Microsoft.Extensions.Logging;
using SgiAzure.Application.Dtos;
using SgiAzure.Application.Interfaces.Mappers;
using SgiAzure.Application.Interfaces.Services;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Exceptions;
using SgiAzure.Domain.Interfaces.Database;
using SgiAzure.Domain.Interfaces.Factories.SgiAzure.Domain.Factories;
using SgiAzure.Domain.Interfaces.Repositories;

namespace SgiAzure.Application.UseCases
{

    public class UpdateWorkItemUseCase: BaseUseCase
    {
        private readonly ILogger<CreateRequirementUseCase> _logger;
        private readonly IMapper<WorkItemUpdatedMessageDto, RequirementUpdatedDto> _workItemMapper;
        private readonly IDatabaseTransactionManager _databaseTransactionManager;
        private readonly IChangeLogService _changeLogService;
        private readonly IRequirementService<RequirementDto> _requirementService;
        private readonly IRequirementWorkItemService<RequirementWorkItemDto> _requirementWorkItemService;

        public UpdateWorkItemUseCase(
            ILogger<CreateRequirementUseCase> logger, 
            IMapper<WorkItemUpdatedMessageDto, RequirementUpdatedDto> workItemMapper, 
            IDatabaseTransactionManager databaseTransactionManager, 
            IChangeLogService changeLogService, 
            IRequirementService<RequirementDto> requirementService,
            IAzureWorkItemServiceFactory azureWorkItemServiceFactory,
            ICustomerRepository<Customer> customerRepository,
            IRequirementWorkItemService<RequirementWorkItemDto> requirementWorkItemService): base(azureWorkItemServiceFactory, logger, customerRepository)
        {
            _logger = logger;
            _workItemMapper = workItemMapper;
            _databaseTransactionManager = databaseTransactionManager;
            _changeLogService = changeLogService;
            _requirementService = requirementService;
            _requirementWorkItemService = requirementWorkItemService;
        }

        public async Task ExecuteAsync(WorkItemUpdatedMessageDto workItemUpdatedMessageDto, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(nameof(workItemUpdatedMessageDto));
            Customer customer = await GetCustomerConfig(workItemUpdatedMessageDto.Origin);
            var workItemService = CreateWorkItemService(customer);
            WorkItemUpdatedDto workItemUpdatedDto = workItemUpdatedMessageDto.NewWorkItem;
            await using var transaction = await _databaseTransactionManager.BeginSgiTransactionAsync(ct);
            await using var sgiAzureTransaction = await _databaseTransactionManager.BeginSgiAzureTransactionAsync(ct);
            try
            {
                RequirementUpdatedDto requirementMap = await _workItemMapper.Map(workItemUpdatedMessageDto, customer.Id ?? throw new SgiAzureException("El identificador del cliente no puede ser nulo"));
                RequirementWorkItemDto requirementWorkItem = await _requirementWorkItemService.GetRequirementWorkItemsByWorkItemIdAsync(workItemUpdatedDto.WorkItemId);
                await _requirementService.UpdateRequirementAsync(requirementWorkItem.RequirementId, requirementMap);
                await transaction.CommitAsync();
                await sgiAzureTransaction.CommitAsync();
                await _changeLogService.RegisterChangeLog(
                    requirementMap, 
                    requirementWorkItem.RequirementId, 
                    workItemUpdatedMessageDto.Origin, 
                    Domain.Enum.ChangeType.Updated);

            }
            catch (Exception)
            {
                await transaction.RollbackAsync(ct);
                await sgiAzureTransaction.RollbackAsync(ct);
                await workItemService.RollbackWorkItemByRevisionId(workItemUpdatedDto.WorkItemId, workItemUpdatedMessageDto.Revision - 1);
                throw;
            }

        }
    }
}

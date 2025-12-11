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
    /// <summary>
    /// Caso de uso para crear un WorkItem a partir de un Requirement.
    /// </summary>
    public class UpdateWorkItemFromRequirementUseCase : BaseUseCase
    {
        private readonly IMapper<RequirementUpdatedDto, WorkItemUpdatedDto> _requirementMapper;
        private readonly IRequirementWorkItemService<RequirementWorkItemDto> _requirementWorkItemService;
        private readonly IChangeLogService _changeLogService;
        private readonly IDatabaseTransactionManager _databaseTransactionManager;

        public UpdateWorkItemFromRequirementUseCase(
            IAzureWorkItemServiceFactory azureWorkItemServiceFactory,
            ILogger<CreateWorkItemUseCase> logger,
            IMapper<RequirementUpdatedDto, WorkItemUpdatedDto> requirementMapper,
            IRequirementWorkItemService<RequirementWorkItemDto> requirementWorkItemService,
            IChangeLogService changeLogService,
            IDatabaseTransactionManager databaseTransactionManager,
            ICustomerRepository<Customer> customerRepository)
            : base(azureWorkItemServiceFactory, logger, customerRepository)
        {
            _requirementMapper = requirementMapper ?? throw new ArgumentNullException(nameof(requirementMapper));
            _requirementWorkItemService = requirementWorkItemService ?? throw new ArgumentNullException(nameof(requirementWorkItemService));
            _changeLogService = changeLogService ?? throw new ArgumentNullException(nameof(changeLogService));
            _databaseTransactionManager = databaseTransactionManager ?? throw new ArgumentNullException(nameof(databaseTransactionManager));
        }

        public async Task<WorkItemDto> ExecuteAsync(RequirementUpdatedDto requirementUpdatedDto, CancellationToken ct = default)
        {
            if (requirementUpdatedDto == null) throw new ArgumentNullException(nameof(requirementUpdatedDto));
            Customer customer = await GetCustomerConfig(requirementUpdatedDto.Company);
            var workItemService = CreateWorkItemService(customer);
            await using var databaseTransaction = await _databaseTransactionManager.BeginSgiAzureTransactionAsync();
            try
            {
                var requirementWorkItemDto = await _requirementWorkItemService.GetRequirementWorkItemByRequirementIdAsync(requirementUpdatedDto.RequirementId);
                WorkItemUpdatedDto workItemUpdatedDto = await _requirementMapper.Map(requirementUpdatedDto, customer.Id ?? throw new SgiAzureException("El identificador del cliente no puede ser nulo"));
                workItemUpdatedDto.WorkItemId = requirementWorkItemDto.WorkItemId;
                var result = await workItemService.UpdateWorkItemAsync(workItemUpdatedDto.WorkItemId, workItemUpdatedDto);
                await _changeLogService.RegisterChangeLog
                    (workItemUpdatedDto, 
                    requirementWorkItemDto.Id, 
                    requirementUpdatedDto.Company, 
                    Domain.Enum.ChangeType.Updated);
                await databaseTransaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                await databaseTransaction.RollbackAsync();
                _logger.LogError(ex, "Error al procesar WorkItem para RequirementId {RequirementId}, cambios revertidos.", requirementUpdatedDto.RequirementId);
                throw;
            }
        }
    }
}

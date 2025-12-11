using Microsoft.Extensions.Logging;
using SgiAzure.Application.Dtos;
using SgiAzure.Application.Interfaces.Mappers;
using SgiAzure.Application.Interfaces.Services;
using SgiAzure.Application.Services;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Exceptions;
using SgiAzure.Domain.Interfaces.Database;
using SgiAzure.Domain.Interfaces.Factories.SgiAzure.Domain.Factories;
using SgiAzure.Domain.Interfaces.Repositories;

namespace SgiAzure.Application.UseCases
{
    public class CreateRequirementUseCase : BaseUseCase
    {
        private readonly ILogger<CreateRequirementUseCase> _logger;
        private readonly IMapper<WorkItemCreatedDto, RequirementCreatedDto> _workItemMapper;
        private readonly IDatabaseTransactionManager _databaseTransactionManager;
        private readonly IChangeLogService _changeLogService;
        private readonly IRequirementService<RequirementDto> _requirementService;
        private readonly IRequirementWorkItemService<RequirementWorkItemDto> _requirementWorkItemService;

        public CreateRequirementUseCase(
            ILogger<CreateRequirementUseCase> logger,
            IRequirementParameterRepository<Multitable> requirementParameterRepository,
            IUserRepository<User> userRepository, 
            IMapper<WorkItemCreatedDto, RequirementCreatedDto> workItemMapper,
            IDatabaseTransactionManager databaseTransactionManager,
            IChangeLogService changelogService,
            IAzureWorkItemServiceFactory azureWorkItemServiceFactory,
            IRequirementService<RequirementDto> requirementService,
            ICustomerRepository<Customer> customerRepository,
            IRequirementWorkItemService<RequirementWorkItemDto> requirementWorkItemService) : base(azureWorkItemServiceFactory, logger, customerRepository)
        {
            _logger = logger;
            _workItemMapper = workItemMapper;
            _databaseTransactionManager = databaseTransactionManager;
            _changeLogService = changelogService;
            _requirementService = requirementService;
            _requirementWorkItemService = requirementWorkItemService;
        }

        public async Task ExecuteAsync(WorkitemCreatedMessageDto workitemCreatedMessageDto, CancellationToken ct = default)
        {
            await using var sgiTransaction = await _databaseTransactionManager.BeginSgiTransactionAsync(ct);
            await using var sgiAzureTransaction = await _databaseTransactionManager.BeginSgiAzureTransactionAsync(ct);
            WorkItemCreatedDto workItemCreatedDto = workitemCreatedMessageDto.WorkItemCreated;
            Customer customer = await GetCustomerConfig(workitemCreatedMessageDto.Origin, ct);
            WorkItemService workItemService = CreateWorkItemService(customer);
            try
            {
                RequirementCreatedDto requirementCreatedDto = await _workItemMapper.Map(workItemCreatedDto, customer.Id ?? throw new SgiAzureException("El identificador del cliente no puede ser nulo"));
                RequirementDto requirement = await _requirementService.CreateRequirementAsync(requirementCreatedDto);
                WorkItemUpdatedDto workItemUpdatedDto = new()
                {
                    WorkItemId = workItemCreatedDto.WorkItemId,
                    RequirementId = requirement.RequirementId,
                    Title = $"{requirement.RequirementId} [{requirement.System}] RQ {requirement.RequirementId}",
                    StartDate = requirement.StartDate,
                    TargetDate = requirement.TargetDate,
                    ProcessingType = requirement.ProcessingType,
                    CreatedBy = requirement.CreatedBy,
                    AssignedUser = requirement.ResponsibleUser
                };
                await workItemService.UpdateWorkItemAsync(workItemUpdatedDto.WorkItemId, workItemUpdatedDto);
                await _requirementWorkItemService.AddRequirementWorkItemAsync(
                    workItemCreatedDto.WorkItemId, 
                    requirement.RequirementId, customer.Id ?? throw new InvalidDataException("El identificador del cliente no puede ser nulo"), 
                    customer.Name);
                await sgiTransaction.CommitAsync();
                await sgiAzureTransaction.CommitAsync();
                _logger.LogInformation("Requerimiento creado exitosamente {RequirementId}", requirement.RequirementId);
                _logger.LogInformation("El título de WorkItem se actualiza a {Title}", workItemUpdatedDto.Title);
            }
            catch (Exception)
            {
                await sgiTransaction.RollbackAsync(ct);
                await sgiAzureTransaction.RollbackAsync(ct);
                throw;
            }
        }
    }
}
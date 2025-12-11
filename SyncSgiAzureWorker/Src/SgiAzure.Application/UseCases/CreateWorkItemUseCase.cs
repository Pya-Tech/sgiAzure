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
    /// <summary>
    /// Caso de uso para crear un WorkItem a partir de un Requirement.
    /// </summary>
    public sealed class CreateWorkItemUseCase : BaseUseCase
    {
        private readonly IMapper<RequirementCreatedDto, WorkItemCreatedDto> _requirementMapper;
        private readonly IRequirementWorkItemService<RequirementWorkItemDto> _requirementWorkItemService;
        private readonly IDatabaseTransactionManager _databaseTransactionManager;
        private readonly IChangeLogService _changelogService;

        public CreateWorkItemUseCase(
            IAzureWorkItemServiceFactory azureWorkItemServiceFactory,
            ILogger<CreateWorkItemUseCase> logger,
            IMapper<RequirementCreatedDto, WorkItemCreatedDto> requirementMapper,
            IRequirementWorkItemService<RequirementWorkItemDto> requirementWorkItemService,
            IDatabaseTransactionManager databaseTransactionManager,
            IChangeLogService changelogService,
            ICustomerRepository<Customer> customerRepository

            )
            : base(azureWorkItemServiceFactory, logger, customerRepository)
        {
            _requirementMapper = requirementMapper ?? throw new ArgumentNullException(nameof(requirementMapper));
            _requirementWorkItemService = requirementWorkItemService ?? throw new ArgumentNullException(nameof(requirementWorkItemService));
            _databaseTransactionManager = databaseTransactionManager ?? throw new ArgumentNullException(nameof(databaseTransactionManager));
            _changelogService = changelogService ?? throw new ArgumentNullException(nameof(changelogService));
        }

        /// <summary>
        /// Ejecuta el caso de uso para crear un WorkItem desde un Requirement.
        /// </summary>
        /// <param name="requirementDto">DTO del Requirement a crear.</param>
        /// <returns>El WorkItem creado.</returns>
        public async Task<WorkItemDto> ExecuteAsync(RequirementCreatedDto requirementDto, CancellationToken ct = default)
        {
            await using var transaction = await _databaseTransactionManager.BeginSgiAzureTransactionAsync(ct);
            Customer customer = await GetCustomerConfig(requirementDto.Company, ct);
            WorkItemService workItemService = CreateWorkItemService(customer);
            int? workItemCreatedId = 0;
            try
            {
                WorkItemCreatedDto workItemDto = await _requirementMapper.Map(requirementDto, customer.Id ?? throw new SgiAzureException("El identificador del cliente no puede ser nulo"));
                WorkItemDto workItemCreated = await workItemService.CreateWorkItemAsync(workItemDto);
                workItemCreatedId = workItemCreated.WorkItemId;
                RequirementWorkItemDto relatedCreated = await _requirementWorkItemService.AddRequirementWorkItemAsync(workItemCreatedId ?? throw new InvalidOperationException("El id de workitem no puede ser nulo"), requirementDto.RequirementId, customer.Id ?? throw new SgiAzureException("El identificador del cliente no puede ser nulo"), customer.Name);
                await transaction.CommitAsync(ct);
                await _changelogService.RegisterChangeLog(workItemCreated, relatedCreated.Id, requirementDto.Company);
                _logger.LogInformation("Workitem creado exitosamente {WorkItemId}", workItemCreatedId);
                _logger.LogInformation("El título de WorkItem se actualiza a {Title}", workItemCreated.Title);
                return workItemCreated;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear WorkItem desde el Requirement, se revierten los cambios");
                await transaction.RollbackAsync(ct);
                if (workItemCreatedId != null)
                {
                    await workItemService.DeleteWorkItemAsync((int)workItemCreatedId);
                }
                throw;
            }
        }

    }
}

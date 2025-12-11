using Microsoft.Extensions.Logging;
using SgiAzure.Application.Dtos;
using SgiAzure.Application.Interfaces.Config;
using SgiAzure.Application.Interfaces.Mappers;
using SgiAzure.Application.Interfaces.Mappings;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Exceptions;
using SgiAzure.Domain.Interfaces.Repositories;

namespace SgiAzure.Application.Mappers
{
    public class WorkItemUpdateMapper : IMapper<RequirementUpdatedDto, WorkItemUpdatedDto>
    {
        private readonly ILogger<WorkItemUpdateMapper> _logger;
        private readonly ICustomerRepository<Customer> _customerRepository;
        private readonly IFieldMappingContext _fieldMappingContext;

        public WorkItemUpdateMapper(
            ILogger<WorkItemUpdateMapper> logger,
            ICustomerRepository<Customer> customerRepository,
            IFieldMappingContext fieldMappingContext)
        {
            _logger = logger;
            _customerRepository = customerRepository;
            _fieldMappingContext = fieldMappingContext;
        }

        public async Task<WorkItemUpdatedDto> Map(RequirementUpdatedDto source, int customerId)
        {
            ArgumentNullException.ThrowIfNull(source);

            var dto = new WorkItemUpdatedDto
            {
                RequirementId = source.RequirementId,
                CreatedAt = source.CreatedAt,
                Description = source.Description,
                StartDate = source.StartDate,
                StateEndDate = source.StateEndDate,
                Title = GetWorkItemTitle(source),
                Project = source.Project ?? string.Empty,
                AssignedTo = await GetAssignedToWorkItem(customerId),
                Area = source.Area,
                FinalStatusDate = source.TargetDate,
                TargetDate = source.TargetDate,
                ResponsibleUser = source.ResponsibleUser ?? string.Empty,
                Company = source.Company,
                CreatedBy = source.CreatedBy,
                Comment = source.Comments,
                Priority = await _fieldMappingContext.MapAsync(
                    "Priority",
                    source.Priority?.ToString(),
                    customerId),
                System = await _fieldMappingContext.MapAsync(
                    "System",
                    source.System,
                    customerId),
                WorkItemType = await _fieldMappingContext.MapAsync(
                    "WorkItemType",
                    source.ReportType,
                    customerId),
                ReportType = await _fieldMappingContext.MapAsync(
                    "ReportedRequirementType",
                    source.ReportType,
                    customerId),
                ProcessingType = await _fieldMappingContext.MapAsync(
                    "ProcessRequirementType",
                    source.ProcessingType,
                    customerId),
                State = await _fieldMappingContext.MapAsync(
                    "Status",
                    source.State,
                    customerId),
            };

            return dto;
        }

        private async Task<string> GetAssignedToWorkItem(int customerId)
        {
            var customer = await _customerRepository.GetById(customerId);
            if (customer == null) return "unnasigned";
            return customer.Email ?? "unnasigned";
        }

        private string GetWorkItemTitle(RequirementUpdatedDto requirementDto)
        {
            var title = $"{requirementDto.RequirementId} [{requirementDto.System}] RQ {requirementDto.RequirementId}";
            _logger.LogInformation("Se crea título: {Title}", title);
            return title;
        }
    }
}

using Microsoft.Extensions.Logging;
using SgiAzure.Application.Common;
using SgiAzure.Application.Dtos;
using SgiAzure.Application.Interfaces.Mappers;
using SgiAzure.Application.Services;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Interfaces.Repositories;

namespace SgiAzure.Application.Mappers
{
    public class WorkItemToRequirementCreatedMapper: IMapper<WorkItemCreatedDto, RequirementCreatedDto>
    {
        private readonly IRequirementParameterRepository<Multitable> _requirementParameterRepository;
        private readonly ILogger<WorkItemToRequirementCreatedMapper> _logger;
        private readonly WorkItemValidatorService _workItemValidatorService;

        public WorkItemToRequirementCreatedMapper(
            IRequirementParameterRepository<Multitable> requirementParameterRepository, 
            ILogger<WorkItemToRequirementCreatedMapper> logger, 
            WorkItemValidatorService workItemValidatorService)
        {
            _requirementParameterRepository = requirementParameterRepository;
            _logger = logger;
            _workItemValidatorService = workItemValidatorService;
        }

        private async Task<string> MapReportType(string reportType)
        {
            var values = reportType.Split(" - ");
            var reportTypeId = values[0];
            var reportTypeObject = await _requirementParameterRepository.GetRequirementTypeByIdAsync(reportTypeId);
            return reportTypeObject.CodeId ?? default!;
        }

        private async Task<string> MapContract(string company)
        {
            var contract = await _requirementParameterRepository.GetRequirementContractsByCompany(company);
            if (contract == null) throw new InvalidOperationException("El contrato no puede ser nulo");
            return contract.First().Code ?? string.Empty;
        }

        private async Task ValidateWorkItemCreated(WorkItemCreatedDto workItemCreatedDto)
        {
            var validationResults = new List<ValidationResult>
            {
                await _workItemValidatorService.IsValidCompany(workItemCreatedDto.Company),
            };

            if (!string.IsNullOrEmpty(workItemCreatedDto.System))
            {
                validationResults.Add(await _workItemValidatorService.IsValidSystem(workItemCreatedDto.Company, workItemCreatedDto.System));
            }

            if (!string.IsNullOrEmpty(workItemCreatedDto.ReportType))
            {
                validationResults.Add(await _workItemValidatorService.IsValidReportType(workItemCreatedDto.ReportType));

            }

            if (!string.IsNullOrEmpty(workItemCreatedDto.ProcessingType))
            {
                validationResults.Add(await _workItemValidatorService.IsValidReportType(workItemCreatedDto.ProcessingType));
            }
            var errors = validationResults.Where(result => !result.IsValid).ToList();
            if (errors.Any())
            {
                var allErrors = string.Join("; ", errors.Select(result => result.ErrorMessage));
                throw new InvalidOperationException($"Errores de validación: {allErrors}");
            }
        }
        public async Task<RequirementCreatedDto> Map(WorkItemCreatedDto source, int customerId)
        {
            await ValidateWorkItemCreated(source);
            var requirementDto = new RequirementCreatedDto
            {
                Company = source.Company,
                Origin = "AZURE",
                Project = source.Project,
                Priority = !string.IsNullOrEmpty(source.Priority) ? int.Parse(source.Priority) : null,
                Description = source.Description,
                ReportType = !string.IsNullOrEmpty(source.ReportType) ? await MapReportType(source.ReportType) : default!,
                CreatedBy = "PSERRANO",
                Contract = await MapContract(source.Company),
                System = source.System
            };
            return requirementDto;
        }
    }
}

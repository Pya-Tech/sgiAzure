using Microsoft.Extensions.Logging;
using SgiAzure.Application.Common;
using SgiAzure.Application.Dtos;
using SgiAzure.Application.Interfaces.Mappers;
using SgiAzure.Application.Services;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Enumerators;
using SgiAzure.Domain.Exceptions;
using SgiAzure.Domain.Interfaces.Repositories;

namespace SgiAzure.Application.Mappers
{
    [Obsolete("Esto ahora pasa a ser WorkItemUpdateMapper")]
    public class WorkItemToRequirementUpdatedMapper: IMapper<WorkItemUpdatedMessageDto, RequirementUpdatedDto>

    {
        private readonly IRequirementParameterRepository<Multitable> _requirementParameterRepository;
        private readonly ILogger<WorkItemToRequirementUpdatedMapper> _logger;
        private readonly WorkItemValidatorService _workItemValidatorService;

        public WorkItemToRequirementUpdatedMapper(
            IRequirementParameterRepository<Multitable> requirementParameterRepository, 
            ILogger<WorkItemToRequirementUpdatedMapper> logger, 
            WorkItemValidatorService workItemValidatorService)
        {
            _requirementParameterRepository = requirementParameterRepository;
            _logger = logger;
            _workItemValidatorService = workItemValidatorService;
        }

        private async Task ValidateWorkItemUpdated(WorkItemUpdatedMessageDto workItemUpdatedMessageDto)
        {
            var validationResults = new List<ValidationResult>();

            if(workItemUpdatedMessageDto.NewWorkItem.Company != null && workItemUpdatedMessageDto.OldWorkItem.Company != workItemUpdatedMessageDto.NewWorkItem.Company)
                validationResults.Add(ValidationResult.Fail("La empresa no puede ser modificada"));

            if (workItemUpdatedMessageDto.OldWorkItem.RequirementId !=null)
                validationResults.Add(ValidationResult.Fail("El requerimiento no puede ser modificado"));

            if(workItemUpdatedMessageDto.NewWorkItem.StartDate != null)
            {
                validationResults.Add(ValidationResult.Fail("La fecha de inicio no puede ser modificada"));
            }

            if (workItemUpdatedMessageDto.NewWorkItem.TargetDate != null)
            {
                validationResults.Add(ValidationResult.Fail("La fecha prevista no puede ser modificada"));
            }

            if (!string.IsNullOrEmpty(workItemUpdatedMessageDto.NewWorkItem.ReportType))
                validationResults.Add(await _workItemValidatorService.IsValidReportType(workItemUpdatedMessageDto.NewWorkItem.ReportType));

            if (!string.IsNullOrEmpty(workItemUpdatedMessageDto.NewWorkItem.ProcessingType))
                validationResults.Add(await _workItemValidatorService.IsValidReportType(workItemUpdatedMessageDto.NewWorkItem.ProcessingType));

            var errors = validationResults.Where(result => !result.IsValid).ToList();
            if (errors.Any())
            {
                var allErrors = string.Join("; ", errors.Select(result => result.ErrorMessage));
                throw new SgiAzureException($"Errores de validación: {allErrors}", ErrorCode.ValidationField);
            }
        }

        private async Task<string> MapReportType(string reportType)
        {
            var values = reportType.Split(" - ");
            var reportTypeId = values[0];
            var reportTypeObject = await _requirementParameterRepository.GetRequirementTypeByIdAsync(reportTypeId);
            return reportTypeObject.CodeId ?? default!;
        }

        public async Task<RequirementUpdatedDto> Map(WorkItemUpdatedMessageDto source, int customerId)
        {
            await ValidateWorkItemUpdated(source);
            var requirementUpdatedDto = new RequirementUpdatedDto
            {
                Origin = "AZURE",
                Project = source.NewWorkItem.Project,
                Priority = !string.IsNullOrEmpty(source.NewWorkItem.Priority) ? int.Parse(source.NewWorkItem.Priority) : null,
                Description = source.NewWorkItem.Description ?? string.Empty,
                ReportType = !string.IsNullOrEmpty(source.NewWorkItem.ReportType) ? await MapReportType(source.NewWorkItem.ReportType) : default!,
                CreatedBy = source.NewWorkItem.CreatedBy ?? default!,
                System = source.NewWorkItem.System
            };
            return requirementUpdatedDto;
        }
    }
}

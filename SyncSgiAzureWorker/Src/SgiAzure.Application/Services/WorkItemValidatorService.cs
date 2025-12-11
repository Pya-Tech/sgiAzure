using SgiAzure.Application.Common;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Interfaces.Repositories;

namespace SgiAzure.Application.Services
{
    public class WorkItemValidatorService
    {
        private readonly IRequirementParameterRepository<Multitable> _requirementParameterRepository;
        private readonly ICompanyRepository<Company> _companyRepository;
        private readonly IProjectRepository<Project> _projectRepository;

        public WorkItemValidatorService(
            IRequirementParameterRepository<Multitable> requirementParameterRepository,
            ICompanyRepository<Company> companyRepository,
            IProjectRepository<Project> projectRepository)
        {
            _requirementParameterRepository = requirementParameterRepository;
            _companyRepository = companyRepository;
            _projectRepository = projectRepository;
        }

        public async Task<ValidationResult> IsValidReportType(string reportTypeId)
        {
            if (string.IsNullOrWhiteSpace(reportTypeId))
                return ValidationResult.Fail("El tipo de reporte no puede estar vacío.");

            var reportTypeIdValue = reportTypeId.Split(" - ")[0];
            var reportType = await _requirementParameterRepository.GetRequirementTypeByIdAsync(reportTypeIdValue);

            return reportType != null
                ? ValidationResult.Success()
                : ValidationResult.Fail($"El tipo de reporte con ID '{reportTypeId}' no existe.");
        }

        public async Task<ValidationResult> IsValidCompany(string company)
        {
            if (string.IsNullOrWhiteSpace(company))
                return ValidationResult.Fail("El campo 'Company' no puede estar vacío.");

            var companyEntity = await _companyRepository.GetCompanyByName(company);

            return companyEntity == null
                ? ValidationResult.Fail($"La compañía '{company}' no existe.")
                : ValidationResult.Success();
        }

        public async Task<ValidationResult> IsValidSystem(string company, string system)
        {
            if (string.IsNullOrWhiteSpace(system))
                return ValidationResult.Fail("El sistema no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(company))
                return ValidationResult.Fail("El identificador de empresa no puede ser nulo");

            var companyEntity = await _companyRepository.GetCompanyByName(company);
            var systemEntity = await _projectRepository.GetProjectByCompany((companyEntity?.CompanyId) ?? throw new InvalidDataException($"No existe empresa con el identificador {company}"), system);
            return systemEntity != null
                ? ValidationResult.Success()
                : ValidationResult.Fail($"El sistema con ID '{system}' no existe.");
        }

        public static ValidationResult IsValidDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                return ValidationResult.Fail("La descripción no puede estar vacía.");
            
            return ValidationResult.Success();
        }

    }
}

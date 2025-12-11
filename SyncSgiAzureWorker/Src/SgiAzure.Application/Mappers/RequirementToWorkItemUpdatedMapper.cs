using Microsoft.Extensions.Logging;
using SgiAzure.Application.Dtos;
using SgiAzure.Application.Interfaces.Config;
using SgiAzure.Application.Interfaces.Mappers;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Interfaces.Repositories;

namespace SgiAzure.Application.Mappers
{
    public class RequirementToWorkItemUpdatedMapper : IMapper<RequirementUpdatedDto, WorkItemUpdatedDto>
    {
        private readonly IWorkItemMappingsConfig _workItemMappingsConfig;
        private readonly IUserRepository<User> _userRepository;
        private readonly IRequirementParameterRepository<Multitable> _requirementParameterRepository;
        private readonly ILogger<RequirementToWorkItemUpdatedMapper> _logger;
        private readonly IProjectRepository<Project> _projectRepository;
        private readonly ICompanyRepository<Company> _companyRepository;

        public RequirementToWorkItemUpdatedMapper(
            IWorkItemMappingsConfig workItemMappingsConfig,
            IUserRepository<User> userRepository,
            IRequirementParameterRepository<Multitable> requirementParameterRepository,
            ILogger<RequirementToWorkItemUpdatedMapper> logger,
            IProjectRepository<Project> projectRepository,
            ICompanyRepository<Company> companyRepository)
        {
            _workItemMappingsConfig = workItemMappingsConfig;
            _userRepository = userRepository;
            _requirementParameterRepository = requirementParameterRepository;
            _logger = logger;
            _projectRepository = projectRepository;
            _companyRepository = companyRepository;
        }
        public async Task<WorkItemUpdatedDto> Map(RequirementUpdatedDto source, int customerId)
        {
            ArgumentNullException.ThrowIfNull(nameof(source));

            WorkItemUpdatedDto workItemDto = new()
            {
                RequirementId = source.RequirementId,
                CreatedAt = source.CreatedAt,
                Description = source.Description,
                StartDate = source.StartDate,
                StateEndDate = source.StateEndDate,
                Title = GetWorkItemTitle(source),
                Project = source.Project ?? string.Empty,
                AssignedTo = await GetAssignedToWorkItem(source),
                Area = source.Area,
                FinalStatusDate = source.TargetDate,
                TargetDate = source.TargetDate,
                Priority = GetPriority(source),
                ResponsibleUser = source.ResponsibleUser ?? string.Empty,
                System = await GetRequirementSystem(source),
                WorkItemType = GetWorkItemType(source),
                Company = source.Company,
                CreatedBy = source.CreatedBy,
                ReportType = await GetRequirementType(source.ReportType),
                State = GetStatuses(source),
                ProcessingType = await GetRequirementType(source.ProcessingType),
                Comment = source.Comments,
            };

            return workItemDto;
        }

        private async Task<string> GetRequirementType(string? requirementType)
        {
            if (string.IsNullOrEmpty(requirementType))
            {
                return string.Empty;
            }
            var processingType = await _requirementParameterRepository.GetRequirementTypeByIdAsync(requirementType);

            return $"{processingType.CodeId} - {processingType.CodeDescription}";
        }


        private async Task<string> GetRequirementSystem(RequirementUpdatedDto requirement)
        {
            var company = await _companyRepository.GetCompanyByName(requirement.Company);
            var requirementSystem = await _projectRepository.GetProjectByCompany(company.CompanyId ?? throw new InvalidOperationException("El id de compañía es nulo"), requirement.System);
            return $"{requirementSystem.System} - {requirementSystem.Description}";

        }

        /// <summary>
        /// Método encargado de obtener el correo de la persona asignada al requerimiento.
        /// Si no se encuentra el usuario, retorna "unnasigned".
        /// </summary>
        /// <param name="requirement">El objeto RequirementDto que contiene la información del requerimiento.</param>
        /// <returns>El correo electrónico del usuario asignado al requerimiento.</returns>
        private async Task<string> GetAssignedToWorkItem(RequirementUpdatedDto requirement)
        {
            var user = await _userRepository.GetUserByUsername(requirement.CreatedBy);
            if (user == null) return "unnasigned";
            return user.Email ?? "unnasigned";
        }

        /// <summary>
        /// Método encargado de obtener el tipo de WorkItemEntity a construir según el tipo de reporte.
        /// </summary>
        /// <param name="requirementDto">El objeto <see cref="RequirementDto"/> que contiene la información del requerimiento.</param>
        /// <returns>Tipo de workitem a crear, basado en la configuración de mapeos.</returns>
        private string GetWorkItemType(RequirementUpdatedDto requirementDto)
        {
            return _workItemMappingsConfig.Types.ContainsKey(requirementDto.ReportType ?? "ADM")
                ? _workItemMappingsConfig.Types[requirementDto.ReportType ?? "ADM"]
                : "ADM";
        }

        /// <summary>
        /// Obtiene la prioridad asociada a un objeto <see cref="RequirementDto"/> según su propiedad <c>Priority</c>.
        /// Si la prioridad no está definida en el diccionario, se asigna un valor por defecto de "1".
        /// </summary>
        /// <param name="requirementDto">El objeto <see cref="RequirementDto"/> que contiene la información de la prioridad.</param>
        /// <returns>
        /// Retorna un valor de tipo <c>string</c> que representa la prioridad asociada al objeto <see cref="RequirementDto"/>.
        /// Si la prioridad del <paramref name="requirementDto"/> existe en el diccionario <c>workItemPriority</c>, se retorna el valor asociado.
        /// En caso contrario, se retorna el valor por defecto "1".
        /// </returns>
        private string GetPriority(RequirementUpdatedDto requirementDto)
        {
            return _workItemMappingsConfig.Priorities.ContainsKey(requirementDto.Priority ?? 1)
                ? _workItemMappingsConfig.Priorities[requirementDto.Priority ?? 1]
                : "1";
        }

        private string? GetStatuses(RequirementUpdatedDto requirement)
        {
            if (requirement == null || string.IsNullOrEmpty(requirement.State)) return null;
            if(_workItemMappingsConfig.Statuses.TryGetValue(requirement.State, out var status))
            {
                return status;
            }
            return null;
        }

        /// <summary>
        /// Método encargado de crear el título del WorkItemEntity basado en el Requerimiento.
        /// El título es generado a partir del ID del requerimiento y el sistema al que pertenece.
        /// </summary>
        /// <param name="requirementDto">El objeto <see cref="RequirementDto"/> que contiene la información del requerimiento.</param>
        /// <returns>El título del WorkItemEntity generado.</returns>
        private string GetWorkItemTitle(RequirementUpdatedDto requirementDto)
        {
            var title = $"{requirementDto.RequirementId} [{requirementDto.System}] RQ {requirementDto.RequirementId}";
            _logger.LogInformation("Se crea título: {Title}", title);
            return title;
        }
    }
}

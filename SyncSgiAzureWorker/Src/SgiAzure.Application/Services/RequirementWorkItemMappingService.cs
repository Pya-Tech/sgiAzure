using Microsoft.Extensions.Logging;
using SgiAzure.Application.Dtos;
using SgiAzure.Application.Interfaces.Config;
using SgiAzure.Application.Interfaces.Services;

namespace SgiAzure.Application.Services
{
    /// <summary>
    /// Servicio encargado de gestionar la relación de mapeo entre WorkItems y Requirements.
    /// Este servicio facilita el mapeo de información entre los objetos RequirementDto y WorkItemDto.
    /// </summary>
    /// 
    [Obsolete("Esto ahora pasa a ser WorkItemCreateMapper")]
    public class RequirementWorkItemMappingService : IRequirementToWorkItemMapperService
    {
        /// <summary>
        /// Repositorio de servicio para la gestión de mapeo entre WorkItems y Requirements.
        /// </summary>
        private readonly IRequirementWorkItemService<RequirementWorkItemDto> _requirementWorkItemService;

        /// <summary>
        /// Servicio de Requirements para gestionar la creación y manipulación de Requerimientos.
        /// </summary>
        private readonly IRequirementService<RequirementDto> _requirementService;

        /// <summary>
        /// Servicio de usuario para obtener información relacionada con los usuarios.
        /// </summary>
        private readonly IUserService<UserDto> _userService;

        /// <summary>
        /// Configuración de mapeos de WorkItems.
        /// </summary>
        private readonly IWorkItemMappingsConfig _workItemMappingsConfig;

        /// <summary>
        /// Servicio de registro para la captura de eventos e información del sistema.
        /// </summary>
        private readonly ILogger<RequirementWorkItemMappingService> _logger;

        /// <summary>
        /// Constructor para inyectar los servicios necesarios en la clase.
        /// </summary>
        /// <param name="requirementWorkItemService">Servicio para trabajar con los mapeos entre Requerimientos y WorkItems.</param>
        /// <param name="requirementService">Servicio para manejar la entidad Requirement.</param>
        /// <param name="userService">Servicio para obtener información sobre los usuarios.</param>
        /// <param name="logger">Servicio de logging para capturar eventos.</param>
        /// <param name="workItemMappingsConfig">Configuración de los mapeos entre WorkItems y Requerimientos.</param>
        public RequirementWorkItemMappingService(
            IRequirementWorkItemService<RequirementWorkItemDto> requirementWorkItemService,
            IRequirementService<RequirementDto> requirementService,
            IUserService<UserDto> userService,
            ILogger<RequirementWorkItemMappingService> logger,
            IWorkItemMappingsConfig workItemMappingsConfig)
        {
            _requirementWorkItemService = requirementWorkItemService ?? throw new ArgumentNullException(nameof(requirementWorkItemService));
            _requirementService = requirementService ?? throw new ArgumentNullException(nameof(requirementService));
            _userService = userService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _workItemMappingsConfig = workItemMappingsConfig;
        }

        /// <summary>
        /// Mapea un objeto <see cref="RequirementDto"/> a un <see cref="WorkItemDto"/>.
        /// Este método convierte un Requerimiento en un WorkItemEntity que puede ser utilizado en otras operaciones.
        /// </summary>
        /// <param name="requirement">El objeto Requerimiento a mapear.</param>
        /// <returns>Un objeto <see cref="WorkItemDto"/> mapeado.</returns>
        /// <exception cref="ArgumentNullException">Lanza una excepción si el parámetro <paramref name="requirement"/> es nulo.</exception>
        public async Task<WorkItemDto> MapRequirementToWorkItemAsync(RequirementDto requirement)
        {
            if (requirement == null)
            {
                throw new ArgumentNullException(nameof(requirement), "El requerimiento no puede ser nulo.");
            }
            WorkItemDto workItemDto = new()
            {
                RequirementId = requirement.RequirementId,
                CreatedAt = requirement.CreatedAt,
                Description = requirement.Description,
                ProcessingType = requirement.ProcessingType,
                StartDate = requirement.StartDate,
                StateEndDate = requirement.StateEndDate,
                Title = GetWorkItemTitle(requirement),
                Project = requirement.Project,
                AssignedTo = await GetAssignedToWorkItem(requirement),
                ScheduledHours = requirement.ScheduledHours,
                Area = requirement.Area,
                FinalStatusDate = requirement.StateEndDate,
                Priority = GetPriority(requirement),
                ResponsibleUser = requirement.ResponsibleUser ?? string.Empty,
                TargetDate = requirement.TargetDate,
                System = requirement.System,
                WorkItemType = GetWorkItemType(requirement),
                Company = requirement.Company,
                CreatedBy = requirement.CreatedBy,
                ReportType = requirement.ReportType
            };

            return workItemDto;
        }

        /// <summary>
        /// Método encargado de obtener el correo de la persona asignada al requerimiento.
        /// Si no se encuentra el usuario, retorna "unnasigned".
        /// </summary>
        /// <param name="requirement">El objeto RequirementDto que contiene la información del requerimiento.</param>
        /// <returns>El correo electrónico del usuario asignado al requerimiento.</returns>
        public async Task<string> GetAssignedToWorkItem(RequirementDto requirement)
        {
            var user = await _userService.GetUserByUsername(requirement.CreatedBy);
            if (user == null) return "unnasigned";
            return user.Email;
        }

        /// <summary>
        /// Método encargado de obtener el tipo de WorkItemEntity a construir según el tipo de reporte.
        /// </summary>
        /// <param name="requirementDto">El objeto <see cref="RequirementDto"/> que contiene la información del requerimiento.</param>
        /// <returns>Tipo de workitem a crear, basado en la configuración de mapeos.</returns>
        private string GetWorkItemType(RequirementDto requirementDto)
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
        private string GetPriority(RequirementDto requirementDto)
        {
            return _workItemMappingsConfig.Priorities.ContainsKey(requirementDto.Priority ?? 1)
                ? _workItemMappingsConfig.Priorities[requirementDto.Priority ?? 1]
                : "1";
        }

        /// <summary>
        /// Método encargado de crear el título del WorkItemEntity basado en el Requerimiento.
        /// El título es generado a partir del ID del requerimiento y el sistema al que pertenece.
        /// </summary>
        /// <param name="requirementDto">El objeto <see cref="RequirementDto"/> que contiene la información del requerimiento.</param>
        /// <returns>El título del WorkItemEntity generado.</returns>
        private string GetWorkItemTitle(RequirementDto requirementDto)
        {
            var title = $"{requirementDto.RequirementId} [{requirementDto.System}] RQ {requirementDto.RequirementId}";
            _logger.LogInformation($"Se crea título: {title}");
            return title;
        }

        public Task<WorkItemDto> MapWorkItemToRequirementAsync(WorkItemDto workItem)
        {
            throw new NotImplementedException();
        }
    }
}

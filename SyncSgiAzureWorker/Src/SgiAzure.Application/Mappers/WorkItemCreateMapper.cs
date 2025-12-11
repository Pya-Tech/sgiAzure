using Microsoft.Extensions.Logging;
using SgiAzure.Application.Dtos;
using SgiAzure.Application.Interfaces.Mappers;
using SgiAzure.Application.Interfaces.Mappings;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Exceptions;
using SgiAzure.Domain.Interfaces.Repositories;

namespace SgiAzure.Application.Mappers
{

    /// <summary>
    /// Clase encargada de mapear un requerimiento creado a un workItem a crear
    /// </summary>
    public class WorkItemCreateMapper : IMapper<RequirementCreatedDto, WorkItemCreatedDto>
    {
        /// <summary>
        /// Configuración de mapeo de requerimientos a workItem
        /// </summary>
        private readonly ICustomerRepository<Customer> _customerRepository;
        private readonly ILogger<WorkItemCreateMapper> _logger;
        private readonly IFieldMappingContext _fieldMappingContext;

        public WorkItemCreateMapper(
            ILogger<WorkItemCreateMapper> logger,
            ICustomerRepository<Customer> customerRepository,
            IFieldMappingContext fieldMappingContext
            )
        {
            _logger = logger;
            _customerRepository = customerRepository;
            _fieldMappingContext = fieldMappingContext;
        }

        /// <summary>
        /// Método encargado de mapear un Requerimiento a Un workitem
        /// </summary>
        /// <param name="source">Requerimiento con los datos a mapear</param>
        /// <returns>devuelve una instancia de WorkItemCreatedDto para ser procesada por el servicio de Azure Devops</returns>
        public async Task<WorkItemCreatedDto> Map(RequirementCreatedDto source, int customerId)
        {
            ArgumentNullException.ThrowIfNull(source);

            WorkItemCreatedDto workItemDto = new()
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
                FinalStatusDate = source.StateEndDate,
                Priority = await _fieldMappingContext.MapAsync(
                    "Priority", 
                    source.Priority?.ToString() ?? "1", 
                    customerId),
                ResponsibleUser = source.ResponsibleUser ?? string.Empty,
                System = await _fieldMappingContext.MapAsync(
                    "System", 
                    source.System, 
                    customerId),
                WorkItemType = await _fieldMappingContext.MapAsync(
                    "WorkItemType", 
                    source.ReportType, 
                    customerId),
                Company = source.Company,
                CreatedBy = source.CreatedBy,
                ReportType = await _fieldMappingContext.MapAsync(
                    "ReportedRequirementType", 
                    source.ReportType, 
                    customerId),
                Comment = source.Comments,
            };

            return workItemDto;
        }

   

        /// <summary>
        /// Método encargado de obtener el correo de la persona asignada al requerimiento.
        /// Si no se encuentra el usuario, retorna "unnasigned".
        /// </summary>
        /// <param name="requirement">El objeto RequirementDto que contiene la información del requerimiento.</param>
        /// <returns>El correo electrónico del usuario asignado al requerimiento.</returns>
        private async Task<string> GetAssignedToWorkItem(int customersId)
        {
            Customer customer = await _customerRepository.GetById(customersId);
            if (customer == null) return "unnasigned";
            return customer.Email ?? "unnasigned";
        }

        /// <summary>
        /// Método encargado de crear el título del WorkItemEntity basado en el Requerimiento.
        /// El título es generado a partir del ID del requerimiento y el sistema al que pertenece.
        /// </summary>
        /// <param name="requirementDto">El objeto <see cref="RequirementDto"/> que contiene la información del requerimiento.</param>
        /// <returns>El título del WorkItemEntity generado.</returns>
        private string GetWorkItemTitle(RequirementCreatedDto requirementDto)
        {
            ArgumentNullException.ThrowIfNull(requirementDto);

            var title = $"{requirementDto.RequirementId} [{requirementDto.System}] RQ {requirementDto.RequirementId}";
            _logger.LogInformation("Se crea título: {Title}", title);
            return title;
        }

    }
}

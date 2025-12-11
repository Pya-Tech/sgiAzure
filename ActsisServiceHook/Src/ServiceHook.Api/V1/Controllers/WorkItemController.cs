using Microsoft.AspNetCore.Mvc;
using ServiceHook.Api.Models;
using ServiceHook.Api.V1.Mappers;
using ServiceHook.Api.V1.Requests;
using ServiceHook.Application.Dto;
using ServiceHook.Application.Interfaces.Services;

namespace ServiceHook.Api.V1.Controllers
{
    /// <summary>
    /// Controlador para gestionar eventos de webhook relacionados con work items.
    /// </summary>
    [Route("api/v1/webhooks/workitems")]
    [ApiController]
    public class WorkItemController : ControllerBase
    {
        /// <summary>
        /// Instancia de <see cref="ILogger"/> utilizada para registrar eventos y errores.
        /// </summary>
        private readonly ILogger<WorkItemController> _logger;

        /// <summary>
        /// Servicio para publicar eventos de work items.
        /// </summary>
        private readonly IWorkItemMessagingService _workItemMessagingService;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="WorkItemController"/>.
        /// </summary>
        /// <param name="logger">Instancia del logger para registrar eventos.</param>
        /// <param name="workItemMessagingService">Servicio para manejar la publicación de eventos de work items.</param>
        /// <exception cref="ArgumentNullException">Se lanza si alguna de las dependencias es nula.</exception>
        public WorkItemController(
            ILogger<WorkItemController> logger,
            IWorkItemMessagingService workItemMessagingService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _workItemMessagingService = workItemMessagingService ?? throw new ArgumentNullException(nameof(workItemMessagingService));
        }

        /// <summary>
        /// Publica un evento de creación de un work item.
        /// </summary>
        /// <param name="workItemEvent">Detalles del evento de creación del work item.</param>
        /// <returns>
        /// - HTTP 200 OK si el evento se procesó correctamente.
        /// - HTTP 400 Bad Request si el modelo de entrada no es válido.
        /// </returns>
        /// <response code="200">El evento de creación fue procesado exitosamente.</response>
        /// <response code="400">El modelo de entrada no es válido.</response>
        [HttpPost("create")]
        [ProducesResponseType(typeof(WorkItemDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateWorkItem([FromBody] WorkItemEventRequest workItemEventRequest)
        {
            if (workItemEventRequest == null)
            {
                _logger.LogWarning("Se recibió un payload nulo para WorkItemCreated.");
                return BadRequest("El payload proporcionado no es válido: WorkItemCreated no puede ser nulo.");
            }
            _logger.LogInformation("Procesando evento WorkItemCreated...");
            var workItemCreatedDto = workItemEventRequest.ToWorkItemCreatedDto();

            await _workItemMessagingService.PublishWorkItemCreated(workItemCreatedDto);

            _logger.LogInformation("Evento WorkItemCreated procesado exitosamente.");
            return Ok(workItemCreatedDto);
        }

        /// <summary>
        /// Publica un evento de actualización de un work item.
        /// </summary>
        /// <param name="workItemEvent">Detalles del evento de actualización del work item.</param>
        /// <returns>
        /// - HTTP 200 OK si la actualización fue procesada exitosamente.
        /// - HTTP 400 Bad Request si el modelo de entrada no es válido.
        /// </returns>
        /// <response code="200">El evento de actualización fue procesado exitosamente.</response>
        /// <response code="400">El modelo de entrada no es válido.</response>
        [HttpPost("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateWorkItem([FromBody] WorkItemEvent workItemEvent)
        {
            if (workItemEvent == null)
            {
                _logger.LogWarning("Se recibió un payload nulo para WorkItemEvent.");
                return BadRequest("El payload proporcionado no es válido: WorkItemEvent no puede ser nulo.");
            }
            _logger.LogInformation("Procesando evento WorkItemCreated...");
            var workItemDto = workItemEvent.ToWorkItemUpdatedDto();

            await _workItemMessagingService.PublishWorkItemUpdated(workItemDto);

            _logger.LogInformation("Evento WorkItemCreated procesado exitosamente.");
            return Ok(workItemDto);
        }
    }
}

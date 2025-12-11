using SgiAzure.Domain.Enum;

namespace SgiAzure.Application.Interfaces.Dtos
{
    public interface IMessageProcesingDto
    {
        /// <summary>
        /// Obtiene o establece el identificador único del procesamiento del mensaje.
        /// </summary>
        int? Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del mensaje procesado.
        /// </summary>
        string? MessageId { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la cola en la que se encuentra el mensaje.
        /// </summary>
        string Queue { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del requerimiento asociado al mensaje, si aplica.
        /// </summary>
        int? RequirementId { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del work item asociado al mensaje, si aplica.
        /// </summary>
        int? WorkItemId { get; set; }

        /// <summary>
        /// Obtiene o establece el estado actual del procesamiento del mensaje.
        /// </summary>
        MessageProcessingStatus Status { get; set; }

        /// <summary>
        /// Obtiene o establece un mensaje de error, si se ha producido un fallo durante el procesamiento.
        /// </summary>
        string? ErrorMessage { get; set; }

        /// <summary>
        /// Obtiene o establece el número de intentos realizados para procesar el mensaje.
        /// </summary>
        int Attempts { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha y hora en que se creó el registro de procesamiento del mensaje.
        /// </summary>
        DateTime CreatedAt { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la relación entre el requerimiento y el work item.
        /// </summary>
        int RequirementWorkItemId { get; set; }
    }
}

using SgiAzure.Domain.Enum;
using SgiAzure.Domain.Interfaces.Entities;
using System;

namespace SgiAzure.Domain.Entities
{
    /// <summary>
    /// Representa el procesamiento de un mensaje en la cola de procesamiento de requerimientos asociados a WorkItems.
    /// </summary>
    public class MessageProcessing : IMessageProcessing
    {
        /// <summary>
        /// Identificador único del proceso de mensaje.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador único del mensaje en la cola.
        /// </summary>
        public required string MessageId { get; set; }

        /// <summary>
        /// Nombre de la cola de procesamiento de mensajes.
        /// </summary>
        public required string Queue { get; set; }

        /// <summary>
        /// Identificador del requerimiento asociado al mensaje. Puede ser nulo si no está asociado a un requerimiento.
        /// </summary>
        public int? RequirementId { get; set; }

        /// <summary>
        /// Identificador del WorkItemEntity asociado al mensaje. Puede ser nulo si no está asociado a un WorkItemEntity.
        /// </summary>
        public int? WorkItemId { get; set; }

        /// <summary>
        /// Estado actual del mensaje durante su procesamiento. Los posibles valores son: Pending, Processing, Processed, Failed.
        /// </summary>
        public MessageProcessingStatus Status { get; set; }

        /// <summary>
        /// Mensaje de error asociado al proceso de mensaje, si ocurre algún fallo.
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// Número de intentos de procesamiento realizados hasta el momento.
        /// </summary>
        public int Attempts { get; set; }

        /// <summary>
        /// Fecha y hora de la creación del proceso de mensaje.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Fecha y hora de la última actualización del proceso de mensaje (si aplica).
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Identificador del requisito asociado al WorkItemEntity que está siendo procesado.
        /// </summary>
        public int RequirementWorkItemId { get; set; }
        
        /// <summary>
        /// Objeto de relación
        /// </summary>
        public RequirementWorkItem? RequirementWorkItem { get; set; }
    }
}

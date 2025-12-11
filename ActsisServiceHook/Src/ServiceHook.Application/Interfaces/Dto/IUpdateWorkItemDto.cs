using ServiceHook.Application.Dto;

namespace ServiceHook.Application.Interfaces.Dto
{
    /// <summary>
    /// Interfaz que define los datos requeridos para actualizar un WorkItem.
    /// </summary>
    public interface IUpdateWorkItemDto
    {
        /// <summary>
        /// URL del proyecto asociado al WorkItem.
        /// </summary>
        public string ProjectUrl { get; set; }

        /// <summary>
        /// Path de iteración del WorkItem
        /// </summary>
        public string IterationPath { get; set; }

        /// <summary>
        /// ID único de la revisión del WorkItem.
        /// </summary>
        public int RevisionId { get; set; }

        /// <summary>
        /// Número de la revisión actual del WorkItem.
        /// </summary>
        public int Revision { get; set; }

        /// <summary>
        /// Identificador del usuario que realizó la última revisión del WorkItem.
        /// </summary>
        public string RevisedBy { get; set; }

        /// <summary>
        /// Origen del evento o sistema que generó la actualización del WorkItem.
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// Dirección del servidor asociado al WorkItem.
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// Fecha y hora en que se realizó la última actualización del WorkItem.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// ID del publicador que generó el evento de actualización del WorkItem.
        /// </summary>
        public string PublisherId { get; set; }

        /// <summary>
        /// Estado del WorkItem antes de la actualización.
        /// </summary>
        public WorkItemDto OldWorkItem { get; set; }

        /// <summary>
        /// Estado del WorkItem después de la actualización.
        /// </summary>
        public WorkItemDto NewWorkItem { get; set; }
    }
}

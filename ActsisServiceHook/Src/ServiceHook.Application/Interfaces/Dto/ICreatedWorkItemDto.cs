using ServiceHook.Application.Dto;

namespace ServiceHook.Application.Interfaces.Dto
{
    /// <summary>
    /// Interfaz que define los datos requeridos para representar un WorkItem recién creado.
    /// </summary>
    public interface ICreatedWorkItemDto
    {
        /// <summary>
        /// URL del proyecto asociado al WorkItem.
        /// </summary>
        public string ProjectUrl { get; set; }

        /// <summary>
        /// URL que apunta a los campos del WorkItem.
        /// </summary>
        public string WorkItemFieldsUrl { get; set; }

        /// <summary>
        /// URL que apunta al WorkItem creado.
        /// </summary>
        public string WorkItemUrl { get; set; }


        /// <summary>
        /// Path de iteración relacionado al workItem Creado.
        /// </summary>
        public string IterationPath { get; set; }

        /// <summary>
        /// URL que apunta al tipo del WorkItem.
        /// </summary>
        public string WorkItemTypeUrl { get; set; }

        /// <summary>
        /// ID único de la revisión del WorkItem.
        /// </summary>
        public int RevisionId { get; set; }

        /// <summary>
        /// Número de la revisión actual del WorkItem.
        /// </summary>
        public int Revision { get; set; }

        /// <summary>
        /// Identificador del usuario que creó el WorkItem.
        /// </summary>
        public string RevisedBy { get; set; }

        /// <summary>
        /// Origen del evento o sistema que generó la creación del WorkItem.
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// Dirección del servidor asociado al WorkItem.
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// Fecha y hora en que se creó el WorkItem.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// ID del publicador que generó el evento de creación del WorkItem.
        /// </summary>
        public string PublisherId { get; set; }

        /// <summary>
        /// Contiene los datos del WorkItem recién creado.
        /// </summary>
        public WorkItemDto WorkItem { get; set; }
    }
}

using SgiAzure.Domain.Enum;
using SgiAzure.Domain.Interfaces.Entities;

namespace SgiAzure.Domain.Entities
{
    /// <summary>
    /// Representa el historial de cambios en los requerimientos asociados con WorkItems en el sistema.
    /// </summary>
    public class Changelog : IChangeLog
    {
        /// <summary>
        /// Identificador único del changelog.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Origen del cambio. Ejemplo: el sistema o módulo que originó el cambio.
        /// </summary>
        public required string Origin { get; set; }

        /// <summary>
        /// Descripción del cambio realizado.
        /// </summary>
        public string ChangeDescription { get; set; } = string.Empty;

        /// <summary>
        /// Tipo de cambio realizado. Puede ser "creado", "actualizado" o "eliminado".
        /// </summary>
        public ChangeType ChangeType { get; set; }

        /// <summary>
        /// Fecha y hora en que se realizó el cambio.
        /// </summary>
        public DateTime ChangeAt { get; set; }

        /// <summary>
        /// Fecha y hora en que el changelog fue creado.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Fecha y hora de la última actualización del changelog (si aplica).
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Identificador del WorkItemEntity asociado con el changelog.
        /// </summary>
        public int RequirementWorkItemId { get; set; }

        /// <summary>
        /// Obtiene la relación WorkItemEntity-Requerimiento asociada.
        /// </summary>
        public RequirementWorkItem? RequirementWorkItem { get; set; }
    }
}

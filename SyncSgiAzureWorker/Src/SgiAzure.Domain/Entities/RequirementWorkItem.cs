using SgiAzure.Domain.Enum;
using SgiAzure.Domain.Interfaces.Entities;

namespace SgiAzure.Domain.Entities
{
    /// <summary>
    /// Representa una entidad que establece la relación entre un Requerimiento y un Work Item.
    /// </summary>
    public class RequirementWorkItem : IRequirementWorkItem
    {
        /// <summary>
        /// Obtiene o establece el identificador único de la relación
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el cliente al que pertenece la relación
        /// </summary>
        public required string Customer { get; set; }

        /// <summary>
        /// Obtiene o establece el estado de la relación.
        /// </summary>
        public Status Status { get; set; } = Status.Enabled;

        /// <summary>
        /// Obtiene o establece el identificador único del Requerimiento asociado.
        /// </summary>
        public int RequirementId { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del Work Item asociado.
        /// </summary>
        public int WorkItemId { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de creación de la relación entre el Requerimiento y el Work Item.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Obtiene o establece la última fecha de actualización de la relación entre el Requerimiento y el Work Item.
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Identificador del cliente al cual está asociado el registro.
        /// </summary>
        public required int CustomerId { get; set; }
    }
}

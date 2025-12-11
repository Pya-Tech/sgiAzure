using SgiAzure.Domain.Enum;

namespace SgiAzure.Domain.Interfaces.Entities
{
    /// <summary>
    /// Interfaz que representa la relación entre un Requerimiento y un Work Item.
    /// </summary>
    public interface IRequirementWorkItem
    {

        /// <summary>
        /// Obtiene o establece el Identificador único de la relación.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Obtiene o establece el ID del Requerimiento.
        /// </summary>
        int RequirementId { get; set; }

        /// <summary>
        /// Obtiene o establece el Cliente al que pertenece el requerimiento
        /// </summary>
        string Customer { get; set; }

        /// <summary>
        /// Obtiene o establece el estado de la relación
        /// </summary>
        Status Status { get; set; }
        
        /// <summary>
        /// Obtiene o establece el ID del Work Item.
        /// </summary>
        int WorkItemId { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha y hora de creación de la relación.
        /// </summary>
        DateTime CreatedAt { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha y hora de la última actualización de la relación.
        /// </summary>
        DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Identificador del cliente e base de datos
        /// </summary>
        int CustomerId { get; set; }
    }
}

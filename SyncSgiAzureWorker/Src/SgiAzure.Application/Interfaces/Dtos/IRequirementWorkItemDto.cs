namespace SgiAzure.Application.Interfaces.Dtos
{
    /// <summary>
    /// Interfaz que representa los detalles de la relación entre un Requerimiento y un Work Item.
    /// </summary>
    public interface IRequirementWorkItemDto
    {
        int Id { get; set; }

        /// <summary>
        /// Identificador único del Requerimiento asociado.
        /// </summary>
        int RequirementId { get; set; }

        /// <summary>
        /// Cliente al cual pertenece el requerimiento asociado.
        /// </summary>
        string Customer { get; set; }

        /// <summary>
        /// Identificador único del Work Item asociado.
        /// </summary>
        int WorkItemId { get; set; }

        /// <summary>
        /// Fecha de creación de la relación entre el Requerimiento y el Work Item.
        /// </summary>
        DateTime CreatedAt { get; set; }

        /// <summary>
        /// Última fecha de actualización de la relación entre el Requerimiento y el Work Item.
        /// </summary>
        DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Idetificador del customer
        /// </summary>
        int CustomerId { get; set; }
    }
}

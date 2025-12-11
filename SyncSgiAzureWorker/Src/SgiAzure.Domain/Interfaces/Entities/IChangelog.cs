using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Enum;

namespace SgiAzure.Domain.Interfaces.Entities
{
    public interface IChangeLog
    {
        /// <summary>
        /// Obtiene o establece el identificador único del registro de cambio.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el origen del cambio, indicando quién o qué generó el cambio.
        /// </summary>
        string Origin { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción del cambio realizado.
        /// </summary>
        string ChangeDescription { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de cambio realizado.
        /// </summary>
        ChangeType ChangeType { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha y hora en que ocurrió el cambio.
        /// </summary>
        DateTime ChangeAt { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha y hora en que el registro de cambio fue creado.
        /// </summary>
        DateTime CreatedAt { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha y hora en que el registro de cambio fue actualizado.
        /// </summary>
        DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la relación entre el requerimiento y el work item.
        /// </summary>
        int RequirementWorkItemId { get; set; }

        /// <summary>
        /// Obtiene la relación WorkItemEntity-requerimiento asociada
        /// </summary>
        public RequirementWorkItem? RequirementWorkItem { get; set; }
    }
}

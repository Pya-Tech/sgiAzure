using SgiAzure.Application.Interfaces.Dtos;
using SgiAzure.Domain.Entities;

namespace SgiAzure.Application.Dtos
{
    /// <summary>
    /// Representa un DTO (Data Transfer Object) para la entidad <see cref="RequirementWorkItem"/>.
    /// Este objeto es utilizado para transferir datos entre la capa de aplicación y otras capas,
    /// como la capa de presentación o la capa de infraestructura.
    /// </summary>
    public class RequirementWorkItemDto : IRequirementWorkItemDto
    {

        /// <summary>
        /// Identificador único de la relación
        /// </summary>
        public int Id { get; set; }

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
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Obtiene o establece la última fecha de actualización de la relación entre el Requerimiento y el Work Item.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Obtiene o establece el dueño del requerimiento o workItem
        /// </summary>
        public required string Customer { get; set; }

        /// <summary>
        /// Identificador del customer
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Convierte una entidad de dominio <see cref="RequirementWorkItem"/> en un DTO <see cref="RequirementWorkItemDto"/>.
        /// Este método estático permite transformar una entidad de dominio en un objeto DTO.
        /// </summary>
        /// <param name="entity">La entidad de dominio que se va a convertir en un DTO.</param>
        /// <returns>Un objeto <see cref="RequirementWorkItemDto"/> con los datos de la entidad proporcionada.</returns>
        /// <exception cref="ArgumentNullException">Se lanza si la entidad proporcionada es <c>null</c>.</exception>
        public static RequirementWorkItemDto FromDomainEntity(RequirementWorkItem entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");

            return new RequirementWorkItemDto
            {
                Id = entity.Id,
                RequirementId = entity.RequirementId,
                Customer = entity.Customer,
                WorkItemId = entity.WorkItemId,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }

        /// <summary>
        /// Convierte el DTO <see cref="RequirementWorkItemDto"/> en una entidad de dominio <see cref="RequirementWorkItem"/>.
        /// Este método de instancia convierte los datos del DTO en una entidad de dominio.
        /// </summary>
        /// <returns>Una nueva instancia de <see cref="RequirementWorkItem"/> con los datos del DTO.</returns>
        public RequirementWorkItem ToDomainEntity()
        {
            return new RequirementWorkItem
            {
                Id = Id,
                RequirementId = RequirementId,
                Customer = Customer,
                WorkItemId = WorkItemId,
                CreatedAt = CreatedAt,
                UpdatedAt = UpdatedAt,
                CustomerId = CustomerId
            };
        }
    }
}

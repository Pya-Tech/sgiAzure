namespace SgiAzure.Domain.Interfaces.Entities
{
    /// <summary>
    /// Representa un mapeo entre dos parámetros de campo,
    /// permitiendo vincular un campo del SGI con su campo equivalente en Azure.
    /// Equivale a la tabla <c>field_mappings</c>.
    /// </summary>
    public interface IFieldMapping
    {
        /// <summary>
        /// Identificador único del mapeo.
        /// </summary>
        int? Id { get; set; }

        /// <summary>
        /// Identificador del campo origen (SGI o Azure).
        /// Corresponde a <c>field_source</c>.
        /// </summary>
        int FieldSourceId { get; set; }

        /// <summary>
        /// Identificador del campo destino en el otro sistema.
        /// Corresponde a <c>field_mapped</c>.
        /// </summary>
        int FieldMappedId { get; set; }

        /// <summary>
        /// Identificador del cliente al que pertenece el mapeo.
        /// </summary>
        int CustomerId { get; set; }

        /// <summary>
        /// Indica si el mapeo está habilitado.
        /// </summary>
        bool Enabled { get; set; }

        /// <summary>
        /// Fecha de creación del registro.
        /// </summary>
        DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Fecha de última actualización.
        /// </summary>
        DateTimeOffset? UpdatedAt { get; set; }
    }
}

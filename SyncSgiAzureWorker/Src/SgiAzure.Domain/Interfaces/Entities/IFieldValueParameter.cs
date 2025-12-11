using System;

namespace SgiAzure.Domain.Interfaces.Entities
{
    /// <summary>
    /// Representa un valor permitido para un parámetro de campo,
    /// tal como estados, prioridades u opciones configurables.
    /// Equivale a la tabla <c>field_value_parameters</c>.
    /// </summary>
    public interface IFieldValueParameter
    {
        /// <summary>
        /// Identificador único del valor.
        /// </summary>
        int? Id { get; set; }

        /// <summary>
        /// Código del valor (ej.: "A", "New", "1").
        /// </summary>
        string ValueCode { get; set; }

        /// <summary>
        /// Descripción legible del valor.
        /// </summary>
        string ValueDescription { get; set; }

        /// <summary>
        /// Indica si el valor está activo.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Fecha de creación del valor.
        /// </summary>
        DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Fecha de última actualización.
        /// </summary>
        DateTimeOffset? UpdatedAt { get; set; }

        /// <summary>
        /// Identificador del parámetro al que pertenece.
        /// </summary>
        int FieldParameterId { get; set; }
    }
}

using SgiAzure.Domain.Enum;

namespace SgiAzure.Domain.Interfaces.Entities
{
    /// <summary>
    /// Representa un parámetro de campo configurable para SGI o Azure,
    /// como estados, prioridades o cualquier metadato parametrizable.
    /// Equivale a la tabla <c>field_parameters</c>.
    /// </summary>
    public interface IFieldParameter
    {
        /// <summary>
        /// Identificador único del parámetro.
        /// </summary>
        int? Id { get; set; }

        /// <summary>
        /// Código del parámetro (ej.: "status", "priority").
        /// </summary>
        string Code { get; set; }

        /// <summary>
        /// Ruta o clave del campo en Azure, si aplica.
        /// </summary>
        string? CodeValue { get; set; }

        /// <summary>
        /// Descripción del parámetro.
        /// </summary>
        string? Description { get; set; }

        /// <summary>
        /// Indica si el parámetro pertenece a SGI o Azure.
        /// </summary>
        Source SourceType { get; set; }

        /// <summary>
        /// Tipo de dato asociado al parámetro.
        /// </summary>
        SgiAzureDataType DataType { get; set; }

        /// <summary>
        /// Indica si el parámetro está activo.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Fecha de creación.
        /// </summary>
        DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Fecha de última actualización.
        /// </summary>
        DateTimeOffset? UpdatedAt { get; set; }
    }
}

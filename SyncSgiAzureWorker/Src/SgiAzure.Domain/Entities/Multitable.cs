using SgiAzure.Domain.Interfaces.Entities;
using System;

namespace SgiAzure.Domain.Entities
{
    /// <summary>
    /// Representa una tabla multiusos con diversas propiedades para su configuración y uso en el sistema.
    /// Implementa la interfaz <see cref="IMultiTable"/>.
    /// </summary>
    public class Multitable : IMultiTable
    {
        /// <summary>
        /// Nombre de la tabla.
        /// </summary>
        public string? TableName { get; set; } = default!;

        /// <summary>
        /// Descripción de la tabla.
        /// </summary>
        public string? TableDescription { get; set; } = default!;

        /// <summary>
        /// Tipo de tabla.
        /// </summary>
        public int? TableType { get; set; }

        /// <summary>
        /// Código identificador único.
        /// </summary>
        public string? CodeId { get; set; } = default!;

        /// <summary>
        /// Código principal.
        /// </summary>
        public string? Code { get; set; } = default!;

        /// <summary>
        /// Descripción del código.
        /// </summary>
        public string? CodeDescription { get; set; } = default!;

        /// <summary>
        /// Código auxiliar.
        /// </summary>
        public string? AuxiliaryCode { get; set; } = default!;

        /// <summary>
        /// Código de carácter.
        /// </summary>
        public string? CharacterCode { get; set; } = default!;

        /// <summary>
        /// Código numérico.
        /// </summary>
        public int? NumericCode { get; set; }

        /// <summary>
        /// Valor de carácter.
        /// </summary>
        public string? CharacterValue { get; set; } = default!;

        /// <summary>
        /// Valor numérico.
        /// </summary>
        public decimal? NumericValue { get; set; } = default!;

        /// <summary>
        /// Valor adicional 1.
        /// </summary>
        public string? Value1 { get; set; } = default!;

        /// <summary>
        /// Valor adicional 2.
        /// </summary>
        public string? Value2 { get; set; } = default!;

        /// <summary>
        /// Valor adicional 3.
        /// </summary>
        public string? Value3 { get; set; } = default!;

        /// <summary>
        /// Valor adicional 4.
        /// </summary>
        public string? Value4 { get; set; } = default!;

        /// <summary>
        /// Valor adicional 5.
        /// </summary>
        public string? Value5 { get; set; } = default!;

        /// <summary>
        /// Valor adicional 6.
        /// </summary>
        public string? Value6 { get; set; } = default!;

        /// <summary>
        /// Indicadores o banderas.
        /// </summary>
        public string? Indicators { get; set; } = default!;

        /// <summary>
        /// Fecha de desactivación.
        /// </summary>
        public DateTime? DeactivationDate { get; set; }

        /// <summary>
        /// Fecha de desactivación en formato juliano.
        /// </summary>
        public int? DeactivationDateJulian { get; set; }

        /// <summary>
        /// Nombre del sistema.
        /// </summary>
        public string? System { get; set; } = default!;

        /// <summary>
        /// Nombre del módulo.
        /// </summary>
        public string? Module { get; set; } = default!;

        /// <summary>
        /// Nombre del submódulo.
        /// </summary>
        public string? Submodule { get; set; } = default!;

        /// <summary>
        /// Indicador de estado activo.
        /// </summary>
        public string? IsActive { get; set; } = default!;

        /// <summary>
        /// Clave identificadora única.
        /// </summary>
        public string? Key { get; set; } = default!;

        /// <summary>
        /// Identificador de fila.
        /// </summary>
        public string? RowId { get; set; } = default!;
    }
}

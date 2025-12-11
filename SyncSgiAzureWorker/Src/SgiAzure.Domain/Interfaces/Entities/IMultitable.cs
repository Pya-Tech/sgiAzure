using System;

namespace SgiAzure.Domain.Interfaces.Entities
{
    /// <summary>
    /// Define las propiedades y métodos asociados a una tabla multiusos.
    /// </summary>
    public interface IMultiTable
    {
        /// <summary>
        /// Nombre de la tabla.
        /// </summary>
        public string? TableName { get; set; }

        /// <summary>
        /// Descripción de la tabla.
        /// </summary>
        public string? TableDescription { get; set; }

        /// <summary>
        /// Tipo de tabla.
        /// </summary>
        public int? TableType { get; set; }

        /// <summary>
        /// Código identificador único.
        /// </summary>
        public string? CodeId { get; set; }

        /// <summary>
        /// Código principal.
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Descripción del código.
        /// </summary>
        public string? CodeDescription { get; set; }

        /// <summary>
        /// Código auxiliar.
        /// </summary>
        public string? AuxiliaryCode { get; set; }

        /// <summary>
        /// Código de carácter.
        /// </summary>
        public string? CharacterCode { get; set; }

        /// <summary>
        /// Código numérico.
        /// </summary>
        public int? NumericCode { get; set; }

        /// <summary>
        /// Valor de carácter.
        /// </summary>
        public string? CharacterValue { get; set; }

        /// <summary>
        /// Valor numérico.
        /// </summary>
        public decimal? NumericValue { get; set; }

        /// <summary>
        /// Valor adicional 1.
        /// </summary>
        public string? Value1 { get; set; }

        /// <summary>
        /// Valor adicional 2.
        /// </summary>
        public string? Value2 { get; set; }

        /// <summary>
        /// Valor adicional 3.
        /// </summary>
        public string? Value3 { get; set; }

        /// <summary>
        /// Valor adicional 4.
        /// </summary>
        public string? Value4 { get; set; }

        /// <summary>
        /// Valor adicional 5.
        /// </summary>
        public string? Value5 { get; set; }

        /// <summary>
        /// Valor adicional 6.
        /// </summary>
        public string? Value6 { get; set; }

        /// <summary>
        /// Indicadores o banderas.
        /// </summary>
        public string? Indicators { get; set; }

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
        public string? System { get; set; }

        /// <summary>
        /// Nombre del módulo.
        /// </summary>
        public string? Module { get; set; }

        /// <summary>
        /// Nombre del submódulo.
        /// </summary>
        public string? Submodule { get; set; }

        /// <summary>
        /// Indicador de estado activo.
        /// </summary>
        public string? IsActive { get; set; }

        /// <summary>
        /// Clave identificadora única.
        /// </summary>
        public string? Key { get; set; }

        /// <summary>
        /// Identificador de fila.
        /// </summary>
        public string? RowId { get; set; }
    }
}

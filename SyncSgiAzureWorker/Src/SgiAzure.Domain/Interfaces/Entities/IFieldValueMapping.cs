using System;

namespace SgiAzure.Domain.Interfaces.Entities
{
    /// <summary>
    /// Representa un mapeo de valores entre dos sistemas (SGI y Azure DevOps),
    /// permitiendo traducir un valor de un campo en SGI hacia su valor equivalente
    /// en Azure, o viceversa.
    /// </summary>
    public interface IFieldValueMapping
    {
        /// <summary>
        /// Identificador único del mapeo de valores.
        /// Corresponde a la columna <c>id</c> de la tabla <c>field_value_mappings</c>.
        /// Puede ser nulo si la entidad no ha sido persistida aún.
        /// </summary>
        int? Id { get; set; }

        /// <summary>
        /// Identificador del valor local (SGI o Azure) que se desea mapear.
        /// Corresponde a la columna <c>local_value_id</c> y es una FK hacia <c>field_value_parameters.id</c>.
        /// </summary>
        int LocalValueId { get; set; }

        /// <summary>
        /// Identificador del valor equivalente en el otro sistema.
        /// Corresponde a la columna <c>equivalent_value_id</c>, FK hacia <c>field_value_parameters.id</c>.
        /// </summary>
        int EquivalentValueId { get; set; }

        /// <summary>
        /// Identificador del parámetro al que pertenece este mapeo.
        /// Se relaciona con la columna <c>field_parameters_id</c>.
        /// Esto permite diferenciar mapeos de:
        /// - estados,
        /// - prioridades,
        /// - tipos de campo,
        /// - y otros valores parametrizables.
        /// </summary>
        int FieldParameterId { get; set; }

        /// <summary>
        /// Sistema destino al que se refiere el mapeo.
        /// Generalmente "azure" o "sgi".
        /// Representa la columna <c>target_system</c>.
        /// </summary>
        string? TargetSystem { get; set; }

        /// <summary>
        /// Identificador del cliente al que pertenece el mapeo.
        /// Equivale a la columna <c>customers_id</c> y soporta escenarios multi-tenant.
        /// </summary>
        int CustomerId { get; set; }

        /// <summary>
        /// Fecha y hora de creación del registro de mapeo.
        /// Representa la columna <c>created_at</c>.
        /// Puede ser nulo si la persistencia aún no se ha realizado.
        /// </summary>
        DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Fecha de la última actualización del registro del mapeo.
        /// Equivale a la columna <c>updated_at</c>.
        /// Puede ser nulo si no se han realizado modificaciones posteriores.
        /// </summary>
        DateTimeOffset? UpdatedAt { get; set; }
    }
}

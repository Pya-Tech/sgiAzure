namespace SgiAzure.Domain.Interfaces.Entities
{
    /// <summary>
    /// Representa la relación de mapeo entre un artefacto del SGI (requerimiento)
    /// y un artefacto equivalente en Azure DevOps (work item).
    /// </summary>
    public interface IWorkArtifactMapping
    {
        /// <summary>
        /// Identificador único del registro de mapeo.
        /// Equivale a la columna <c>id</c> en la tabla <c>work_artifacts_mappings</c>.
        /// Puede ser nulo cuando la entidad aún no ha sido persistida.
        /// </summary>
        int? Id { get; set; }

        /// <summary>
        /// Indica si la relación de mapeo está habilitada.
        /// Un valor <c>true</c> implica que el mapeo es válido y aplicable.
        /// </summary>
        bool Enabled { get; set; }

        /// <summary>
        /// Fecha y hora de creación del registro, expresada en formato <see cref="DateTimeOffset"/>.
        /// Normalmente se corresponde con la columna <c>created_at</c> de la base de datos.
        /// </summary>
        DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Fecha y hora de la última actualización del registro.
        /// Si no ha habido modificaciones posteriores a su creación, puede ser nulo.
        /// Corresponde a la columna <c>updated_at</c>.
        /// </summary>
        DateTimeOffset? UpdatedAt { get; set; }

        /// <summary>
        /// Identificador del cliente (tenant) al que pertenece este mapeo.
        /// Se vincula a la tabla <c>customers</c> mediante la columna <c>customers_id</c>.
        /// </summary>
        int CustomerId { get; set; }

        /// <summary>
        /// Identificador del artefacto SGI (requerimiento) que se desea mapear.
        /// Hace referencia al registro en la tabla <c>work_artifacts</c> con tipo <c>requirement</c>.
        /// </summary>
        int RequirementArtifactId { get; set; }

        /// <summary>
        /// Identificador del artefacto de Azure DevOps (work item) asociado.
        /// Hace referencia a la entrada de <c>work_artifacts</c> con tipo <c>workitem</c>.
        /// Este valor determina el tipo de Work Item que se creará en Azure.
        /// </summary>
        int WorkitemArtifactId { get; set; }
    }
}

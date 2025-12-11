using System;
using SgiAzure.Domain.Enum;

namespace SgiAzure.Domain.Interfaces.Entities
{
    /// <summary>
    /// Representa un artefacto dentro del modelo de integración SGI–Azure.
    /// 
    /// Un artefacto puede corresponder a:
    /// - Un tipo de requerimiento en SGI (<see cref="WorkArtifactType.Requirement"/>)
    /// - Un tipo de Work Item en Azure DevOps (<see cref="WorkArtifactType.WorkItem"/>)
    /// </summary>
    public interface IWorkArtifact
    {
        /// <summary>
        /// Identificador único del artefacto.
        /// Equivale a la columna <c>id</c> de la tabla <c>work_artifacts</c>.
        /// Puede ser nulo cuando la entidad aún no ha sido persistida.
        /// </summary>
        int? Id { get; set; }

        /// <summary>
        /// Nombre del artefacto.
        /// Para SGI suele ser el código del requerimiento (ej.: "GT2", "ADM").
        /// Para Azure suele ser el tipo del Work Item (ej.: "Bug", "Task").
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Descripción del artefacto.
        /// Puede incluir información funcional o semántica,
        /// como "Garantía - Parcial", "Tipo de WorkItem Azure: Task", etc.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Tipo de artefacto dentro de la integración.
        /// Determina si corresponde a un artefacto de SGI (requerimiento)
        /// o a uno de Azure DevOps (work item).
        /// </summary>
        WorkArtifactType Type { get; set; }

        /// <summary>
        /// Fecha y hora de creación del artefacto.
        /// Equivale a la columna <c>created_at</c> en la base de datos.
        /// </summary>
        DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Fecha y hora de la última actualización del artefacto.
        /// Para registros no modificados posteriormente a su creación,
        /// este valor puede mantenerse igual a <see cref="CreatedAt"/>.
        /// </summary>
        DateTimeOffset? UpdatedAt { get; set; }
    }
}

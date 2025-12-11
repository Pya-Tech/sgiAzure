using System;

namespace SgiAzure.Domain.Interfaces.Entities
{
    /// <summary>
    /// Representa una entidad de cliente que contiene la información de identificación
    /// y los datos necesarios para integrarse con Azure DevOps u otros sistemas externos.
    /// </summary>
    public interface ICustomer
    {
        /// <summary>
        /// Obtiene o establece el identificador único del cliente.
        /// </summary>
        int? Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre completo o nombre descriptivo del cliente.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Obtiene o establece el dominio asociado al cliente (por ejemplo, dominio de organización).
        /// </summary>
        string Domain { get; set; }

        /// <summary>
        /// Obtiene o establece el token de acceso utilizado para autenticarse frente a servicios externos.
        /// </summary>
        string AccessToken { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la organización en Azure DevOps asociada al cliente.
        /// </summary>
        string Organization { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del proyecto en Azure DevOps vinculado al cliente.
        /// </summary>
        string Project { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de usuario utilizado para identificar al cliente en el sistema.
        /// </summary>
        string UserName { get; set; }

        /// <summary>
        /// Obtiene o establece la dirección de correo electrónico principal del cliente.
        /// </summary>
        string? Email { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha y hora de creación del registro del cliente.
        /// </summary>
        DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha y hora de la última actualización del cliente.
        /// </summary>
        DateTimeOffset? UpdatedAt { get; set; }
    }
}

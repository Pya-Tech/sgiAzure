using SgiAzure.Domain.Interfaces.Entities;

namespace SgiAzure.Domain.Entities
{
    /// <summary>
    /// Representa a un cliente configurado para integrarse con Azure DevOps,
    /// incluyendo credenciales, configuración de proyecto y metadatos.
    /// </summary>
    public class Customer : ICustomer
    {
        /// <summary>
        /// Identificador único del cliente. Puede ser nulo si aún no ha sido persistido.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Nombre descriptivo del cliente.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Dominio asociado al cliente.
        /// </summary>
        public string Domain { get; set; } = string.Empty;

        /// <summary>
        /// Token de acceso para autenticación con servicios externos.
        /// </summary>
        public string AccessToken { get; set; } = string.Empty;

        /// <summary>
        /// Organización de Azure DevOps asociada al cliente.
        /// </summary>
        public string Organization { get; set; } = string.Empty;

        /// <summary>
        /// Proyecto de Azure DevOps vinculado al cliente.
        /// </summary>
        public string Project { get; set; } = string.Empty;

        /// <summary>
        /// Nombre de usuario del cliente.
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Correo electrónico principal del cliente.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Fecha y hora en que se creó el cliente.
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// Fecha y hora de la última actualización del cliente.
        /// </summary>
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}

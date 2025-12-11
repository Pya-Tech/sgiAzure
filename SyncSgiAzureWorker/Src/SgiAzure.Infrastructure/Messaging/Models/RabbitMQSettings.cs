namespace Infrastructure.Messaging.Models
{
    /// <summary>
    /// Configuración para la conexión a RabbitMQ.
    /// Contiene las propiedades necesarias para configurar el acceso al servidor RabbitMQ.
    /// </summary>
    public class RabbitMQSettings
    {
        /// <summary>
        /// Obtiene o establece el nombre o dirección del host de RabbitMQ.
        /// </summary>
        public string Host { get; set; } = default!;

        /// <summary>
        /// Obtiene o establece el número de puerto en el que RabbitMQ está escuchando.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Número máximo de intentos para reintentar proceso de cola
        /// </summary>
        public int MaxRetryAttemps { get; set; }


        /// <summary>
        /// Número límite de mensajes a procesar en el consumidor
        /// </summary>
        public ushort PrefetchCount { get; set; } = 10;

        /// <summary>
        /// Obtiene o establece las credenciales para autenticar el acceso a RabbitMQ.
        /// </summary>
        public RabbitMQCredentials Credentials { get; set; } = new();

    }

    /// <summary>
    /// Credenciales para la autenticación en RabbitMQ.
    /// Contiene el nombre de usuario y la contraseña necesarios para acceder al servidor RabbitMQ.
    /// </summary>
    public class RabbitMQCredentials
    {
        /// <summary>
        /// Obtiene o establece el nombre de usuario para autenticar en RabbitMQ.
        /// </summary>
        public string Username { get; set; } = default!;

        /// <summary>
        /// Obtiene o establece la contraseña para autenticar en RabbitMQ.
        /// </summary>
        public string Password { get; set; } = default!;

        /// <summary>
        /// Atributo que guarda el nombre de la conexión(Visible desde el panel de administración de RabbitMq)
        /// </summary>
        public string ClientProvidedName { get; set; } = "SgiAzureApp";
    }


}

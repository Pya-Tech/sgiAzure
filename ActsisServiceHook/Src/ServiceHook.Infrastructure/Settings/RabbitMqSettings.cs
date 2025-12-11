namespace ServiceHook.Infrastructure.Settings
{
    /// <summary>
    /// Configuración para la conexión a RabbitMQ.
    /// Contiene las propiedades necesarias para configurar el acceso al servidor RabbitMQ, incluyendo el host, el puerto, el número máximo de intentos de reintento,
    /// el exchange y las claves de enrutamiento para diferentes tipos de acciones.
    /// </summary>
    public class RabbitMQSettings
    {
        /// <summary>
        /// Obtiene o establece el nombre o dirección del host de RabbitMQ.
        /// </summary>
        public required string Host { get; set; }

        /// <summary>
        /// Obtiene o establece el número de puerto en el que RabbitMQ está escuchando.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Obtiene o establece el número máximo de intentos para reintentar el proceso de la cola.
        /// </summary>
        public required int MaxRetryAttemps { get; set; }


        /// <summary>
        /// Obtiene o establece las credenciales para la autenticación en RabbitMQ.
        /// </summary>
        public required RabbitMQCredentials Credentials { get; set; }
    }

    /// <summary>
    /// Configuración de las credenciales necesarias para la autenticación en RabbitMQ.
    /// Incluye el nombre de usuario y la contraseña para acceder al servidor RabbitMQ.
    /// </summary>
    public class RabbitMQCredentials
    {
        /// <summary>
        /// Obtiene o establece el nombre de usuario para autenticar en RabbitMQ.
        /// </summary>
        public required string Username { get; set; }

        /// <summary>
        /// Obtiene o establece la contraseña para autenticar en RabbitMQ.
        /// </summary>
        public required string Password { get; set; }
    }
}

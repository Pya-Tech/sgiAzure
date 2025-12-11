namespace SgiAzure.Application.Interfaces.Dtos
{
    /// <summary>
    /// longerfaz que define las propiedades básicas de un DTO de usuario.
    /// Un DTO (Data Transfer Object) es una estructura utilizada para transferir datos entre diferentes capas.
    /// </summary>
    public interface IUserDto
    {
        /// <summary>
        /// Obtiene o establece el sistema al que pertenece el usuario.
        /// </summary>
        string UserSystem { get; set; }

        /// <summary>
        /// Obtiene o establece la cédula del usuario.
        /// </summary>
        long IdCard { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del usuario.
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Obtiene o establece la dependencia a la que pertenece el usuario.
        /// </summary>
        string Dependency { get; set; }

        /// <summary>
        /// Obtiene o establece el cargo del usuario.
        /// </summary>
        string Position { get; set; }

        /// <summary>
        /// Obtiene o establece la zona a la que pertenece el usuario.
        /// </summary>
        int? Zone { get; set; }

        /// <summary>
        /// Obtiene o establece el path de la impresora principal del usuario.
        /// </summary>
        string Printer { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del usuario.
        /// </summary>
        string Status { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad máxima de sesiones permitidas para el usuario.
        /// </summary>
        int? MaxSessions { get; set; }

        /// <summary>
        /// Obtiene o establece el correo electrónico del usuario.
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Obtiene o establece el path de la impresora auxiliar del usuario.
        /// </summary>
        string AuxiliaryPrinter { get; set; }

        /// <summary>
        /// Obtiene o establece el número de teléfono móvil del usuario.
        /// </summary>
        long? MobilePhone { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del usuario jefe o supervisor.
        /// </summary>
        string SupervisorUser { get; set; }

        /// <summary>
        /// Obtiene o establece la ciudad de expedición de la cédula del usuario.
        /// </summary>
        string IdCardIssuedCity { get; set; }

        /// <summary>
        /// Obtiene o establece la contraseña encriptada del usuario.
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de usuario (por ejemplo, "b" para base de datos).
        /// </summary>
        string UserType { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de desactivación del usuario.
        /// </summary>
        DateTime? DeactivationDate { get; set; }

        /// <summary>
        /// Obtiene o establece la foto del usuario en formato de arreglo de bytes.
        /// </summary>
        byte[] ProfilePicture { get; set; }

        /// <summary>
        /// Obtiene o establece la oficina a la que pertenece el usuario.
        /// </summary>
        string Office { get; set; }

        /// <summary>
        /// Obtiene o establece la extensión telefónica del usuario.
        /// </summary>
        int? Extension { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de creación del usuario.
        /// </summary>
        DateTime? CreationDate { get; set; }

    }
}

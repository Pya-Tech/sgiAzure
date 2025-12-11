namespace SgiAzure.Domain.Entities
{
    /// <summary>
    /// Representa un usuario en el sistema.
    /// </summary>
    public class User : IUser
    {
        /// <summary>
        /// Obtiene o establece el usuario del sistema (valor predeterminado: cadena vacía).
        /// </summary>
        public string UserSystem { get; set; } = default!;

        /// <summary>
        /// Obtiene o establece la cédula del usuario (valor predeterminado: 0).
        /// </summary>
        public long IdCard { get; set; } = default!;

        /// <summary>
        /// Obtiene o establece el nombre del usuario (valor predeterminado: cadena vacía).
        /// </summary>
        public string FirstName { get; set; } = default!;

        /// <summary>
        /// Obtiene o establece la dependencia a la que pertenece el usuario (valor predeterminado: cadena vacía).
        /// </summary>
        public string? Dependency { get; set; }

        /// <summary>
        /// Obtiene o establece el cargo del usuario (valor predeterminado: cadena vacía).
        /// </summary>
        public string? Position { get; set; } = default!;

        /// <summary>
        /// Obtiene o establece la zona a la que pertenece el usuario (valor predeterminado: null).
        /// </summary>
        public int? Zone { get; set; } = null;

        /// <summary>
        /// Obtiene o establece el path de la impresora principal (valor predeterminado: cadena vacía).
        /// </summary>
        public string? Printer { get; set; } = default!;

        /// <summary>
        /// Obtiene o establece el estado del usuario (valor predeterminado: "n" para no activo).
        /// </summary>
        public string Status { get; set; } = default!;

        /// <summary>
        /// Obtiene o establece la cantidad máxima de sesiones permitidas (valor predeterminado: null).
        /// </summary>
        public int? MaxSessions { get; set; } = null;

        /// <summary>
        /// Obtiene o establece el correo electrónico del usuario (valor predeterminado: cadena vacía).
        /// </summary>
        public string? Email { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece el path de la impresora auxiliar (valor predeterminado: cadena vacía).
        /// </summary>
        public string? AuxiliaryPrinter { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece el número de teléfono celular (valor predeterminado: null).
        /// </summary>
        public long? MobilePhone { get; set; } = null;

        /// <summary>
        /// Obtiene o establece el usuario jefe (valor predeterminado: cadena vacía).
        /// </summary>
        public string? SupervisorUser { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece la ciudad de expedición de la cédula (valor predeterminado: cadena vacía).
        /// </summary>
        public string? IdCardIssuedCity { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece la contraseña encriptada del usuario (valor predeterminado: cadena vacía).
        /// </summary>
        public string? Password { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece el tipo de usuario (valor predeterminado: "b" para base de datos).
        /// </summary>
        public string? UserType { get; set; } = "b";

        /// <summary>
        /// Obtiene o establece la fecha de desactivación del usuario (valor predeterminado: null).
        /// </summary>
        public DateTime? DeactivationDate { get; set; } = null;

        /// <summary>
        /// Obtiene o establece la foto del usuario (valor predeterminado: arreglo vacío).
        /// </summary>
        public byte[]? ProfilePicture { get; set; } = Array.Empty<byte>();

        /// <summary>
        /// Obtiene o establece la oficina a la que pertenece el usuario (valor predeterminado: cadena vacía).
        /// </summary>
        public string Office { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece la extensión telefónica (valor predeterminado: null).
        /// </summary>
        public int? Extension { get; set; } = null;

        /// <summary>
        /// Obtiene o establece la fecha de creación del usuario (valor predeterminado: fecha y hora actuales en formato UTC).
        /// </summary>
        public DateTime? CreationDate { get; set; } = DateTime.UtcNow;
    }
}

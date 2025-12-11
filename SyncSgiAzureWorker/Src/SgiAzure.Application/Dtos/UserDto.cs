using SgiAzure.Application.Interfaces.Dtos;
using SgiAzure.Domain.Entities;
using System.Text.Json.Serialization;

namespace SgiAzure.Application.Dtos
{
    /// <summary>
    /// Representa un usuario en el sistema como un DTO.
    /// Esta clase es utilizada para la transferencia de datos entre capas de la aplicación.
    /// </summary>
    public class UserDto : IUserDto
    {
        /// <summary>
        /// Obtiene o establece el sistema al que pertenece el usuario.
        /// </summary>
        [JsonPropertyName("user_system")]
        public string UserSystem { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece la cédula del usuario.
        /// </summary>
        [JsonPropertyName("id_card")]
        public long IdCard { get; set; } = 0;

        /// <summary>
        /// Obtiene o establece el nombre del usuario.
        /// </summary>
        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece la dependencia a la que pertenece el usuario.
        /// </summary>
        [JsonPropertyName("dependency")]
        public string Dependency { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece el cargo del usuario.
        /// </summary>
        [JsonPropertyName("position")]
        public string Position { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece la zona a la que pertenece el usuario.
        /// </summary>
        [JsonPropertyName("zone")]
        public int? Zone { get; set; } = null;

        /// <summary>
        /// Obtiene o establece el path de la impresora principal del usuario.
        /// </summary>
        [JsonPropertyName("printer")]
        public string? Printer { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece el estado del usuario.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; } = "n";

        /// <summary>
        /// Obtiene o establece la cantidad máxima de sesiones permitidas para el usuario.
        /// </summary>
        [JsonPropertyName("max_sessions")]
        public int? MaxSessions { get; set; } = null;

        /// <summary>
        /// Obtiene o establece el correo electrónico del usuario.
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece el path de la impresora auxiliar del usuario.
        /// </summary>
        [JsonPropertyName("auxiliary_printer")]
        public string? AuxiliaryPrinter { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece el número de teléfono móvil del usuario.
        /// </summary>
        [JsonPropertyName("mobile_phone")]
        public long? MobilePhone { get; set; } = null;

        /// <summary>
        /// Obtiene o establece el nombre del usuario jefe o supervisor.
        /// </summary>
        [JsonPropertyName("supervisor_user")]
        public string SupervisorUser { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece la ciudad de expedición de la cédula del usuario.
        /// </summary>
        [JsonPropertyName("id_card_issued_city")]
        public string? IdCardIssuedCity { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece la contraseña encriptada del usuario.
        /// </summary>
        [JsonPropertyName("password")]
        public string? Password { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece el tipo de usuario (por ejemplo, "b" para base de datos).
        /// </summary>
        [JsonPropertyName("user_type")]
        public string UserType { get; set; } = "b";

        /// <summary>
        /// Obtiene o establece la fecha de desactivación del usuario.
        /// </summary>
        [JsonPropertyName("deactivation_date")]
        public DateTime? DeactivationDate { get; set; } = null;

        /// <summary>
        /// Obtiene o establece la foto del usuario en formato de arreglo de bytes.
        /// </summary>
        [JsonPropertyName("profile_picture")]
        public byte[] ProfilePicture { get; set; } = Array.Empty<byte>();

        /// <summary>
        /// Obtiene o establece la oficina a la que pertenece el usuario.
        /// </summary>
        [JsonPropertyName("office")]
        public string Office { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece la extensión telefónica del usuario.
        /// </summary>
        [JsonPropertyName("extension")]
        public int? Extension { get; set; } = null;

        /// <summary>
        /// Obtiene o establece la fecha de creación del usuario.
        /// </summary>
        [JsonPropertyName("creation_date")]
        public DateTime? CreationDate { get; set; } = DateTime.UtcNow;


        /// <summary>
        /// Convierte el DTO a una entidad de dominio.
        /// </summary>
        /// <returns>Entidad de dominio correspondiente.</returns>
        public User ToDomainEntity()
        {
            return new User
            {
                UserSystem = UserSystem,
                IdCard = IdCard,
                FirstName = FirstName ?? string.Empty,
                Dependency = Dependency,
                Position = Position,
                Zone = Zone,
                Printer = Printer,
                Status = Status,
                MaxSessions = MaxSessions,
                Email = Email,
                AuxiliaryPrinter = AuxiliaryPrinter,
                MobilePhone = MobilePhone,
                SupervisorUser = SupervisorUser,
                IdCardIssuedCity = IdCardIssuedCity,
                Password = Password,
                UserType = UserType,
                DeactivationDate = DeactivationDate,
                ProfilePicture = ProfilePicture,
                Office = Office,
                Extension = Extension,
                CreationDate = CreationDate
            };
        }

        /// <summary>
        /// Convierte una entidad de dominio a un DTO.
        /// </summary>
        /// <param name="user">Entidad de dominio que representa un usuario.</param>
        /// <returns>DTO correspondiente.</returns>
        public static UserDto FromDomainEntity(User user)
        {
            return new UserDto
            {
                UserSystem = user.UserSystem,
                IdCard = user.IdCard,
                FirstName = user.FirstName,
                Dependency = user.Dependency ?? string.Empty,
                Position = user.Position ?? string.Empty,
                Zone = user.Zone,
                Printer = user.Printer,
                Status = user.Status,
                MaxSessions = user.MaxSessions,
                Email = user.Email ?? string.Empty,
                AuxiliaryPrinter = user.AuxiliaryPrinter,
                MobilePhone = user.MobilePhone,
                SupervisorUser = user.SupervisorUser ?? string.Empty,
                IdCardIssuedCity = user.IdCardIssuedCity,
                Password = user.Password,
                UserType = user.UserType ?? string.Empty,
                DeactivationDate = user.DeactivationDate,
                ProfilePicture = user.ProfilePicture ?? [],
                Office = user.Office,
                Extension = user.Extension,
                CreationDate = user.CreationDate
            };
        }
    }
}

using SgiAzure.Application.Dtos;
using SgiAzure.Application.Interfaces.Dtos;

namespace SgiAzure.Application.Interfaces.Services
{
    /// <summary>
    /// Interface que define los métodos de servicio para gestionar usuarios.
    /// </summary>
    public interface IUserService<T> where T : IUserDto
    {
        /// <summary>
        /// Obtiene todos los usuarios.
        /// </summary>
        /// <returns>Lista de DTOs de usuarios.</returns>
        Task<IEnumerable<T>> GetAllUsersAsync();

        /// <summary>
        /// Obtiene un usuario por su ID de cédula.
        /// </summary>
        /// <param name="idCard">Cédula del usuario.</param>
        /// <returns>DTO del usuario.</returns>
        Task<T?> GetUserByIdAsync(int idCard);

        /// <summary>
        /// Método encargado de obtener un usuario por su nombre de usuario
        /// </summary>
        /// <param name="username">Nombre de usuario</param>
        /// <returns>DTO del usuario.</returns>
        Task<T?> GetUserByUsername(string username);

        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="userDto">DTO del usuario a crear.</param>
        /// <returns>DTO del usuario creado.</returns>
        Task<T?> CreateUserAsync(UserDto userDto);

        /// <summary>
        /// Actualiza un usuario existente.
        /// </summary>
        /// <param name="idCard">Cédula del usuario a actualizar.</param>
        /// <param name="userDto">DTO del usuario con los nuevos datos.</param>
        /// <returns>DTO del usuario actualizado.</returns>
        Task<T?> UpdateUserAsync(int idCard, UserDto userDto);

        /// <summary>
        /// Elimina un usuario por su ID de cédula.
        /// </summary>
        /// <param name="idCard">Cédula del usuario a eliminar.</param>
        /// <returns>True si la eliminación fue exitosa, false en caso contrario.</returns>
        Task<bool> DeleteUserAsync(int idCard);
    }
}

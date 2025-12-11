using SgiAzure.Application.Dtos;
using SgiAzure.Application.Interfaces.Services;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Interfaces.Repositories;

namespace SgiAzure.Application.Services
{
    /// <summary>
    /// Implementación del servicio para gestionar usuarios. 
    /// Este servicio proporciona métodos para crear, obtener, actualizar y eliminar usuarios a través de sus DTOs (Data Transfer Objects).
    /// </summary>
    public class UserService : IUserService<UserDto>
    {
        private readonly IUserRepository<User> _userRepository;

        /// <summary>
        /// Constructor de la clase UserService.
        /// Inicializa el repositorio de usuarios que será utilizado por los métodos del servicio.
        /// </summary>
        /// <param name="userRepository">Repositorio de usuarios para acceder y manipular los datos de los usuarios en la base de datos.</param>
        public UserService(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Obtiene un usuario por su nombre de usuario.
        /// </summary>
        /// <param name="username">Nombre de usuario del usuario a buscar.</param>
        /// <returns>DTO del usuario encontrado, o null si no se encuentra el usuario.</returns>
        public async Task<UserDto?> GetUserByUsername(string username)
        {
            var user = await _userRepository.GetUserByUsername(username);
            if (user == null) return null;
            return UserDto.FromDomainEntity(user);
        }

        /// <summary>
        /// Obtiene todos los usuarios registrados.
        /// </summary>
        /// <returns>Lista de DTOs de todos los usuarios.</returns>
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(user => UserDto.FromDomainEntity(user));
        }

        /// <summary>
        /// Obtiene un usuario por su cédula de identidad.
        /// </summary>
        /// <param name="idCard">Cédula del usuario a buscar.</param>
        /// <returns>DTO del usuario encontrado, o null si no se encuentra el usuario.</returns>
        public async Task<UserDto?> GetUserByIdAsync(int idCard)
        {
            var user = await _userRepository.GetByIdAsync(idCard);
            return user != null ? UserDto.FromDomainEntity(user) : null;
        }

        /// <summary>
        /// Crea un nuevo usuario en el sistema.
        /// </summary>
        /// <param name="userDto">DTO que contiene los datos del nuevo usuario a crear.</param>
        /// <returns>DTO del usuario creado.</returns>
        public async Task<UserDto?> CreateUserAsync(UserDto userDto)
        {
            var user = userDto.ToDomainEntity();
            var createdUser = await _userRepository.AddAsync(user);
            return UserDto.FromDomainEntity(createdUser);
        }

        /// <summary>
        /// Actualiza los datos de un usuario existente en el sistema.
        /// </summary>
        /// <param name="idCard">Cédula del usuario a actualizar.</param>
        /// <param name="userDto">DTO con los nuevos datos del usuario.</param>
        /// <returns>DTO del usuario actualizado, o null si no se encuentra el usuario para actualizar.</returns>
        public async Task<UserDto?> UpdateUserAsync(int idCard, UserDto userDto)
        {
            var user = await _userRepository.GetByIdAsync(idCard);
            if (user == null) return null;

            user = userDto.ToDomainEntity();
            user.IdCard = idCard;
            var updatedUser = await _userRepository.UpdateAsync(idCard,user);
            return UserDto.FromDomainEntity(updatedUser);
        }

        /// <summary>
        /// Elimina un usuario del sistema por su cédula de identidad.
        /// </summary>
        /// <param name="idCard">Cédula del usuario a eliminar.</param>
        /// <returns>True si la eliminación fue exitosa, false en caso contrario.</returns>
        public async Task<bool> DeleteUserAsync(int idCard)
        {
            var user = await _userRepository.GetByIdAsync(idCard);
            if (user == null) return false;

            await _userRepository.DeleteAsync(idCard);
            return true;
        }
    }
}

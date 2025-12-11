using SgiAzure.Domain.Entities;

namespace SgiAzure.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Repositorio para gestionar las operaciones relacionadas con los usuarios.
    /// </summary>
    public interface IUserRepository<T> where T : IUser
    {
        /// <summary>
        /// Obtiene un usuario por su identificador único.
        /// </summary>
        /// <param name="userId">El identificador del usuario.</param>
        /// <returns>El usuario correspondiente.</returns>
        Task<T> GetByIdAsync(long userId, CancellationToken ct = default);

        /// <summary>
        /// Obtiene un usuario por su nombre de usuario.
        /// </summary>
        /// <param name="userId">El nombre de usuario.</param>
        /// <returns>El usuario correspondiente.</returns>
        Task<T?> GetUserByUsername(string username, CancellationToken ct = default);


        /// <summary>
        /// Obtiene una lista de todos los usuarios.
        /// </summary>
        /// <returns>Una lista de usuarios.</returns>
        Task<IEnumerable<T>> GetAllAsync(CancellationToken ct = default);

        /// <summary>
        /// Agrega un nuevo usuario al repositorio.
        /// </summary>
        /// <param name="user">El usuario a agregar.</param>
        /// <returns>El usuario agregado.</returns>
        Task<T> AddAsync(T user, CancellationToken ct = default);

        /// <summary>
        /// Actualiza los detalles de un usuario existente.
        /// </summary>
        /// <param name="user">El usuario actualizado.</param>
        /// <returns>El usuario actualizado.</returns>
        Task<T> UpdateAsync(int userId, T user, CancellationToken ct = default);

        /// <summary>
        /// Elimina un usuario del repositorio.
        /// </summary>
        /// <param name="userId">El identificador del usuario a eliminar.</param>
        /// <returns>Una tarea que representa la operación.</returns>
        Task DeleteAsync(long userId, CancellationToken ct = default);

        /// <summary>
        /// Verifica si un usuario existe por su identificador.
        /// </summary>
        /// <param name="userId">El identificador del usuario.</param>
        /// <returns>True si el usuario existe, false en caso contrario.</returns>
        Task<bool> ExistsAsync(long userId, CancellationToken ct = default);

        /// <summary>
        /// Busca usuarios por un criterio específico.
        /// </summary>
        /// <param name="searchTerm">El término de búsqueda.</param>
        /// <returns>Una lista de usuarios que coinciden con el criterio.</returns>
        Task<IEnumerable<T>> SearchAsync(string searchTerm, CancellationToken ct = default);
    }
}

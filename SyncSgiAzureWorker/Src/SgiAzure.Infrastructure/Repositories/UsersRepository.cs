using Microsoft.EntityFrameworkCore;
using SgiAzure.Domain.Enumerators;
using SgiAzure.Domain.Exceptions;
using SgiAzure.Domain.Interfaces.Repositories;
using SgiAzure.Infrastructure.Databases.Sgi;
using User = SgiAzure.Domain.Entities.User;

namespace SgiAzure.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio encargado de la gestión de usuarios en la base de datos.
    /// Implementa la interfaz <see cref="IUserRepository{User}"/> para interactuar con los datos de usuario.
    /// </summary>
    public class UsersRepository : IUserRepository<User>
    {
        /// <summary>
        /// Contexto de la base de datos para la conexión con Oracle.
        /// </summary>
        private readonly SgiDbContext _context;

        /// <summary>
        /// Constructor para inyectar el contexto de la base de datos.
        /// </summary>
        /// <param name="context">El contexto de la base de datos utilizado para acceder a los datos de usuarios.</param>
        public UsersRepository(SgiDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "El contexto de la base de datos no puede ser nulo.");
        }

        /// <summary>
        /// Agrega un nuevo usuario a la base de datos.
        /// </summary>
        /// <param name="user">El usuario a agregar.</param>
        /// <returns>El usuario agregado.</returns>
        public async Task<User> AddAsync(User user, CancellationToken ct = default)
        {
            await _context.Users.AddAsync(user, ct);
            await _context.SaveChangesAsync(ct);
            return user;
        }

        /// <summary>
        /// Elimina un usuario de la base de datos por su identificador.
        /// </summary>
        /// <param name="userId">El ID del usuario a eliminar.</param>
        /// <returns>Una tarea asincrónica que representa la operación de eliminación.</returns>
        public async Task DeleteAsync(long userId, CancellationToken ct = default)
        {
            var user = await _context.Users.FindAsync(userId, ct);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync(ct);
            }
        }

        /// <summary>
        /// Verifica si un usuario existe en la base de datos por su identificador.
        /// </summary>
        /// <param name="userId">El ID del usuario a verificar.</param>
        /// <returns>True si el usuario existe, de lo contrario False.</returns>
        public async Task<bool> ExistsAsync(long userId, CancellationToken ct = default)
        {
            return await _context.Users.AnyAsync(u => u.IdCard == userId, ct);
        }

        /// <summary>
        /// Obtiene todos los usuarios almacenados en la base de datos.
        /// </summary>
        /// <returns>Una lista de todos los usuarios.</returns>
        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken ct = default)
        {
            return await _context.Users.ToListAsync(ct); 
        }

        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        /// <param name="userId">El ID del usuario a buscar.</param>
        /// <returns>El usuario correspondiente, o null si no se encuentra.</returns>
        public async Task<User> GetByIdAsync(long userId, CancellationToken ct = default)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.IdCard == userId, ct) ?? 
                throw new SgiAzureException($"No existe usuario con el identificador {userId}", ErrorCode.EntityNotFound);
        }

        /// <summary>
        /// Obtiene un usuario por su nombre de usuario
        /// </summary>
        /// <param name="userId">El nombre de usuario a buscar.</param>
        /// <returns>El usuario correspondiente, o null si no se encuentra.</returns>
        public async Task<User?> GetUserByUsername(string username, CancellationToken ct)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserSystem == username, ct);
        }

        /// <summary>
        /// Realiza una búsqueda de usuarios que coincidan con un término de búsqueda en sus campos de nombre, email o posición.
        /// </summary>
        /// <param name="searchTerm">El término de búsqueda utilizado para filtrar los usuarios.</param>
        /// <returns>Una lista de usuarios que coinciden con el término de búsqueda.</returns>
        public async Task<IEnumerable<User>> SearchAsync(string searchTerm, CancellationToken ct)
        {
            return await _context.Users
                .Where(u => u.FirstName.Contains(searchTerm) || u!.Email!.Contains(searchTerm) || u!.Position!.Contains(searchTerm))
                .ToListAsync(ct);
        }

        /// <summary>
        /// Actualiza la información de un usuario existente en la base de datos.
        /// </summary>
        /// <param name="user">El usuario con la información actualizada.</param>
        /// <returns>El usuario actualizado, o null si no se encontró el usuario.</returns>
        public async Task<User> UpdateAsync(int userId,User user, CancellationToken ct = default)
        {
            var existingUser = await _context.Users.FindAsync(userId, ct);
            if (existingUser == null) throw new SgiAzureException($"No existe usuario con id {userId}", ErrorCode.EntityNotFound);

            existingUser.IdCard = user.IdCard;
            existingUser.Email = user.Email;
            existingUser.Position = user.Position;

            await _context.SaveChangesAsync(ct);
            return existingUser;
        }
    }
}

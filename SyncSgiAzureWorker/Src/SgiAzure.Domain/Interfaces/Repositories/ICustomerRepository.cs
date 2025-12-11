using SgiAzure.Domain.Interfaces.Entities;

namespace SgiAzure.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface encargada de abstraer las operaciones de acceso a datos
    /// relacionadas con la entidad <see cref="ICustomer"/>.
    /// </summary>
    /// <typeparam name="T">Clase que implementa <see cref="ICustomer"/>.</typeparam>
    public interface ICustomerRepository<T> where T : ICustomer
    {
        /// <summary>
        /// Obtiene todos los clientes registrados.
        /// </summary>
        /// <returns>Una colección de clientes.</returns>
        Task<IEnumerable<T>> GetAll(CancellationToken ct = default);

        /// <summary>
        /// Obtiene un cliente por su identificador único.
        /// </summary>
        /// <param name="id">Identificador del cliente.</param>
        /// <returns>Instancia del cliente correspondiente al ID.</returns>
        Task<T> GetById(int id, CancellationToken ct = default);

        /// <summary>
        /// Obtiene un cliente por su nombre.
        /// </summary>
        /// <param name="name">Nombre del cliente.</param>
        /// <returns>Instancia del cliente que coincide con el nombre.</returns>
        Task<T> GetByName(string name, CancellationToken ct = default);

        /// <summary>
        /// Obtiene un cliente por su correo electrónico.
        /// </summary>
        /// <param name="email">Correo electrónico del cliente.</param>
        /// <returns>Instancia del cliente que coincide con el correo.</returns>
        Task<T> GetByEmail(string email, CancellationToken ct = default);

        /// <summary>
        /// Crea un nuevo cliente en el repositorio.
        /// </summary>
        /// <param name="entity">Entidad del cliente a crear.</param>
        /// <returns>Cliente creado.</returns>
        Task<T> CreateCustomer(T entity, CancellationToken ct = default);

        /// <summary>
        /// Actualiza la información de un cliente existente.
        /// </summary>
        /// <param name="entity">Entidad del cliente con los datos actualizados.</param>
        /// <returns>Cliente actualizado.</returns>
        Task<T> UpdateCustomer(int id, T entity, CancellationToken ct = default);

        /// <summary>
        /// Elimina un cliente del repositorio.
        /// </summary>
        /// <param name="entity">Entidad del cliente a eliminar.</param>
        /// <returns>Cliente eliminado.</returns>
        Task DeleteCustomer(int id, CancellationToken ct = default);
    }
}

using SgiAzure.Domain.Interfaces.Entities;

namespace SgiAzure.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interfaz que abstrae las operaciones del repositorio para gestionar los requerimientos.
    /// </summary>
    /// <typeparam name="T">El tipo de la entidad de requerimiento.</typeparam>
    public interface IRequirementRepository<T> where T : IRequirement
    {
        /// <summary>
        /// Recupera todos los requerimientos de forma asincrónica desde la fuente de datos.
        /// </summary>
        /// <returns>
        /// Una tarea que representa la operación asincrónica. El resultado de la tarea contiene un 
        /// <see cref="IEnumerable{T}"/> de requerimientos, donde <typeparamref name="T"/> es el tipo 
        /// de la entidad de requerimiento.
        /// </returns>
        /// <remarks>
        /// Este método recupera todos los registros de la fuente de datos subyacente sin aplicar ningún filtro. 
        /// Úselo con precaución si la fuente de datos contiene una gran cantidad de registros, 
        /// ya que podría afectar el rendimiento o el uso de memoria.
        /// </remarks>
        Task<IEnumerable<T>> GetAllAsync(CancellationToken ct = default);

        /// <summary>
        /// Obtiene un requerimiento por su identificador único de forma asincrónica.
        /// </summary>
        /// <param name="id">El identificador único del requerimiento.</param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica. El resultado contiene el objeto <see cref="IRequirement"/> 
        /// asociado al identificador, o null si no se encuentra.
        /// </returns>
        Task<T?> GetByIdAsync(int id, CancellationToken ct = default);


        /// <summary>
        /// Crea un nuevo requerimiento de forma asincrónica.
        /// </summary>
        /// <param name="requirement">El objeto <see cref="IRequirement"/> que se va a crear.</param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica. El resultado contiene el requerimiento creado.
        /// </returns>
        Task<T> CreateAsync(T requirement, CancellationToken ct = default);


        /// <summary>
        /// Actualiza un requerimiento existente de forma asincrónica.
        /// </summary>
        /// <param name="requirement">El objeto <see cref="IRequirement"/> que se va a actualizar.</param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica.
        /// </returns>
        Task UpdateAsync(int requirementId, T requirement, CancellationToken ct = default);

        /// <summary>
        /// Elimina un requerimiento por su identificador único de forma asincrónica.
        /// </summary>
        /// <param name="id">El identificador único del requerimiento a eliminar.</param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica. El resultado es verdadero si la eliminación 
        /// fue exitosa, o falso si el requerimiento no se encontró o no se pudo eliminar.
        /// </returns>
        Task DeleteAsync(int id, CancellationToken ct = default);
    }
}

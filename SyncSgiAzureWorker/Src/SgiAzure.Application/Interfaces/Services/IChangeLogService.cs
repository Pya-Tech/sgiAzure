using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Enum;

namespace SgiAzure.Application.Interfaces.Services
{
    /// <summary>
    /// Interfaz para el servicio de gestión de registros de cambios (Changelog).
    /// Define las operaciones de negocio relacionadas con los registros de cambios.
    /// </summary>
    public interface IChangeLogService
    {

        /// <summary>
        /// Registra un conjunto de cambios de manera asíncrona
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="changeValuesObject"></param>
        /// <param name="requirementWorkItemId"></param>
        /// <param name="origin"></param>
        /// <param name="changeType"></param>
        /// <returns></returns>
        Task RegisterChangeLog<T>(T changeValuesObject, int requirementWorkItemId, string origin, ChangeType changeType = ChangeType.Created, CancellationToken ct = default);

        /// <summary>
        /// Elimina un registro de cambio por su identificador de manera asíncrona.
        /// </summary>
        /// <param name="changeLogId">El identificador del registro de cambio a eliminar.</param>
        /// <returns>Una tarea asincrónica que representa la operación.</returns>
        Task DeleteAsync(int changeLogId, CancellationToken ct = default);

    }
}

using Microsoft.EntityFrameworkCore;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Enumerators;
using SgiAzure.Domain.Exceptions;
using SgiAzure.Domain.Interfaces.Repositories;
using SgiAzure.Infrastructure.Databases.SgiAzure;

namespace SgiAzure.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio para gestionar los registros de cambios (Changelog) de manera persistente.
    /// Implementa las operaciones definidas en la interfaz <see cref="IChangelogRepository{T}"/>.
    /// </summary>
    public class ChangelogRepository : IChangelogRepository<Changelog>
    {
        private readonly SgiAzureDbContext _context;

        public ChangelogRepository(SgiAzureDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Agrega un nuevo registro de cambio a la base de datos de manera asíncrona.
        /// </summary>
        /// <param name="changelog">El objeto <see cref="Changelog"/> a agregar.</param>
        /// <returns>Una tarea asincrónica que representa la operación de agregar.</returns>
        public async Task AddAsync(Changelog changelog, CancellationToken ct = default)
        {
            if (changelog == null)
                throw new ArgumentNullException(nameof(changelog));

            await _context.Changelogs.AddAsync(changelog, ct);
            await _context.SaveChangesAsync(ct);
        }

        /// <summary>
        /// Elimina un registro de cambio por su identificador de manera asíncrona.
        /// </summary>
        /// <param name="changeLogId">El identificador del registro de cambio a eliminar.</param>
        /// <returns>Una tarea asincrónica que representa la operación de eliminación.</returns>
        public async Task DeleteAsync(int changeLogId, CancellationToken ct = default)
        {
            var changelog = await _context.Changelogs.FindAsync(changeLogId);
            if (changelog == null)
                throw new SgiAzureException("Changelog no encontrado.", ErrorCode.EntityNotFound);

             _context.Changelogs.Remove(changelog);
            await _context.SaveChangesAsync(ct);
        }

        /// <summary>
        /// Obtiene un registro de cambio por su <paramref name="requirementId"/> de manera asíncrona.
        /// </summary>
        /// <param name="requirementId">El identificador del requerimiento.</param>
        /// <returns>Una tarea asincrónica que devuelve el registro de cambio o null si no se encuentra.</returns>
        public async Task<Changelog?> GetChangelogByRequirementId(int requirementId, CancellationToken ct = default)
        {
            return await _context.Changelogs
                .Where(c => c.RequirementWorkItemId == requirementId)
                .FirstOrDefaultAsync(ct);
        }

        /// <summary>
        /// Obtiene un registro de cambio por su <paramref name="workItemId"/> de manera asíncrona.
        /// </summary>
        /// <param name="workItemId">El identificador del work item.</param>
        /// <returns>Una tarea asincrónica que devuelve el registro de cambio o null si no se encuentra.</returns>
        public async Task<Changelog?> GetChangelogByWorkItemId(int workItemId, CancellationToken ct = default)
        {
            return await _context.Changelogs
                .Where(c => c.RequirementWorkItemId == workItemId)
                .FirstOrDefaultAsync(ct);
        }

        /// <summary>
        /// Actualiza un registro de cambio existente de manera asíncrona.
        /// </summary>
        /// <param name="changelog">El objeto <see cref="Changelog"/> con la nueva información del registro de cambio.</param>
        /// <returns>Una tarea asincrónica que representa la operación de actualización.</returns>
        public async Task UpdateAsync(int changeLogId, Changelog changelog, CancellationToken ct = default)
        {
            var changeLogFind = await _context.Changelogs.FindAsync(changeLogId);
            if (changeLogFind == null)
            {
                throw new SgiAzureException($"No existe changelog con el id {changeLogId}", ErrorCode.EntityNotFound);
            }
            changeLogFind.ChangeDescription = changelog.ChangeDescription;
            changeLogFind.ChangeType = changelog.ChangeType;
            changeLogFind.UpdatedAt = DateTime.UtcNow;
            changeLogFind.Origin = changelog.Origin;
            changeLogFind.RequirementWorkItemId = changelog.RequirementWorkItemId;
            await _context.SaveChangesAsync(ct);
        }
    }
}

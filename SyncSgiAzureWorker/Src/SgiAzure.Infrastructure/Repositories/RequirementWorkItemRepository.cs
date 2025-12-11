using Microsoft.EntityFrameworkCore;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Enumerators;
using SgiAzure.Domain.Exceptions;
using SgiAzure.Domain.Interfaces.Repositories;
using SgiAzure.Infrastructure.Databases.SgiAzure;

namespace SgiAzure.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio que gestiona las operaciones CRUD para la entidad RequirementWorkItem.
    /// </summary>
    public class RequirementWorkItemRepository : IRequirementWorkItemRepository<RequirementWorkItem>
    {
        private readonly SgiAzureDbContext _context;

        /// <summary>
        /// Inicializa una nueva instancia de RequirementWorkItemRepository.
        /// </summary>
        /// <param name="context">Contexto de base de datos de tipo SgiAzureDbContext.</param>
        public RequirementWorkItemRepository(SgiAzureDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Agrega de forma asíncrona un nuevo RequirementWorkItem a la base de datos.
        /// </summary>
        /// <param name="requirementWorkItem">La entidad RequirementWorkItem a agregar.</param>
        /// <returns>Tarea que representa la operación asincrónica.</returns>
        public async Task<RequirementWorkItem> AddAsync(RequirementWorkItem requirementWorkItem, CancellationToken ct = default)
        {
            var data = await _context.RequirementWorkItems.AddAsync(requirementWorkItem, ct);
            await _context.SaveChangesAsync(ct);
            return data.Entity;
        }

        /// <summary>
        /// Obtiene de forma asíncrona un RequirementWorkItem a partir del RequirementId.
        /// </summary>
        /// <param name="requirementId">ID del requerimiento asociado.</param>
        /// <returns>La entidad RequirementWorkItem correspondiente o null si no se encuentra.</returns>
        public async Task<RequirementWorkItem?> GetByRequirementIdAsync(int requirementId, CancellationToken ct = default)
        {
            return await _context.RequirementWorkItems
                .FirstOrDefaultAsync(rw => rw.RequirementId == requirementId, ct);
        }

        /// <summary>
        /// Obtiene de forma asíncrona todos los RequirementWorkItems asociados a un WorkItemId.
        /// </summary>
        /// <param name="workItemId">ID del Work Item asociado.</param>
        /// <returns>Colección de RequirementWorkItems asociados al ID especificado.</returns>
        public async Task<RequirementWorkItem?> GetByWorkItemIdAsync(int workItemId, CancellationToken ct = default)
        {
            return await _context.RequirementWorkItems
                .FirstOrDefaultAsync(rw => rw.WorkItemId == workItemId, ct);
        }

        /// <summary>
        /// Actualiza de forma asíncrona un RequirementWorkItem existente en la base de datos.
        /// </summary>
        /// <param name="requirementWorkItem">Entidad RequirementWorkItem a actualizar.</param>
        /// <returns>Tarea que representa la operación asincrónica.</returns>
        public async Task UpdateAsync(int requirementId, RequirementWorkItem requirementWorkItem, CancellationToken ct = default)
        {
            _ = await _context.RequirementWorkItems.FirstOrDefaultAsync(rw => rw.Id == requirementId, ct) ?? 
                throw new SgiAzureException($"No se encontró Requerimiento y WorkItem con Id ${requirementId}", ErrorCode.EntityNotFound); 
            _context.RequirementWorkItems.Update(requirementWorkItem);
            await _context.SaveChangesAsync(ct);
        }

        /// <summary>
        /// Elimina de forma asíncrona un RequirementWorkItem de la base de datos usando el RequirementId y WorkItemId.
        /// </summary>
        /// <param name="requirementId">ID del requerimiento a eliminar.</param>
        /// <param name="workItemId">ID del Work Item asociado al requerimiento.</param>
        /// <returns>Tarea que representa la operación asincrónica.</returns>
        public async Task DeleteAsync(int requirementId, int workItemId, CancellationToken ct = default)
        {
            var requirementWorkItem = await _context.RequirementWorkItems
                .FindAsync(requirementId, workItemId);

            if (requirementWorkItem != null)
            {
                _context.RequirementWorkItems.Remove(requirementWorkItem);
                await _context.SaveChangesAsync(ct);
            }
        }
    }
}

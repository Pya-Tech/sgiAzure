using Microsoft.EntityFrameworkCore;
using SgiAzure.Domain.Entities;
using SgiAzure.Domain.Enum;
using SgiAzure.Domain.Enumerators;
using SgiAzure.Domain.Exceptions;
using SgiAzure.Domain.Interfaces.Repositories;
using SgiAzure.Infrastructure.Databases.SgiAzure;

namespace SgiAzure.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio para gestionar los registros de procesamiento de mensajes (MessageProcessing) de manera persistente.
    /// Implementa las operaciones definidas en la interfaz <see cref="IMessageProcessingRepository{T}"/>.
    /// </summary>
    public class MessageProcessingRepository : IMessageProcessingRepository<MessageProcessing>
    {
        private readonly SgiAzureDbContext _context;

        public MessageProcessingRepository(SgiAzureDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Agrega un nuevo registro de procesamiento de mensaje a la base de datos de manera asíncrona.
        /// </summary>
        /// <param name="messageProcessing">El objeto <see cref="MessageProcessing"/> a agregar.</param>
        /// <returns>Una tarea asincrónica que representa la operación de agregar.</returns>
        public async Task AddAsync(MessageProcessing messageProcessing, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(messageProcessing);

            await _context.MessageProcessings.AddAsync(messageProcessing, ct);
            await _context.SaveChangesAsync(ct);
        }

        /// <summary>
        /// Elimina un registro de procesamiento de mensaje por su identificador de mensaje de manera asíncrona.
        /// </summary>
        /// <param name="messageId">El identificador del mensaje a eliminar.</param>
        /// <returns>Una tarea asincrónica que representa la operación de eliminación.</returns>
        public async Task DeleteAsync(string messageId, CancellationToken ct = default)
        {
            var messageProcessing = await _context.MessageProcessings
                .FirstOrDefaultAsync(mp => mp.MessageId == messageId, ct);

            if (messageProcessing == null)
                throw new SgiAzureException("MessageProcessing no encontrado.", ErrorCode.EntityNotFound);

            _context.MessageProcessings.Remove(messageProcessing);
            await _context.SaveChangesAsync(ct);
        }

        /// <summary>
        /// Obtiene un registro de procesamiento de mensaje por su identificador de mensaje de manera asíncrona.
        /// </summary>
        /// <param name="messageId">El identificador del mensaje.</param>
        /// <returns>Una tarea asincrónica que devuelve el registro de procesamiento de mensaje o null si no se encuentra.</returns>
        public async Task<MessageProcessing?> GetByMessageIdAsync(string messageId, CancellationToken ct = default)
        {
            return await _context.MessageProcessings
                .Where(mp => mp.MessageId == messageId)
                .FirstOrDefaultAsync(ct);
        }

        /// <summary>
        /// Obtiene todos los registros de procesamiento de mensajes con un estado específico de manera asíncrona.
        /// </summary>
        /// <param name="status">El estado del procesamiento de mensaje a buscar.</param>
        /// <returns>Una tarea asincrónica que devuelve una lista de registros de procesamiento de mensajes.</returns>
        public async Task<IEnumerable<MessageProcessing>> GetByStatusAsync(MessageProcessingStatus status, CancellationToken ct = default)
        {
            return await _context.MessageProcessings
                .Where(mp => mp.Status == status)
                .ToListAsync(ct);
        }

        /// <summary>
        /// Actualiza un registro de procesamiento de mensaje existente de manera asíncrona.
        /// </summary>
        /// <param name="messageProcessing">El objeto <see cref="MessageProcessing"/> con la nueva información del registro de procesamiento de mensaje.</param>
        /// <returns>Una tarea asincrónica que representa la operación de actualización.</returns>
        public async Task UpdateAsync(MessageProcessing messageProcessing, CancellationToken ct = default)
        {
            if (messageProcessing == null)
                throw new ArgumentNullException(nameof(messageProcessing));

            _context.MessageProcessings.Update(messageProcessing);
            await _context.SaveChangesAsync(ct);
        }
    }
}

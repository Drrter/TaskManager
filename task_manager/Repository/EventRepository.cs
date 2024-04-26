using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// Реализация репозитория IEventRepository
    /// </summary>
    public class EventRepository : IEventRepository
    {
        /// <summary>
        /// Передает TaskContext в конструктор
        /// </summary>
        private readonly TaskContext _context;

        public EventRepository(TaskContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Получает список всех событий
        /// </summary>
        /// <returns>Список событий</returns>
        public async Task<List<Events>> GetAllEventsAsync(CancellationToken cancellationToken)
        {
            return await _context.Events.ToListAsync(cancellationToken);
        }
        /// <summary>
        /// Получает событие по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор события</param>
        /// <returns> Получает событие с указанным идентификатором</returns>
        public async Task<Events> GetEventByIdAsync(int id,CancellationToken cancellationToken)
        {
            return await _context.Events.FindAsync(id,cancellationToken);
        }
        /// <summary>
        /// Добавление события
        /// </summary>
        /// <param name="newEvent">Новое событие</param>
        /// <returns>Выполнено</returns>
        public async Task AddEventAsync(Events newEvent,CancellationToken cancellationToken)
        {
            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync(cancellationToken);
        }
        /// <summary>
        /// Обновление события
        /// </summary>
        /// <param name="id">Идентификатор события</param>
        /// <param name="updatedEvent">Обновленное событие</param>
        /// <returns>Выполнено</returns>
        public async Task UpdateEventAsync(int id, Events updatedEvent,CancellationToken cancellationToken)
        {
            _context.Entry(updatedEvent).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }
        /// <summary>
        /// Удаление события
        /// </summary>
        /// <param name="id">Идентификатор события</param>
        /// <returns>Выполнено</returns>
        public async Task DeleteEventAsync(int id,CancellationToken cancellationToken)
        {
            var eventToDelete = await _context.Events.FindAsync(id);
            if (eventToDelete != null)
            {
                _context.Events.Remove(eventToDelete);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}

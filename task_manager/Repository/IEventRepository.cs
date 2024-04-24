using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// интерфейс с методами управления событиями
    /// </summary>
    public interface IEventRepository
    {
        /// <summary>
        /// получает список всех событий
        /// </summary>
        /// <returns>список событий</returns>
        Task<List<Events>> GetAllEventsAsync();
        /// <summary>
        /// получает событие по идентификатору
        /// </summary>
        /// <param name="id">идентификатор события</param>
        /// <returns>
        /// получает событие с указанным идентификатором</returns>
        Task<Events> GetEventByIdAsync(int id);
        /// <summary>
        /// добавление события
        /// </summary>
        /// <param name="newEvent">новое событие</param>
        /// <returns>выполнено</returns>
        Task AddEventAsync(Events newEvent);
        /// <summary>
        /// обновление события
        /// </summary>
        /// <param name="id">идентификатор события</param>
        /// <param name="updatedEvent">обновленное событие</param>
        /// <returns></returns>
        Task UpdateEventAsync(int id, Events updatedEvent);
        /// <summary>
        /// удаление события
        /// </summary>
        /// <param name="id">идентификатор события</param>
        /// <returns>выполнено</returns>
        Task DeleteEventAsync(int id);
    }
    /// <summary>
    /// реализация репозитория IEventRepository
    /// </summary>
    public class EventRepository : IEventRepository
    {
        /// <summary>
        /// передает TaskContext в конструктор
        /// </summary>
        private readonly TaskContext _context;

        public EventRepository(TaskContext context)
        {
            _context = context;
        }
        /// <summary>
        /// получает список всех событий
        /// </summary>
        /// <returns>список событий</returns>
        public async Task<List<Events>> GetAllEventsAsync()
        {
            return await _context.Events.ToListAsync();
        }
        /// <summary>
        /// получает событие по идентификатору
        /// </summary>
        /// <param name="id">идентификатор события</param>
        /// <returns>
        /// получает событие с указанным идентификатором</returns>
        public async Task<Events> GetEventByIdAsync(int id)
        {
            return await _context.Events.FindAsync(id);
        }
        /// <summary>
        /// добавление события
        /// </summary>
        /// <param name="newEvent">новое событие</param>
        /// <returns>выполнено</returns>
        public async Task AddEventAsync(Events newEvent)
        {
            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// обновление события
        /// </summary>
        /// <param name="id">идентификатор события</param>
        /// <param name="updatedEvent">обновленное событие</param>
        /// <returns></returns>
        public async Task UpdateEventAsync(int id,Events updatedEvent)
        {
            _context.Entry(updatedEvent).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// удаление события
        /// </summary>
        /// <param name="id">идентификатор события</param>
        /// <returns>выполнено</returns>
        public async Task DeleteEventAsync(int id)
        {
            var eventToDelete = await _context.Events.FindAsync(id);
            if (eventToDelete != null)
            {
                _context.Events.Remove(eventToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
    /// <summary>
    /// сервис для управления событиями
    /// </summary>
    public class EventService
    {
        /// <summary>
        /// зависимость типа IEventRepository
        /// </summary>
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        /// <summary>
        /// получает список всех событий
        /// </summary>
        /// <returns>список событий</returns>
        public async Task<List<Events>> GetAllEventsAsync(CancellationToken cancellationToken)
        {
            return await _eventRepository.GetAllEventsAsync();
        }
        /// <summary>
        /// получает событие по идентификатору
        /// </summary>
        /// <param name="id">идентификатор события</param>
        /// <returns>
        /// получает событие с указанным идентификатором</returns>
        public async Task<Events> GetEventByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _eventRepository.GetEventByIdAsync(id);
        }
        /// <summary>
        /// добавление события
        /// </summary>
        /// <param name="newEvent">новое событие</param>
        /// <returns>выполнено</returns>
        public async Task AddEventAsync(Events newEvent, CancellationToken cancellationToken)
        {
            await _eventRepository.AddEventAsync(newEvent);
        }
        /// <summary>
        /// обновление события
        /// </summary>
        /// <param name="id">идентификатор события</param>
        /// <param name="updatedEvent">обновленное событие</param>
        /// <returns></returns>
        public async Task UpdateEventAsync(Events updatedEvent, CancellationToken cancellationToken)
        {
             await _eventRepository.UpdateEventAsync(updatedEvent.IdEvent, updatedEvent);
        }
        /// <summary>
        /// удаление события
        /// </summary>
        /// <param name="id">идентификатор события</param>
        /// <returns>выполнено</returns>
        public async Task DeleteEventAsync(int id, CancellationToken cancellationToken)
        {
            await _eventRepository.DeleteEventAsync(id);
        }
    }


}

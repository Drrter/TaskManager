using TaskManager.DB;
using TaskManager.Repository;

namespace TaskManager.Services
{
    /// <summary>
    /// Сервис для управления событиями
    /// </summary>
    public class EventService
    {
        /// <summary>
        /// Зависимость типа IEventRepository
        /// </summary>
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        /// <summary>
        /// Получает список всех событий
        /// </summary>
        /// <returns>Список событий</returns>
        public async Task<List<Events>> GetAllEventsAsync(CancellationToken cancellationToken)
        {
            return await _eventRepository.GetAllEventsAsync(cancellationToken);
        }
        /// <summary>
        /// Получает событие по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор события</param>
        /// <returns>Получает событие с указанным идентификатором</returns>
        public async Task<Events> GetEventByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _eventRepository.GetEventByIdAsync(id, cancellationToken);
        }
        /// <summary>
        /// Добавление события
        /// </summary>
        /// <param name="newEvent">Новое событие</param>
        /// <returns>Выполнено</returns>
        public async Task AddEventAsync(Events newEvent, CancellationToken cancellationToken)
        {
            await _eventRepository.AddEventAsync(newEvent, cancellationToken);
        }
        /// <summary>
        /// Обновление события
        /// </summary>
        /// <param name="id">Идентификатор события</param>
        /// <param name="updatedEvent">Обновленное событие</param>
        /// <returns>Выполнено</returns>
        public async Task UpdateEventAsync(Events updatedEvent, CancellationToken cancellationToken)
        {
            await _eventRepository.UpdateEventAsync(updatedEvent.Id, updatedEvent, cancellationToken);
        }
        /// <summary>
        /// Удаление события
        /// </summary>
        /// <param name="id">Идентификатор события</param>
        /// <returns>Выполнено</returns>
        public async Task DeleteEventAsync(int id, CancellationToken cancellationToken)
        {
            await _eventRepository.DeleteEventAsync(id, cancellationToken);
        }
    }
}

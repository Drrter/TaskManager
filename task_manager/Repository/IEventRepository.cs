using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// Интерфейс с методами управления событиями
    /// </summary>
    public interface IEventRepository
    {
        /// <summary>
        /// Получает список всех событий
        /// </summary>
        /// <returns>Список событий</returns>
        Task<List<Events>> GetAllEventsAsync(CancellationToken cancellationToken);
        /// <summary>
        /// Получает событие по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор события</param>
        /// <returns>
        /// Получает событие с указанным идентификатором</returns>
        Task<Events> GetEventByIdAsync(int id, CancellationToken cancellationToken);
        /// <summary>
        /// Добавление события
        /// </summary>
        /// <param name="newEvent">Новое событие</param>
        /// <returns>Выполнено</returns>
        Task AddEventAsync(Events newEvent, CancellationToken cancellationToken);
        /// <summary>
        /// Обновление события
        /// </summary>
        /// <param name="id">Идентификатор события</param>
        /// <param name="updatedEvent">Обновленное событие</param>
        /// <returns>Выполнено</returns>
        Task UpdateEventAsync(int id, Events updatedEvent, CancellationToken cancellationToken);
        /// <summary>
        /// Удаление события
        /// </summary>
        /// <param name="id">Идентификатор события</param>
        /// <returns>Выполнено</returns>
        Task DeleteEventAsync(int id, CancellationToken cancellationToken);
    }
       
}

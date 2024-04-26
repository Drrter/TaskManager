using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// Интерфейс с методами управления задачами
    /// </summary>
    public interface ITasksRepository
    {
        /// <summary>
        /// Получает список всех задач
        /// </summary>
        /// <returns>Список задач</returns>
        Task<List<Tasks>> GetAllTasksAsync(CancellationToken cancellationToken);
        /// <summary>
        /// Получает задачу по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        /// <returns>Задача с указанным идентификатором</returns>
        Task<Tasks> GetTasksByIdAsync(int id, CancellationToken cancellationToken);
        /// <summary>
        /// Добавление новой задачи
        /// </summary>
        /// <param name="newTask">Новая задача</param>
        /// <returns>Выполнено</returns>
        Task AddTaskAsync(Tasks newTask, CancellationToken cancellationToken);
        /// <summary>
        /// Обновление существующей задачи
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        /// <param name="updatedTask">Обновленная задача</param>
        /// <returns>Выполнено</returns>
        Task UpdateTaskAsync(int id, Tasks updatedTask, CancellationToken cancellationToken);
        /// <summary>
        /// Удаление задачи
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        /// <returns>Выполнено</returns>
        Task DeleteTaskAsync(int id,CancellationToken cancellationToken);
    }
    
}

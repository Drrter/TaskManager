using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// Интерфейс с методами управления выполненными задачами
    /// </summary>
    public interface ICompletedTasksRepository
    {
        /// <summary>
        /// Получает список всех выполненных задач
        /// </summary>
        /// <returns>Список выполненных задач</returns>
        Task<List<CompletedTasks>> GetAllComplTasksAsync(CancellationToken cancellationToken);
        /// <summary>
        /// Получает выполненную задачу по идентификтору
        /// </summary>
        /// <param name="id">Идентификатор выполенной задачи</param>
        /// <returns>Выполненная задача по указанному идентификатору</returns>
        Task<CompletedTasks> GetComplTasksByIdAsync(int id, CancellationToken cancellationToken);
        /// <summary>
        /// Добавление выполенной задачи
        /// </summary>
        /// <param name="newComplTask">Новая выполенная задача</param>
        /// <returns>Выполено</returns>
        Task AddComplTaskAsync(CompletedTasks newComplTask, CancellationToken cancellationToken);
        /// <summary>
        /// Изменение выполненной задачи
        /// </summary>
        /// <param name="id">Идентификатор выполненной задачи</param>
        /// <param name="updatedComplTask">Обновленная выполненная задача</param>
        /// <returns>Выполнено</returns>
        Task UpdateComplTaskAsync(int id, CompletedTasks updatedComplTask,CancellationToken cancellationToken);
        /// <summary>
        /// Удаление выполненной задачи
        /// </summary>
        /// <param name="id">Идентификатор выполненной задачи</param>
        /// <returns>Выполнено</returns>
        Task DeleteComplTaskAsync(int id, CancellationToken cancellationToken);
    }
    
}

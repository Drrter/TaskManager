using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// Реализация репозитория ICompletedTasksRepository
    /// </summary>
    public class CompletedTasksRepository : ICompletedTasksRepository
    {
        /// <summary>
        /// Передает TaskContext в конструктор
        /// </summary>
        private readonly TaskContext _context;

        public CompletedTasksRepository(TaskContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Получает список всех выполненных задач
        /// </summary>
        /// <returns>Список выполненных задач</returns>
        public async Task<List<CompletedTasks>> GetAllComplTasksAsync(CancellationToken cancellationToken)
        {
            return await _context.CompletedTasks.ToListAsync(cancellationToken);
        }
        /// <summary>
        /// Получает выполненную задачу по идентификтору
        /// </summary>
        /// <param name="id">Идентификатор выполенной задачи</param>
        /// <returns>Выполненная задача по указанному идентификатору</returns>
        public async Task<CompletedTasks> GetComplTasksByIdAsync(int id,CancellationToken cancellationToken)
        {
            return await _context.CompletedTasks.FindAsync(id,cancellationToken);
        }
        /// <summary>
        /// Добавление выполенной задачи
        /// </summary>
        /// <param name="newComplTask">Новая выполенная задача</param>
        /// <returns>Выполено</returns>
        public async Task AddComplTaskAsync(CompletedTasks newComplTask,CancellationToken cancellationToken)
        {
            _context.CompletedTasks.Add(newComplTask);
            await _context.SaveChangesAsync(cancellationToken);
        }
        /// <summary>
        /// Изменение выполненной задачи
        /// </summary>
        /// <param name="id">Идентификатор выполненной задачи</param>
        /// <param name="updatedComplTask">Обновленная выполненная задача</param>
        /// <returns>Выполнено</returns>
        public async Task UpdateComplTaskAsync(int id, CompletedTasks updatedComplTask,CancellationToken cancellationToken)
        {
            _context.Entry(updatedComplTask).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }
        /// <summary>
        /// Удаление выполненной задачи
        /// </summary>
        /// <param name="id">Идентификатор выполненной задачи</param>
        /// <returns>Выполнено</returns>
        public async Task DeleteComplTaskAsync(int id,CancellationToken cancellationToken)
        {
            var compltaskToDelete = await _context.CompletedTasks.FindAsync(id);
            if (compltaskToDelete != null)
            {
                _context.CompletedTasks.Remove(compltaskToDelete);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }

}

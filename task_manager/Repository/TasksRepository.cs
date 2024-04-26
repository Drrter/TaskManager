using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// Реализация репозитория ITasksRepository
    /// </summary>
    public class TasksRepository : ITasksRepository
    {
        private readonly TaskContext _context;
        /// <summary>
        /// Передает TaskContext в конструктор
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public TasksRepository(TaskContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Получает список всех задач
        /// </summary>
        /// <returns>Список задач</returns>
        public async Task<List<Tasks>> GetAllTasksAsync(CancellationToken cancellationToken)
        {
            return await _context.Tasks.ToListAsync(cancellationToken);
        }
        /// <summary>
        /// Получает задачу по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        /// <returns>Задача с указанным идентификатором</returns>
        public async Task<Tasks> GetTasksByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Tasks.FindAsync(id,cancellationToken);
        }
        /// <summary>
        /// Добавление новой задачи
        /// </summary>
        /// <param name="newTask">Новая задача</param>
        /// <returns>Выполнено</returns>
        public async Task AddTaskAsync(Tasks newTask, CancellationToken cancellationToken)
        {
            _context.Tasks.Add(newTask);
            await _context.SaveChangesAsync(cancellationToken);
        }
        /// <summary>
        /// Обновление существующей задачи
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        /// <param name="updatedTask">Обновленная задача</param>
        /// <returns>Выполнено</returns>
        public async Task UpdateTaskAsync(int id, Tasks updatedTask,CancellationToken cancellationToken)
        {
            _context.Entry(updatedTask).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }
        /// <summary>
        /// Удаление задачи
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        /// <returns>Выполнено</returns>
        public async Task DeleteTaskAsync(int id, CancellationToken cancellationToken)
        {
            var taskToDelete = await _context.Tasks.FindAsync(id);
            if (taskToDelete != null)
            {
                _context.Tasks.Remove(taskToDelete);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}

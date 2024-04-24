using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// интерфейс с методами управления задачами
    /// </summary>
    public interface ITasksRepository
    {
        /// <summary>
        /// получает список всех задач
        /// </summary>
        /// <returns>список задач</returns>
        Task<List<Tasks>> GetAllTasksAsync();
        /// <summary>
        /// получает задачу по идентификатору
        /// </summary>
        /// <param name="id">идентификатор задачи</param>
        /// <returns>задача с указанным идентификатором</returns>
        Task<Tasks> GetTasksByIdAsync(int id);
        /// <summary>
        /// добавление новой задачи
        /// </summary>
        /// <param name="newTask">новая задача</param>
        /// <returns>выполнено</returns>
        Task AddTaskAsync(Tasks newTask);
        /// <summary>
        /// обновление существующей задачи
        /// </summary>
        /// <param name="id">идентификатор задачи</param>
        /// <param name="updatedTask">обновленная задача</param>
        /// <returns>выполнено</returns>
        Task UpdateTaskAsync(int id, Tasks updatedTask);
        /// <summary>
        /// удаление задачи
        /// </summary>
        /// <param name="id">идентификатор задачи</param>
        /// <returns>выполнено</returns>
        Task DeleteTaskAsync(int id);
    }
    /// <summary>
    /// реализация репозитория ITasksRepository
    /// </summary>
    public class TasksRepository : ITasksRepository
    {
        private readonly TaskContext _context;
        /// <summary>
        /// передает TaskContext в конструктор
        /// </summary>
        /// <param name="context">контекст базы данных</param>
        public TasksRepository(TaskContext context)
        {
            _context = context;
        }
        /// <summary>
        /// получает список всех задач
        /// </summary>
        /// <returns>список задач</returns>
        public async Task<List<Tasks>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }
        /// <summary>
        /// получает задачу по идентификатору
        /// </summary>
        /// <param name="id">идентификатор задачи</param>
        /// <returns>задача с указанным идентификатором</returns>
        public async Task<Tasks> GetTasksByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }
        /// <summary>
        /// добавление новой задачи
        /// </summary>
        /// <param name="newTask">новая задача</param>
        /// <returns>выполнено</returns>
        public async Task AddTaskAsync(Tasks newTask)
        {
            _context.Tasks.Add(newTask);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// обновление существующей задачи
        /// </summary>
        /// <param name="id">идентификатор задачи</param>
        /// <param name="updatedTask">обновленная задача</param>
        /// <returns>выполнено</returns>
        public async Task UpdateTaskAsync(int id, Tasks updatedTask)
        {
            _context.Entry(updatedTask).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// удаление задачи
        /// </summary>
        /// <param name="id">идентификатор задачи</param>
        /// <returns>выполнено</returns>
        public async Task DeleteTaskAsync(int id)
        {
            var taskToDelete = await _context.Tasks.FindAsync(id);
            if (taskToDelete != null)
            {
                _context.Tasks.Remove(taskToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
    /// <summary>
    /// сервис для управления задачами
    /// </summary>
    public class TasksService
    {
        /// <summary>
        /// зависимость типа ITasksRepository
        /// </summary>
        private readonly ITasksRepository _tasksRepository;
        public TasksService(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }
        /// <summary>
        /// получает список всех задач
        /// </summary>
        /// <returns>список задач</returns>
        public async Task<List<Tasks>> GetAllTasksAsync(CancellationToken cancellationToken)
        {
            return await _tasksRepository.GetAllTasksAsync();
        }
        /// <summary>
        /// получает задачу по идентификатору
        /// </summary>
        /// <param name="id">идентификатор задачи</param>
        /// <returns>задача с указанным идентификатором</returns>
        public async Task<Tasks> GetTasksByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _tasksRepository.GetTasksByIdAsync(id);
        }
        /// <summary>
        /// добавление новой задачи
        /// </summary>
        /// <param name="newTask">новая задача</param>
        /// <returns>выполнено</returns>
        public async Task AddTaskAsync(Tasks newTask, CancellationToken cancellationToken)
        {
            await _tasksRepository.AddTaskAsync(newTask);
        }
        /// <summary>
        /// обновление существующей задачи
        /// </summary>
        /// <param name="id">идентификатор задачи</param>
        /// <param name="updatedTask">обновленная задача</param>
        /// <returns>выполнено</returns>
        public async Task UpdateTaskAsync(Tasks updatedTask, CancellationToken cancellationToken)
        {
            await _tasksRepository.UpdateTaskAsync(updatedTask.IdTask, updatedTask);
        }
        /// <summary>
        /// удаление задачи
        /// </summary>
        /// <param name="id">идентификатор задачи</param>
        /// <returns>выполнено</returns>
        public async Task DeleteTaskAsync(int id, CancellationToken cancellationToken)
        {
            await _tasksRepository.DeleteTaskAsync(id);
        }
    }
}

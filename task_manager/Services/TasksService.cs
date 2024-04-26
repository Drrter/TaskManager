using TaskManager.DB;
using TaskManager.Repository;

namespace TaskManager.Services
{
    /// <summary>
    /// Сервис для управления задачами
    /// </summary>
    public class TasksService
    {
        /// <summary>
        /// Зависимость типа ITasksRepository
        /// </summary>
        private readonly ITasksRepository _tasksRepository;
        public TasksService(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }
        /// <summary>
        /// Получает список всех задач
        /// </summary>
        /// <returns>Список задач</returns>
        public async Task<List<Tasks>> GetAllTasksAsync(CancellationToken cancellationToken)
        {
            return await _tasksRepository.GetAllTasksAsync(cancellationToken);
        }
        /// <summary>
        /// Получает задачу по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        /// <returns>Задача с указанным идентификатором</returns>
        public async Task<Tasks> GetTasksByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _tasksRepository.GetTasksByIdAsync(id, cancellationToken);
        }
        /// <summary>
        /// Добавление новой задачи
        /// </summary>
        /// <param name="newTask">Новая задача</param>
        /// <returns>Выполнено</returns>
        public async Task AddTaskAsync(Tasks newTask, CancellationToken cancellationToken)
        {
            await _tasksRepository.AddTaskAsync(newTask, cancellationToken);
        }
        /// <summary>
        /// Обновление существующей задачи
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        /// <param name="updatedTask">Обновленная задача</param>
        /// <returns>Выполнено</returns>
        public async Task UpdateTaskAsync(Tasks updatedTask, CancellationToken cancellationToken)
        {
            await _tasksRepository.UpdateTaskAsync(updatedTask.Id, updatedTask, cancellationToken);
        }
        /// <summary>
        /// Удаление задачи
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        /// <returns>Выполнено</returns>
        public async Task DeleteTaskAsync(int id, CancellationToken cancellationToken)
        {
            await _tasksRepository.DeleteTaskAsync(id, cancellationToken);
        }
    }
}

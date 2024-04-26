using TaskManager.DB;
using TaskManager.Repository;

namespace TaskManager.Services
{
    /// <summary>
    /// Сервис для управления выполненными задачами
    /// </summary>
    public class CompletedTasksService
    {
        /// <summary>
        /// Зависимость типа ICompletedTasksRepository
        /// </summary>
        private readonly ICompletedTasksRepository _compltasksRepository;
        public CompletedTasksService(ICompletedTasksRepository compltasksRepository)
        {
            _compltasksRepository = compltasksRepository;
        }
        /// <summary>
        /// Получает список всех выполненных задач
        /// </summary>
        /// <returns>Список выполненных задач</returns>
        public async Task<List<CompletedTasks>> GetAllComplTasksAsync(CancellationToken cancellationToken)
        {
            return await _compltasksRepository.GetAllComplTasksAsync(cancellationToken);
        }
        /// <summary>
        /// Получает выполненную задачу по идентификтору
        /// </summary>
        /// <param name="id">Идентификатор выполенной задачи</param>
        /// <returns>Выполненная задача по указанному идентификатору</returns>
        public async Task<CompletedTasks> GetComplTasksByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _compltasksRepository.GetComplTasksByIdAsync(id, cancellationToken);
        }
        /// <summary>
        /// Добавление выполенной задачи
        /// </summary>
        /// <param name="newComplTask">Новая выполенная задача</param>
        /// <returns>Выполено</returns>
        public async Task AddComplTaskAsync(CompletedTasks newComplTask, CancellationToken cancellationToken)
        {
            await _compltasksRepository.AddComplTaskAsync(newComplTask, cancellationToken);
        }
        /// <summary>
        /// Изменение выполненной задачи
        /// </summary>
        /// <param name="id">Идентификатор выполненной задачи</param>
        /// <param name="updatedComplTask">Обновленная выполненная задача</param>
        /// <returns>Выполнено</returns>
        public async Task UpdateComplTaskAsync(CompletedTasks updatedComplTask, CancellationToken cancellationToken)
        {
            await _compltasksRepository.UpdateComplTaskAsync(updatedComplTask.Id, updatedComplTask,cancellationToken);
        }
        /// <summary>
        /// Удаление выполненной задачи
        /// </summary>
        /// <param name="id">Идентификатор выполненной задачи</param>
        /// <returns>Выполнено</returns>
        public async Task DeleteComplTaskAsync(int id, CancellationToken cancellationToken)
        {
            await _compltasksRepository.DeleteComplTaskAsync(id, cancellationToken);
        }
    }
}

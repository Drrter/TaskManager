using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// интерфейс с методами управления выполненными задачами
    /// </summary>
    public interface ICompletedTasksRepository
    {
        /// <summary>
        /// получает список всех выполненных задач
        /// </summary>
        /// <returns>список выполненных задач</returns>
        Task<List<CompletedTasks>> GetAllComplTasksAsync();
        /// <summary>
        /// получает выполненную задачу по идентификтору
        /// </summary>
        /// <param name="id">идентификатор выполенной задачи</param>
        /// <returns>выполненная задача по указанному идентификатору</returns>
        Task<CompletedTasks> GetComplTasksByIdAsync(int id);
        /// <summary>
        /// добавление выполенной задачи
        /// </summary>
        /// <param name="newComplTask">новая выполенная задача</param>
        /// <returns>выполено</returns>
        Task AddComplTaskAsync(CompletedTasks newComplTask);
        /// <summary>
        /// изменение выполненной задачи
        /// </summary>
        /// <param name="id">идентификатор выполненной задачи</param>
        /// <param name="updatedComplTask">обновленная выполненная задача</param>
        /// <returns>выполнено</returns>
        Task UpdateComplTaskAsync(int id, CompletedTasks updatedComplTask);
        /// <summary>
        /// удаление выполненной задачи
        /// </summary>
        /// <param name="id">идентификатор выполненной задачи</param>
        /// <returns></returns>
        Task DeleteComplTaskAsync(int id);
    }
    /// <summary>
    /// реализация репозитория ICompletedTasksRepository
    /// </summary>
    public class CompletedTasksRepository : ICompletedTasksRepository
    {
        /// <summary>
        /// передает TaskContext в конструктор
        /// </summary>
        private readonly TaskContext _context;

        public CompletedTasksRepository(TaskContext context)
        {
            _context = context;
        }
        /// <summary>
        /// получает список всех выполненных задач
        /// </summary>
        /// <returns>список выполненных задач</returns>
        public async Task<List<CompletedTasks>> GetAllComplTasksAsync()
        {
            return await _context.CompletedTasks.ToListAsync();
        }
        /// <summary>
        /// получает выполненную задачу по идентификтору
        /// </summary>
        /// <param name="id">идентификатор выполенной задачи</param>
        /// <returns>выполненная задача по указанному идентификатору</returns>
        public async Task<CompletedTasks> GetComplTasksByIdAsync(int id)
        {
            return await _context.CompletedTasks.FindAsync(id);
        }
        /// <summary>
        /// добавление выполенной задачи
        /// </summary>
        /// <param name="newComplTask">новая выполенная задача</param>
        /// <returns>выполено</returns>
        public async Task AddComplTaskAsync(CompletedTasks newComplTask)
        {
            _context.CompletedTasks.Add(newComplTask);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// изменение выполненной задачи
        /// </summary>
        /// <param name="id">идентификатор выполненной задачи</param>
        /// <param name="updatedComplTask">обновленная выполненная задача</param>
        /// <returns>выполнено</returns>
        public async Task UpdateComplTaskAsync(int id, CompletedTasks updatedComplTask)
        {
            _context.Entry(updatedComplTask).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// удаление выполненной задачи
        /// </summary>
        /// <param name="id">идентификатор выполненной задачи</param>
        /// <returns></returns>
        public async Task DeleteComplTaskAsync(int id)
        {
            var compltaskToDelete = await _context.CompletedTasks.FindAsync(id);
            if (compltaskToDelete != null)
            {
                _context.CompletedTasks.Remove(compltaskToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
    /// <summary>
    /// сервис для управления выполненными задачами
    /// </summary>
    public class CompletedTasksService
    {
        /// <summary>
        /// зависимость типа ICompletedTasksRepository
        /// </summary>
        private readonly ICompletedTasksRepository _compltasksRepository;
        public CompletedTasksService(ICompletedTasksRepository compltasksRepository)
        {
            _compltasksRepository = compltasksRepository;
        }
        /// <summary>
        /// получает список всех выполненных задач
        /// </summary>
        /// <returns>список выполненных задач</returns>
        public async Task<List<CompletedTasks>> GetAllComplTasksAsync(CancellationToken cancellationToken)
        {
            return await _compltasksRepository.GetAllComplTasksAsync();
        }
        /// <summary>
        /// получает выполненную задачу по идентификтору
        /// </summary>
        /// <param name="id">идентификатор выполенной задачи</param>
        /// <returns>выполненная задача по указанному идентификатору</returns>
        public async Task<CompletedTasks> GetComplTasksByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _compltasksRepository.GetComplTasksByIdAsync(id);
        }
        /// <summary>
        /// добавление выполенной задачи
        /// </summary>
        /// <param name="newComplTask">новая выполенная задача</param>
        /// <returns>выполено</returns>
        public async Task AddComplTaskAsync(CompletedTasks newComplTask, CancellationToken cancellationToken)
        {
            await _compltasksRepository.AddComplTaskAsync(newComplTask);
        }
        /// <summary>
        /// изменение выполненной задачи
        /// </summary>
        /// <param name="id">идентификатор выполненной задачи</param>
        /// <param name="updatedComplTask">обновленная выполненная задача</param>
        /// <returns>выполнено</returns>
        public async Task UpdateComplTaskAsync(CompletedTasks updatedComplTask, CancellationToken cancellationToken)
        {
            await _compltasksRepository.UpdateComplTaskAsync(updatedComplTask.IdCompltask, updatedComplTask);
        }
        /// <summary>
        /// удаление выполненной задачи
        /// </summary>
        /// <param name="id">идентификатор выполненной задачи</param>
        /// <returns></returns>
        public async Task DeleteComplTaskAsync(int id, CancellationToken cancellationToken)
        {
            await _compltasksRepository.DeleteComplTaskAsync(id);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// интерфейс с методами управления статусами
    /// </summary>
    public interface IStatusTasksRepository
    {
        /// <summary>
        /// получает список всех статусов
        /// </summary>
        /// <returns>список статусов</returns>
        Task<List<StatusTask>> GetAllStatusAsync();
        /// <summary>
        /// получает статус по идентификатору
        /// </summary>
        /// <param name="id">идентификатор статуса</param>
        /// <returns>статус с указанным идентификатором</returns>
        Task<StatusTask> GetStatusByIdAsync(int id);
    }
    /// <summary>
    /// реализация репозитория IStatusTasksRepository
    /// </summary>
    public class StatusTasksRerository:IStatusTasksRepository
    {
        /// <summary>
        /// передает TaskContext в конструктор
        /// </summary>
        private readonly TaskContext _context;
        public StatusTasksRerository(TaskContext context)
        {
            _context = context;
        }
        /// <summary>
        /// получает список всех статусов
        /// </summary>
        /// <returns>список статусов</returns>
        public async Task<List<StatusTask>> GetAllStatusAsync()
        {
            return await _context.StatusTasks.ToListAsync();
        }
        /// <summary>
        /// получает статус по идентификатору
        /// </summary>
        /// <param name="id">идентификатор статуса</param>
        /// <returns>статус с указанным идентификатором</returns>
        public async Task<StatusTask> GetStatusByIdAsync(int id)
        {
            return await _context.StatusTasks.FindAsync(id);
        }
    }
    /// <summary>
    /// сервис для управления статусами
    /// </summary>
    public class StatusService
    {
        /// <summary>
        /// зависимость типа IStatusTasksRepository
        /// </summary>
        private readonly IStatusTasksRepository _statusTasksRepository;
        public StatusService(IStatusTasksRepository statusTasksRepository)
        {
            _statusTasksRepository = statusTasksRepository;
        }
        /// <summary>
        /// получает список всех статусов
        /// </summary>
        /// <returns>список статусов</returns>
        public async Task<List<StatusTask>> GetAllStatusAsync(CancellationToken cancellationToken)
        {
            return await _statusTasksRepository.GetAllStatusAsync();
        }
        /// <summary>
        /// получает статус по идентификатору
        /// </summary>
        /// <param name="id">идентификатор статуса</param>
        /// <returns>статус с указанным идентификатором</returns>
        public async Task<StatusTask> GetStatusByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _statusTasksRepository.GetStatusByIdAsync(id);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// Реализация репозитория IStatusTasksRepository
    /// </summary>
    public class StatusTasksRerository : IStatusTasksRepository
    {
        /// <summary>
        /// Передает TaskContext в конструктор
        /// </summary>
        private readonly TaskContext _context;
        public StatusTasksRerository(TaskContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Получает список всех статусов
        /// </summary>
        /// <returns>Список статусов</returns>
        public async Task<List<StatusTask>> GetAllStatusAsync(CancellationToken cancellationToken)
        {
            return await _context.StatusTasks.ToListAsync(cancellationToken);
        }
        /// <summary>
        /// Получает статус по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор статуса</param>
        /// <returns>Статус с указанным идентификатором</returns>
        public async Task<StatusTask> GetStatusByIdAsync(int id,CancellationToken cancellationToken)
        {
            return await _context.StatusTasks.FindAsync(id,cancellationToken);
        }
    }
}

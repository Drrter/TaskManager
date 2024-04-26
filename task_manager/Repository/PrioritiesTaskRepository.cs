using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// Реализация репозитория IPrioritiesTaskRepository
    /// </summary>
    public class PrioritiesTaskRepository : IPrioritiesTaskRepository
    {
        /// <summary>
        /// Передает TaskContext в конструктор
        /// </summary>
        private readonly TaskContext _context;

        public PrioritiesTaskRepository(TaskContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Получает список всех приоритетов
        /// </summary>
        /// <returns>Список приоритетов</returns>
        public async Task<List<PrioritiesTask>> GetAllPriorityAsync(CancellationToken cancellationToken)
        {
            return await _context.PrioritiesTask.ToListAsync(cancellationToken);
        }
        /// <summary>
        /// Получает приоритет по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор приоритета</param>
        /// <returns>Приоритет с указанным идентификатором</returns>
        public async Task<PrioritiesTask> GetPriorityByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.PrioritiesTask.FindAsync(id,cancellationToken);
        }
    }
}

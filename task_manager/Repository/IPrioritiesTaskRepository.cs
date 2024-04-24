using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// интерфейс с методами управления приоритетами
    /// </summary>
    public interface IPrioritiesTaskRepository
    {
        /// <summary>
        /// получает список всех приоритетов
        /// </summary>
        /// <returns>список приоритетов</returns>
        Task<List<PrioritiesTask>> GetAllPriorityAsync();
        /// <summary>
        /// получает приоритет по идентификатору
        /// </summary>
        /// <param name="id">идентификатор приоритета</param>
        /// <returns>приоритет с указанным идентификатором</returns>
        Task<PrioritiesTask> GetPriorityByIdAsync(int id);
    }
    /// <summary>
    /// реализаци репозитория IPrioritiesTaskRepository
    /// </summary>
    public class PrioritiesTaskRepository : IPrioritiesTaskRepository
    {
        /// <summary>
        /// передает TaskContext в конструктор
        /// </summary>
        private readonly TaskContext _context;

        public PrioritiesTaskRepository(TaskContext context)
        {
            _context = context;
        }
        /// <summary>
        /// получает список всех приоритетов
        /// </summary>
        /// <returns>список приоритетов</returns>
        public async Task<List<PrioritiesTask>> GetAllPriorityAsync()
        {
            return await _context.PrioritiesTask.ToListAsync();
        }
        /// <summary>
        /// получает приоритет по идентификатору
        /// </summary>
        /// <param name="id">идентификатор приоритета</param>
        /// <returns>приоритет с указанным идентификатором</returns>
        public async Task<PrioritiesTask> GetPriorityByIdAsync(int id)
        {
            return await _context.PrioritiesTask.FindAsync(id);
        }
    }
    /// <summary>
    /// сервис для управления приоритетами
    /// </summary>
    public class PrioritiesServices
    {
        /// <summary>
        /// зависимость типа IPrioritiesTaskRepository
        /// </summary>
        private readonly IPrioritiesTaskRepository _prioritiesTaskRepository;

        public PrioritiesServices(IPrioritiesTaskRepository prioritiesTaskRepository)
        {
            _prioritiesTaskRepository = prioritiesTaskRepository;
        }
        /// <summary>
        /// получает список всех приоритетов
        /// </summary>
        /// <returns>список приоритетов</returns>
        public async Task<List<PrioritiesTask>> GetAllPriorityAsync(CancellationToken cancellationToken)
        {
            return await _prioritiesTaskRepository.GetAllPriorityAsync();
        }
        /// <summary>
        /// получает приоритет по идентификатору
        /// </summary>
        /// <param name="id">идентификатор приоритета</param>
        /// <returns>приоритет с указанным идентификатором</returns>
        public async Task<PrioritiesTask> GetPriorityByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _prioritiesTaskRepository.GetPriorityByIdAsync(id);
        }
    }
}

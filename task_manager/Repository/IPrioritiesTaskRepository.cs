using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    public interface IPrioritiesTaskRepository
    {
        Task<List<PrioritiesTask>> GetAllPriority();
        Task<PrioritiesTask> GetPriorityById(int id);
    }
    public class PrioritiesTaskRepository : IPrioritiesTaskRepository
    {
        private readonly TaskContext _context;

        public PrioritiesTaskRepository(TaskContext context)
        {
            _context = context;
        }

        public async Task<List<PrioritiesTask>> GetAllPriority()
        {
            return await _context.PrioritiesTask.ToListAsync();
        }

        public async Task<PrioritiesTask> GetPriorityById(int id)
        {
            return await _context.PrioritiesTask.FindAsync(id);
        }
    }
    public class PrioritiesServices
    {
        private readonly IPrioritiesTaskRepository _prioritiesTaskRepository;

        public PrioritiesServices(IPrioritiesTaskRepository prioritiesTaskRepository)
        {
            _prioritiesTaskRepository = prioritiesTaskRepository;
        }

        public async Task<List<PrioritiesTask>> GetAllPriority()
        {
            return await _prioritiesTaskRepository.GetAllPriority();
        }

        public async Task<PrioritiesTask> GetPriorityById(int id)
        {
            return await _prioritiesTaskRepository.GetPriorityById(id);
        }
    }
}

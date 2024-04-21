using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    public interface IStatusTasksRepository
    {
        Task<List<StatusTask>> GetAllStatus();
        Task<StatusTask> GetStatusById(int id);
    }
    public class StatusTasksRerository:IStatusTasksRepository
    {
        private readonly TaskContext _context;

        public StatusTasksRerository(TaskContext context)
        {
            _context = context;
        }

        public async Task<List<StatusTask>> GetAllStatus()
        {
            return await _context.StatusTasks.ToListAsync();
        }

        public async Task<StatusTask> GetStatusById(int id)
        {
            return await _context.StatusTasks.FindAsync(id);
        }
    }
    public class StatusService
    {
        private readonly IStatusTasksRepository _statusTasksRepository;

        public StatusService(IStatusTasksRepository statusTasksRepository)
        {
            _statusTasksRepository = statusTasksRepository;
        }

        public async Task<List<StatusTask>> GetAllStatus()
        {
            return await _statusTasksRepository.GetAllStatus();
        }

        public async Task<StatusTask> GetStatusById(int id)
        {
            return await _statusTasksRepository.GetStatusById(id);
        }
    }
}

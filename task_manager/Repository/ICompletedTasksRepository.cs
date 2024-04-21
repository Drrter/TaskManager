using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    public interface ICompletedTasksRepository
    {
        Task<List<CompletedTasks>> GetAllComplTasks();
        Task<CompletedTasks> GetComplTasksById(int id);
        Task AddComplTask(CompletedTasks newComplTask);
        Task UpdateComplTask(int id, CompletedTasks updatedComplTask);
        Task DeleteComplTask(int id);
    }
    public class CompletedTasksRepository : ICompletedTasksRepository
    {
        private readonly TaskContext _context;

        public CompletedTasksRepository(TaskContext context)
        {
            _context = context;
        }

        public async Task<List<CompletedTasks>> GetAllComplTasks()
        {
            return await _context.CompletedTasks.ToListAsync();
        }

        public async Task<CompletedTasks> GetComplTasksById(int id)
        {
            return await _context.CompletedTasks.FindAsync(id);
        }

        public async Task AddComplTask(CompletedTasks newComplTask)
        {
            _context.CompletedTasks.Add(newComplTask);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateComplTask(int id, CompletedTasks updatedComplTask)
        {
            _context.Entry(updatedComplTask).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteComplTask(int id)
        {
            var compltaskToDelete = await _context.CompletedTasks.FindAsync(id);
            if (compltaskToDelete != null)
            {
                _context.CompletedTasks.Remove(compltaskToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
    public class CompletedTasksService
    {
        private readonly ICompletedTasksRepository _compltasksRepository;
        public CompletedTasksService(ICompletedTasksRepository compltasksRepository)
        {
            _compltasksRepository = compltasksRepository;
        }

        public async Task<List<CompletedTasks>> GetAllComplTasks()
        {
            return await _compltasksRepository.GetAllComplTasks();
        }

        public async Task<CompletedTasks> GetComplTasksById(int id)
        {
            return await _compltasksRepository.GetComplTasksById(id);
        }
        public async Task AddComplTask(CompletedTasks newComplTask)
        {
            await _compltasksRepository.AddComplTask(newComplTask);
        }

        public async Task UpdateComplTask(CompletedTasks updatedComplTask)
        {
            await _compltasksRepository.UpdateComplTask(updatedComplTask.IdCompltask, updatedComplTask);
        }
        public async Task DeleteComplTask(int id)
        {
            await _compltasksRepository.DeleteComplTask(id);
        }
    }
}

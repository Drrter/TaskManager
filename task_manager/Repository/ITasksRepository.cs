using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    public interface ITasksRepository
    {
        Task<List<Tasks>> GetAllTasks();
        Task<Tasks> GetTasksById(int id);
        Task AddTask(Tasks newTask);
        Task UpdateTask(int id, Tasks updatedTask);
        Task DeleteTask(int id);
    }
    public class TasksRepository : ITasksRepository
    {
        private readonly TaskContext _context;

        public TasksRepository(TaskContext context)
        {
            _context = context;
        }

        public async Task<List<Tasks>> GetAllTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Tasks> GetTasksById(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task AddTask(Tasks newTask)
        {
            _context.Tasks.Add(newTask);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTask(int id, Tasks updatedTask)
        {
            _context.Entry(updatedTask).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTask(int id)
        {
            var taskToDelete = await _context.Tasks.FindAsync(id);
            if (taskToDelete != null)
            {
                _context.Tasks.Remove(taskToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
    public class TasksService
    {
        private readonly ITasksRepository _tasksRepository;
        public TasksService(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public async Task<List<Tasks>> GetAllTasks()
        {
            return await _tasksRepository.GetAllTasks();
        }

        public async Task<Tasks> GetTasksById(int id)
        {
            return await _tasksRepository.GetTasksById(id);
        }
        public async Task AddTask(Tasks newTask)
        {
            await _tasksRepository.AddTask(newTask);
        }

        public async Task UpdateTask(Tasks updatedTask)
        {
            await _tasksRepository.UpdateTask(updatedTask.IdTask, updatedTask);
        }
        public async Task DeleteTask(int id)
        {
            await _tasksRepository.DeleteTask(id);
        }
    }
}

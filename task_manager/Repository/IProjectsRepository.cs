using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    public interface IProjectsRepository
    {
        Task<List<Projects>> GetAllProjects();
        Task<Projects> GetProjectById(int id);
        Task AddProject(Projects newProject);
        Task UpdateProject(int id, Projects updatedProject);
        Task DeleteProject(int id);
    }
    public class ProjectsRepository : IProjectsRepository
    {

        private readonly TaskContext _context;

        public ProjectsRepository(TaskContext context)
        {
            _context = context;
        }

        public async Task<List<Projects>> GetAllProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Projects> GetProjectById(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task AddProject(Projects newProject)
        {
            _context.Projects.Add(newProject);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProject(int id, Projects updatedProject)
        {
            _context.Entry(updatedProject).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProject(int id)
        {
            var projectToDelete = await _context.Projects.FindAsync(id);
            if (projectToDelete != null)
            {
                _context.Projects.Remove(projectToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
    public class ProjectsService
    {
        private readonly IProjectsRepository _projectsRepository;
        public ProjectsService(IProjectsRepository projectRepository)
        {
            _projectsRepository = projectRepository;
        }

        public async Task<List<Projects>> GetAllProjects()
        {
            return await _projectsRepository.GetAllProjects();
        }

        public async Task<Projects> GetProjectById(int id)
        {
            return await _projectsRepository.GetProjectById(id);
        }
        public async Task AddProject(Projects newProject)
        {
            await _projectsRepository.AddProject(newProject);
        }

        public async Task UpdateProject(Projects updatedProject)
        {
            await _projectsRepository.UpdateProject(updatedProject.IdProject, updatedProject);
        }
        public async Task DeleteProject(int id)
        {
            await _projectsRepository.DeleteProject(id);
        }
    }
}

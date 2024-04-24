using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// интерфейс с методами управления проектами
    /// </summary>
    public interface IProjectsRepository
    {
        /// <summary>
        /// получает список всех проектов
        /// </summary>
        /// <returns>список проектов</returns>
        Task<List<Projects>> GetAllProjectsAsync();
        /// <summary>
        /// получает проект по идентификатору
        /// </summary>
        /// <param name="id">идентификатор проекта</param>
        /// <returns>проект с указанным идентификатором</returns>
        Task<Projects> GetProjectByIdAsync(int id);
        /// <summary>
        /// добавление проекта
        /// </summary>
        /// <param name="newProject">новый проект</param>
        /// <returns>выполнено</returns>
        Task AddProjectAsync(Projects newProject);
        /// <summary>
        /// обновление существующего проекта
        /// </summary>
        /// <param name="id">идентификатор проекта</param>
        /// <param name="updatedProject">обновленный проект</param>
        /// <returns>выполнено</returns>
        Task UpdateProjectAsync(int id, Projects updatedProject);
        /// <summary>
        /// удаление проекта 
        /// </summary>
        /// <param name="id">идентификатор проекта</param>
        /// <returns>выполнено</returns>
        Task DeleteProjectAsync(int id);
    }
    public class ProjectsRepository : IProjectsRepository
    {
        /// <summary>
        /// передает TaskContext в конструктор
        /// </summary>
        private readonly TaskContext _context;

        public ProjectsRepository(TaskContext context)
        {
            _context = context;
        }
        /// <summary>
        /// получает список всех проектов
        /// </summary>
        /// <returns>список проектов</returns>
        public async Task<List<Projects>> GetAllProjectsAsync()
        {
            return await _context.Projects.ToListAsync();
        }
        /// <summary>
        /// получает проект по идентификатору
        /// </summary>
        /// <param name="id">идентификатор проекта</param>
        /// <returns>проект с указанным идентификатором</returns>
        public async Task<Projects> GetProjectByIdAsync(int id)
        {
            return await _context.Projects.FindAsync(id);
        }
        /// <summary>
        /// добавление проекта
        /// </summary>
        /// <param name="newProject">новый проект</param>
        /// <returns>выполнено</returns>
        public async Task AddProjectAsync(Projects newProject)
        {
            _context.Projects.Add(newProject);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// обновление существующего проекта
        /// </summary>
        /// <param name="id">идентификатор проекта</param>
        /// <param name="updatedProject">обновленный проект</param>
        /// <returns>выполнено</returns>
        public async Task UpdateProjectAsync(int id, Projects updatedProject)
        {
            _context.Entry(updatedProject).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// удаление проекта 
        /// </summary>
        /// <param name="id">идентификатор проекта</param>
        /// <returns>выполнено</returns>
        public async Task DeleteProjectAsync(int id)
        {
            var projectToDelete = await _context.Projects.FindAsync(id);
            if (projectToDelete != null)
            {
                _context.Projects.Remove(projectToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
    /// <summary>
    /// сервис для управения проектами
    /// </summary>
    public class ProjectsService
    {
        /// <summary>
        /// зависимость типа IProjectsRepository
        /// </summary>
        private readonly IProjectsRepository _projectsRepository;
        public ProjectsService(IProjectsRepository projectRepository)
        {
            _projectsRepository = projectRepository;
        }
        /// <summary>
        /// получает список всех проектов
        /// </summary>
        /// <returns>список проектов</returns>
        public async Task<List<Projects>> GetAllProjectsAsync()
        {
            return await _projectsRepository.GetAllProjectsAsync();
        }
        /// <summary>
        /// получает проект по идентификатору
        /// </summary>
        /// <param name="id">идентификатор проекта</param>
        /// <returns>проект с указанным идентификатором</returns>
        public async Task<Projects> GetProjectByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _projectsRepository.GetProjectByIdAsync(id);
        }
        /// <summary>
        /// добавление проекта
        /// </summary>
        /// <param name="newProject">новый проект</param>
        /// <returns>выполнено</returns>
        public async Task AddProjectAsync(Projects newProject, CancellationToken cancellationToken)
        {
            await _projectsRepository.AddProjectAsync(newProject);
        }
        /// <summary>
        /// обновление существующего проекта
        /// </summary>
        /// <param name="id">идентификатор проекта</param>
        /// <param name="updatedProject">обновленный проект</param>
        /// <returns>выполнено</returns>
        public async Task UpdateProjectAsync(Projects updatedProject, CancellationToken cancellationToken)
        {
            await _projectsRepository.UpdateProjectAsync(updatedProject.IdProject, updatedProject);
        }
        /// <summary>
        /// удаление проекта 
        /// </summary>
        /// <param name="id">идентификатор проекта</param>
        /// <returns>выполнено</returns>
        public async Task DeleteProjectAsync(int id)
        {
            await _projectsRepository.DeleteProjectAsync(id);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// Реализация репозитория IProjectsRepository
    /// </summary>
    public class ProjectsRepository : IProjectsRepository
    {
        /// <summary>
        /// Передает TaskContext в конструктор
        /// </summary>
        private readonly TaskContext _context;

        public ProjectsRepository(TaskContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Получает список всех проектов
        /// </summary>
        /// <returns>Список проектов</returns>
        public async Task<List<Projects>> GetAllProjectsAsync(CancellationToken cancellationToken)
        {
            return await _context.Projects.ToListAsync();
        }
        /// <summary>
        /// Получает проект по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор проекта</param>
        /// <returns>Проект с указанным идентификатором</returns>
        public async Task<Projects> GetProjectByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Projects.FindAsync(id,cancellationToken);
        }
        /// <summary>
        /// Добавление проекта
        /// </summary>
        /// <param name="newProject">Новый проект</param>
        /// <returns>Выполнено</returns>
        public async Task AddProjectAsync(Projects newProject, CancellationToken cancellationToken)
        {
            _context.Projects.Add(newProject);
            await _context.SaveChangesAsync(cancellationToken);
        }
        /// <summary>
        /// Обновление существующего проекта
        /// </summary>
        /// <param name="id">Идентификатор проекта</param>
        /// <param name="updatedProject">Обновленный проект</param>
        /// <returns>Выполнено</returns>
        public async Task UpdateProjectAsync(int id, Projects updatedProject, CancellationToken cancellationToken)
        {
            _context.Entry(updatedProject).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }
        /// <summary>
        /// Удаление проекта 
        /// </summary>
        /// <param name="id">Идентификатор проекта</param>
        /// <returns>Выполнено</returns>
        public async Task DeleteProjectAsync(int id, CancellationToken cancellationToken)
        {
            var projectToDelete = await _context.Projects.FindAsync(id);
            if (projectToDelete != null)
            {
                _context.Projects.Remove(projectToDelete);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}

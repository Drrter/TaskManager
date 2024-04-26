using TaskManager.DB;
using TaskManager.Repository;

namespace TaskManager.Services
{
    /// <summary>
    /// Сервис для управения проектами
    /// </summary>
    public class ProjectsService
    {
        /// <summary>
        /// Зависимость типа IProjectsRepository
        /// </summary>
        private readonly IProjectsRepository _projectsRepository;
        public ProjectsService(IProjectsRepository projectRepository)
        {
            _projectsRepository = projectRepository;
        }
        /// <summary>
        /// Получает список всех проектов
        /// </summary>
        /// <returns>Список проектов</returns>
        public async Task<List<Projects>> GetAllProjectsAsync(CancellationToken cancellationToken)
        {
            return await _projectsRepository.GetAllProjectsAsync(cancellationToken);
        }
        /// <summary>
        /// Получает проект по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор проекта</param>
        /// <returns>Проект с указанным идентификатором</returns>
        public async Task<Projects> GetProjectByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _projectsRepository.GetProjectByIdAsync(id, cancellationToken);
        }
        /// <summary>
        /// Добавление проекта
        /// </summary>
        /// <param name="newProject">Новый проект</param>
        /// <returns>Выполнено</returns>
        public async Task AddProjectAsync(Projects newProject, CancellationToken cancellationToken)
        {
            await _projectsRepository.AddProjectAsync(newProject, cancellationToken);
        }
        /// <summary>
        /// Обновление существующего проекта
        /// </summary>
        /// <param name="id">Идентификатор проекта</param>
        /// <param name="updatedProject">Обновленный проект</param>
        /// <returns>Выполнено</returns>
        public async Task UpdateProjectAsync(Projects updatedProject, CancellationToken cancellationToken)
        {
            await _projectsRepository.UpdateProjectAsync(updatedProject.Id, updatedProject, cancellationToken);
        }
        /// <summary>
        /// Удаление проекта 
        /// </summary>
        /// <param name="id">Идентификатор проекта</param>
        /// <returns>Выполнено</returns>
        public async Task DeleteProjectAsync(int id,CancellationToken cancellationToken)
        {
            await _projectsRepository.DeleteProjectAsync(id, cancellationToken);
        }
    }
}

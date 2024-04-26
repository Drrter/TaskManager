using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// Интерфейс с методами управления проектами
    /// </summary>
    public interface IProjectsRepository
    {
        /// <summary>
        /// Получает список всех проектов
        /// </summary>
        /// <returns>Список проектов</returns>
        Task<List<Projects>> GetAllProjectsAsync(CancellationToken cancellationToken);
        /// <summary>
        /// Получает проект по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор проекта</param>
        /// <returns>Проект с указанным идентификатором</returns>
        Task<Projects> GetProjectByIdAsync(int id,CancellationToken cancellationToken);
        /// <summary>
        /// Добавление проекта
        /// </summary>
        /// <param name="newProject">Новый проект</param>
        /// <returns>Выполнено</returns>
        Task AddProjectAsync(Projects newProject,CancellationToken cancellationToken);
        /// <summary>
        /// Обновление существующего проекта
        /// </summary>
        /// <param name="id">Идентификатор проекта</param>
        /// <param name="updatedProject">Обновленный проект</param>
        /// <returns>Выполнено</returns>
        Task UpdateProjectAsync(int id, Projects updatedProject,CancellationToken cancellationToken);
        /// <summary>
        /// Удаление проекта 
        /// </summary>
        /// <param name="id">Идентификатор проекта</param>
        /// <returns>Выполнено</returns>
        Task DeleteProjectAsync(int id,CancellationToken cancellationToken);
    }
    
}

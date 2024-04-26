using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager;
using TaskManager.DB;
using TaskManager.Repository;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    /// <summary>
    /// Контроллер работы с проектами
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectsService _projectsService;
        /// <summary>
        /// Конструктор контроллера ProjectsController
        /// </summary>
        /// <param name="projectsService">Сервис проектов</param>
        public ProjectsController(ProjectsService projectsService)
        {
            _projectsService = projectsService;
        }
        /// <summary>
        /// Получить список всех проектов
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список проектов</returns>
        [HttpGet]
        public async Task<ActionResult<List<Projects>>> GetAllProjectsAsync(CancellationToken cancellationToken)
        {
            var projects = await _projectsService.GetAllProjectsAsync(cancellationToken);
            return Ok(projects);
        }
        /// <summary>
        /// Получить проект по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор проекта</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Проект по указанному идентификатору</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Projects>> GetProjectByIdAsync(int id, CancellationToken cancellationToken)
        {
            var @project = await _projectsService.GetProjectByIdAsync(id,cancellationToken);
            if (@project == null)
            {
                return NotFound();
            }
            return @project;
        }
        /// <summary>
        /// Добавить новый проект
        /// </summary>
        /// <param name="newProject">Новый проект</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Выполнено</returns>
        [HttpPost]
        public async Task<ActionResult<Projects>> AddProjectAsync(Projects newProject, CancellationToken cancellationToken)
        {
            await _projectsService.AddProjectAsync(newProject,cancellationToken);
            return CreatedAtAction(nameof(GetProjectByIdAsync), new { id = newProject.Id }, newProject);
        }
        /// <summary>
        /// Обновление данных проекта
        /// </summary>
        /// <param name="id">Идентификатор проекта</param>
        /// <param name="updatedProject">Обновленный проект</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Выполнено</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProjectAsync(int id, Projects updatedProject,CancellationToken cancellationToken)
        {
            if (id != updatedProject.Id)
            {
                return BadRequest();
            }

            await _projectsService.UpdateProjectAsync(updatedProject,cancellationToken);

            return NoContent();
        }
        /// <summary>
        /// Удаление проекта
        /// </summary>
        /// <param name="id">Идентификатор проекта</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Выполнено</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectAsync(int id,CancellationToken cancellationToken)
        {
            var projectToDelete = await _projectsService.GetProjectByIdAsync(id,cancellationToken);
            if (projectToDelete == null)
            {
                return NotFound();
            }

            await _projectsService.DeleteProjectAsync(id, cancellationToken);

            return NoContent();
        }
    }
}

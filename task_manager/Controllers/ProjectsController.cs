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

namespace TaskManager.Controllers
{
    /// <summary>
    /// контроллер работы с проектами
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectsService _projectsService;
        /// <summary>
        /// конструктор контроллера ProjectsController
        /// </summary>
        /// <param name="projectsService">сервис проектов</param>
        public ProjectsController(ProjectsService projectsService)
        {
            _projectsService = projectsService;
        }
        /// <summary>
        /// получить список всех проектов
        /// </summary>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Projects>>> GetAllProjectsAsync(CancellationToken cancellationToken)
        {
            var projects = await _projectsService.GetAllProjectsAsync();
            return Ok(projects);
        }
        /// <summary>
        /// получить проект по идентификатору
        /// </summary>
        /// <param name="id">идентификатор проекта</param>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
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
        /// добавить новый проект
        /// </summary>
        /// <param name="newProject">новый проект</param>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Projects>> AddProjectAsync(Projects newProject, CancellationToken cancellationToken)
        {
            await _projectsService.AddProjectAsync(newProject,cancellationToken);
            return CreatedAtAction(nameof(GetProjectByIdAsync), new { id = newProject.IdProject }, newProject);
        }
        /// <summary>
        /// обновление данных проекта
        /// </summary>
        /// <param name="id">идентификатор проекта</param>
        /// <param name="updatedProject">обновленный проект</param>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProjectAsync(int id, Projects updatedProject,CancellationToken cancellationToken)
        {
            if (id != updatedProject.IdProject)
            {
                return BadRequest();
            }

            await _projectsService.UpdateProjectAsync(updatedProject,cancellationToken);

            return NoContent();
        }
        /// <summary>
        /// удаление проекта
        /// </summary>
        /// <param name="id">идентификатор проекта</param>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectAsync(int id,CancellationToken cancellationToken)
        {
            var projectToDelete = await _projectsService.GetProjectByIdAsync(id,cancellationToken);
            if (projectToDelete == null)
            {
                return NotFound();
            }

            await _projectsService.DeleteProjectAsync(id);

            return NoContent();
        }
    }
}

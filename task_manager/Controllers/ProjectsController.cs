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
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectsService _projectsService;

        public ProjectsController(ProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Projects>>> GetAllProjects()
        {
            var projects = await _projectsService.GetAllProjects();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Projects>> GetProjectById(int id)
        {
            var @project = await _projectsService.GetProjectById(id);
            if (@project == null)
            {
                return NotFound();
            }
            return @project;
        }
        [HttpPost]
        public async Task<ActionResult<Projects>> AddProject(Projects newProject)
        {
            await _projectsService.AddProject(newProject);
            return CreatedAtAction(nameof(GetProjectById), new { id = newProject.IdProject }, newProject);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, Projects updatedProject)
        {
            if (id != updatedProject.IdProject)
            {
                return BadRequest();
            }

            await _projectsService.UpdateProject(updatedProject);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var projectToDelete = await _projectsService.GetProjectById(id);
            if (projectToDelete == null)
            {
                return NotFound();
            }

            await _projectsService.DeleteProject(id);

            return NoContent();
        }
    }
}

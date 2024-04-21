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
    public class CompletedTasksController : ControllerBase
    {
        private readonly CompletedTasksService _completedTasksService;

        public CompletedTasksController(CompletedTasksService completedTasksService)
        {
            _completedTasksService = completedTasksService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompletedTasks>>> GetAllComplTasks()
        {
            var compltasks = await _completedTasksService.GetAllComplTasks();
            return Ok(compltasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompletedTasks>> GetComplTasksById(int id)
        {
            var @compltasks = await _completedTasksService.GetComplTasksById(id);
            if (@compltasks == null)
            {
                return NotFound();
            }
            return @compltasks;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComplTask(int id, CompletedTasks updatedComplTask)
        {
            if (id != updatedComplTask.IdCompltask)
            {
                return BadRequest();
            }
            if (updatedComplTask.IdStatus != 4)
            {
                return Content("Статус выполненных задач может быть только: В архиве");
            }
            await _completedTasksService.UpdateComplTask(updatedComplTask);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComplTask(int id)
        {
            var compltaskToDelete = await _completedTasksService.GetComplTasksById(id);
            if (compltaskToDelete == null)
            {
                return NotFound();
            }

            await _completedTasksService.DeleteComplTask(id);

            return NoContent();
        }
    }
}

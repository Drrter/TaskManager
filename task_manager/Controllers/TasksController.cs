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
    public class TasksController : ControllerBase
    {
        private readonly TasksService _tasksService;
        private readonly CompletedTasksService _compltasksService;

        public TasksController(TasksService tasksService, CompletedTasksService completedTasksService)
        {
            _tasksService = tasksService;
            _compltasksService = completedTasksService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tasks>>> GetAllTasks()
        {
            var tasks = await _tasksService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tasks>> GetTasksById(int id)
        {
            var @task = await _tasksService.GetTasksById(id);
            if (@task == null)
            {
                return NotFound();
            }
            return @task;
        }
        [HttpPost]
        public async Task<ActionResult<Tasks>> AddTask(Tasks newTask)
        {
            await _tasksService.AddTask(newTask);
            return CreatedAtAction(nameof(GetTasksById), new { id = newTask.IdTask }, newTask);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, Tasks updatedTask)
        {
            if (id != updatedTask.IdTask)
            {
                return BadRequest();
            }
            if (updatedTask.IdStatus == 4)
            {
                CompletedTasks newComplTask = new CompletedTasks
                {
                    // копирование значений из updatedTask в completedTask
                    IdCompltask = updatedTask.IdTask,
                    CompltaskName = updatedTask.TaskName,
                    DescriptionCompltask = updatedTask.DescriptionTask,
                    IdStatus = 4,
                    CompltaskEnddate = updatedTask.Deadline,
                    IdUser = updatedTask.IdUser,
                    IdUsercreator = updatedTask.IdUsercreator,
                    IdProject = updatedTask.IdProject
                };

                await _compltasksService.AddComplTask(newComplTask);
                await _tasksService.DeleteTask(updatedTask.IdTask);
                return NoContent();
            }

            await _tasksService.UpdateTask(updatedTask);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var taskToDelete = await _tasksService.GetTasksById(id);
            if (taskToDelete == null)
            {
                return NotFound();
            }

            await _tasksService.DeleteTask(id);

            return NoContent();
        }
    }
}

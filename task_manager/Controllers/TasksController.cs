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
    /// контроллер для работы с задачами 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TasksService _tasksService;
        private readonly CompletedTasksService _compltasksService;
        /// <summary>
        /// конструктор контроллера TasksController
        /// </summary>
        /// <param name="tasksService">сервис задач</param>
        /// <param name="completedTasksService">сервис выполненных задач</param>
        public TasksController(TasksService tasksService, CompletedTasksService completedTasksService)
        {
            _tasksService = tasksService;
            _compltasksService = completedTasksService;
        }
        /// <summary>
        /// получить список всех заадч
        /// </summary>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Tasks>>> GetAllTasksAsync(CancellationToken cancellationToken)
        {
            var tasks = await _tasksService.GetAllTasksAsync(cancellationToken);
            return Ok(tasks);
        }
        /// <summary>
        /// получить задачу по идентификатору
        /// </summary>
        /// <param name="id">идентификатор задачи</param>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Tasks>> GetTasksByIdAsync(int id, CancellationToken cancellationToken)
        {
            var @task = await _tasksService.GetTasksByIdAsync(id, cancellationToken);
            if (@task == null)
            {
                return NotFound();
            }
            return @task;
        }
        /// <summary>
        /// добавить новую задачу
        /// </summary>
        /// <param name="newTask">новая задача</param>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Tasks>> AddTaskAsync(Tasks newTask, CancellationToken cancellationToken)
        {
            await _tasksService.AddTaskAsync(newTask, cancellationToken);
            return CreatedAtAction(nameof(GetTasksByIdAsync), new { id = newTask.IdTask }, newTask);
        }
        /// <summary>
        /// обновление существующей задачи
        /// </summary>
        /// <param name="id">идентификатор задачи</param>
        /// <param name="updatedTask">обновленная задача</param>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskAsync(int id, Tasks updatedTask,CancellationToken cancellationToken)
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

                await _compltasksService.AddComplTaskAsync(newComplTask,cancellationToken);
                await _tasksService.DeleteTaskAsync(updatedTask.IdTask,cancellationToken);
                return NoContent();
            }

            await _tasksService.UpdateTaskAsync(updatedTask, cancellationToken);

            return NoContent();
        }
        /// <summary>
        /// удаление задачи
        /// </summary>
        /// <param name="id">идентификатор задачи</param>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskAsync(int id, CancellationToken cancellationToken)
        {
            var taskToDelete = await _tasksService.GetTasksByIdAsync(id, cancellationToken);
            if (taskToDelete == null)
            {
                return NotFound();
            }

            await _tasksService.DeleteTaskAsync(id,cancellationToken);

            return NoContent();
        }
    }
}

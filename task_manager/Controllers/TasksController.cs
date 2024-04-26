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
    /// Контроллер для работы с задачами 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TasksService _tasksService;
        private readonly CompletedTasksService _compltasksService;
        /// <summary>
        /// Конструктор контроллера TasksController
        /// </summary>
        /// <param name="tasksService">Сервис задач</param>
        /// <param name="completedTasksService">Сервис выполненных задач</param>
        public TasksController(TasksService tasksService, CompletedTasksService completedTasksService)
        {
            _tasksService = tasksService;
            _compltasksService = completedTasksService;
        }
        /// <summary>
        /// Получить список всех заадч
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список задач</returns>
        [HttpGet]
        public async Task<ActionResult<List<Tasks>>> GetAllTasksAsync(CancellationToken cancellationToken)
        {
            var tasks = await _tasksService.GetAllTasksAsync(cancellationToken);
            return Ok(tasks);
        }
        /// <summary>
        /// Получить задачу по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Задача по указанному идентификатору</returns>
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
        /// Добавить новую задачу
        /// </summary>
        /// <param name="newTask">Новая задача</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Выполнено</returns>
        [HttpPost]
        public async Task<ActionResult<Tasks>> AddTaskAsync(Tasks newTask, CancellationToken cancellationToken)
        {
            await _tasksService.AddTaskAsync(newTask, cancellationToken);
            return CreatedAtAction(nameof(GetTasksByIdAsync), new { id = newTask.Id }, newTask);
        }
        /// <summary>
        /// Обновление существующей задачи
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        /// <param name="updatedTask">Обновленная задача</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Выполнено</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskAsync(int id, Tasks updatedTask,CancellationToken cancellationToken)
        {
            if (id != updatedTask.Id)
            {
                return BadRequest();
            }
            if (updatedTask.IdStatus == 4)
            {
                CompletedTasks newComplTask = new CompletedTasks
                {
                    // копирование значений из updatedTask в completedTask
                    Id = updatedTask.Id,
                    CompltaskName = updatedTask.TaskName,
                    DescriptionCompltask = updatedTask.DescriptionTask,
                    IdStatus = 4,
                    CompltaskEnddate = updatedTask.Deadline,
                    IdUser = updatedTask.IdUser,
                    IdUsercreator = updatedTask.IdUsercreator,
                    IdProject = updatedTask.IdProject
                };

                await _compltasksService.AddComplTaskAsync(newComplTask,cancellationToken);
                await _tasksService.DeleteTaskAsync(updatedTask.Id,cancellationToken);
                return NoContent();
            }

            await _tasksService.UpdateTaskAsync(updatedTask, cancellationToken);

            return NoContent();
        }
        /// <summary>
        /// Удаление задачи
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Выполнено</returns>
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

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
    /// контроллер для работы с выполненными задачами
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CompletedTasksController : ControllerBase
    {
        private readonly CompletedTasksService _completedTasksService;
        /// <summary>
        /// конструктор контроллера CompletedTasksController
        /// </summary>
        /// <param name="completedTasksService">сервис выполненных задач</param>
        public CompletedTasksController(CompletedTasksService completedTasksService)
        {
            _completedTasksService = completedTasksService;
        }
        /// <summary>
        /// получить список всех выполненных задач
        /// </summary>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<CompletedTasks>>> GetAllComplTasksAsync(CancellationToken cancellationToken)
        {
            var compltasks = await _completedTasksService.GetAllComplTasksAsync(cancellationToken);
            return Ok(compltasks);
        }
        /// <summary>
        /// получить выполненную задачу по идентификатору
        /// </summary>
        /// <param name="id">идентификатор выполненной задачи</param>
        /// <param name="cancellationToken">токен отмены операциии</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CompletedTasks>> GetComplTasksByIdAsync(int id, CancellationToken cancellationToken)
        {
            var @compltasks = await _completedTasksService.GetComplTasksByIdAsync(id,cancellationToken);
            if (@compltasks == null)
            {
                return NotFound();
            }
            return @compltasks;
        }
        /// <summary>
        /// обновление выполенной задачи
        /// </summary>
        /// <param name="id">идентификатор выполненной задачи</param>
        /// <param name="updatedComplTask">обновленная выполненной задача</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComplTaskAsync(int id, CompletedTasks updatedComplTask,CancellationToken cancellationToken)
        {
            if (id != updatedComplTask.IdCompltask)
            {
                return BadRequest();
            }
            if (updatedComplTask.IdStatus != 4)
            {
                return Content("Статус выполненных задач может быть только: В архиве");
            }
            await _completedTasksService.UpdateComplTaskAsync(updatedComplTask,cancellationToken);

            return NoContent();
        }
        /// <summary>
        /// удаление выполненной задачи
        /// </summary>
        /// <param name="id">идентификатор выполненной задачи</param>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComplTaskAsync(int id, CancellationToken cancellationToken)
        {
            var compltaskToDelete = await _completedTasksService.GetComplTasksByIdAsync(id,cancellationToken);
            if (compltaskToDelete == null)
            {
                return NotFound();
            }

            await _completedTasksService.DeleteComplTaskAsync(id,cancellationToken);

            return NoContent();
        }
    }
}

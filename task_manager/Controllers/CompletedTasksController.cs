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
    /// Контроллер для работы с выполненными задачами
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CompletedTasksController : ControllerBase
    {
        private readonly CompletedTasksService _completedTasksService;
        /// <summary>
        /// Конструктор контроллера CompletedTasksController
        /// </summary>
        /// <param name="completedTasksService">Сервис выполненных задач</param>
        public CompletedTasksController(CompletedTasksService completedTasksService)
        {
            _completedTasksService = completedTasksService;
        }
        /// <summary>
        /// Получить список всех выполненных задач
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список выполненных задач</returns>
        [HttpGet]
        public async Task<ActionResult<List<CompletedTasks>>> GetAllComplTasksAsync(CancellationToken cancellationToken)
        {
            var compltasks = await _completedTasksService.GetAllComplTasksAsync(cancellationToken);
            return Ok(compltasks);
        }
        /// <summary>
        /// Получить выполненную задачу по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор выполненной задачи</param>
        /// <param name="cancellationToken">Токен отмены операциии</param>
        /// <returns>Выполненная задача по указанному идентификатору</returns>
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
        /// Обновление выполенной задачи
        /// </summary>
        /// <param name="id">Идентификатор выполненной задачи</param>
        /// <param name="updatedComplTask">Обновленная выполненной задача</param>
        /// <param name="cancellationToken">Токен отмены операциии</param>
        /// <returns>Выполнено</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComplTaskAsync(int id, CompletedTasks updatedComplTask,CancellationToken cancellationToken)
        {
            if (id != updatedComplTask.Id)
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
        /// Удаление выполненной задачи
        /// </summary>
        /// <param name="id">Идентификатор выполненной задачи</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Выполнено</returns>
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

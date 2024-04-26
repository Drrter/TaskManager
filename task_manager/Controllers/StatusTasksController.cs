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
    /// Контроллер работы со статусами задач
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StatusTasksController : ControllerBase
    {
        private readonly StatusService _statusService;
        /// <summary>
        /// Конструктор контроллера StatusTasksController
        /// </summary>
        /// <param name="statusService">Сервис статусов</param>
        public StatusTasksController(StatusService statusService)
        {
            _statusService = statusService;
        }
        /// <summary>
        /// Получить список всех статусов
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список статусов</returns>
        [HttpGet]
        public async Task<ActionResult<List<StatusTask>>> GetAllStatusAsync(CancellationToken cancellationToken)
        {
            var status = await _statusService.GetAllStatusAsync(cancellationToken);
            return Ok(status);
        }
        /// <summary>
        /// Получить статус по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор статуса</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Статус по указанному идентификатору</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusTask>> GetStatusByIdAsync(int id, CancellationToken cancellationToken)
        {
            var @status = await _statusService.GetStatusByIdAsync(id,cancellationToken);
            if (@status == null)
            {
                return NotFound();
            }
            return @status;
        }
    }
}

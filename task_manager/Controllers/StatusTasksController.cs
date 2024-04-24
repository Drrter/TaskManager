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
    /// контроллер работы со статусами задач
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StatusTasksController : ControllerBase
    {
        private readonly StatusService _statusService;
        /// <summary>
        /// конструктор контроллера StatusTasksController
        /// </summary>
        /// <param name="statusService">сервис статусов</param>
        public StatusTasksController(StatusService statusService)
        {
            _statusService = statusService;
        }
        /// <summary>
        /// получить список всех статусов
        /// </summary>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<StatusTask>>> GetAllStatusAsync(CancellationToken cancellationToken)
        {
            var status = await _statusService.GetAllStatusAsync(cancellationToken);
            return Ok(status);
        }
        /// <summary>
        /// получить статус по идентификатору
        /// </summary>
        /// <param name="id">идентификатор статуса</param>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
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

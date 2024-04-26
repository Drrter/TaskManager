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
    /// Контроллер работы с приоритетами задач
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PrioritiesTaskController : ControllerBase
    {
        private readonly PrioritiesService _prioritiesServices;
        /// <summary>
        /// Конструктор контроллера PrioritiesTaskController
        /// </summary>
        /// <param name="prioritiesServices">Сервис приоритетов</param>
        public PrioritiesTaskController(PrioritiesService prioritiesServices)
        {
            _prioritiesServices = prioritiesServices;
        }
        /// <summary>
        /// Получить список всех приоритетов
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список приоритетов</returns>
        [HttpGet]
        public async Task<ActionResult<List<PrioritiesTask>>> GetAllPriorityAsync(CancellationToken cancellationToken)
        {
            var priority = await _prioritiesServices.GetAllPriorityAsync(cancellationToken);
            return Ok(priority);
        }
        /// <summary>
        /// Получить приоритет по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор приоритета</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Приоритет по указанному идентификатору</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PrioritiesTask>> GetPriorityByIdAsync(int id,CancellationToken cancellationToken)
        {
            var @priority = await _prioritiesServices.GetPriorityByIdAsync(id,cancellationToken);
            if (@priority == null)
            {
                return NotFound();
            }
            return @priority;
        }
    }
}

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
    /// контроллер работы с приоритетами задач
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PrioritiesTaskController : ControllerBase
    {
        private readonly PrioritiesServices _prioritiesServices;
        /// <summary>
        /// конструктор контроллера PrioritiesTaskController
        /// </summary>
        /// <param name="prioritiesServices"></param>
        public PrioritiesTaskController(PrioritiesServices prioritiesServices)
        {
            _prioritiesServices = prioritiesServices;
        }
        /// <summary>
        /// получить список всех приоритетов
        /// </summary>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<PrioritiesTask>>> GetAllPriorityAsync(CancellationToken cancellationToken)
        {
            var priority = await _prioritiesServices.GetAllPriorityAsync(cancellationToken);
            return Ok(priority);
        }
        /// <summary>
        /// получить приоритет по идентификатору
        /// </summary>
        /// <param name="id">идентификатор приоритета</param>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
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

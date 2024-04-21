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
    public class PrioritiesTaskController : ControllerBase
    {
        private readonly PrioritiesServices _prioritiesServices;

        public PrioritiesTaskController(PrioritiesServices prioritiesServices)
        {
            _prioritiesServices = prioritiesServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<PrioritiesTask>>> GetAllPriority()
        {
            var priority = await _prioritiesServices.GetAllPriority();
            return Ok(priority);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PrioritiesTask>> GetPriorityById(int id)
        {
            var @priority = await _prioritiesServices.GetPriorityById(id);
            if (@priority == null)
            {
                return NotFound();
            }
            return @priority;
        }
    }
}

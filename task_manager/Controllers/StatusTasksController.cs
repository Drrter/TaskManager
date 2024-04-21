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
    public class StatusTasksController : ControllerBase
    {
        private readonly StatusService _statusService;

        public StatusTasksController(StatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StatusTask>>> GetAllStatus()
        {
            var status = await _statusService.GetAllStatus();
            return Ok(status);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatusTask>> GetStatusById(int id)
        {
            var @status = await _statusService.GetStatusById(id);
            if (@status == null)
            {
                return NotFound();
            }
            return @status;
        }
    }
}

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
    public class TeamsController : ControllerBase
    {
        private readonly TeamsService _teamsService;

        public TeamsController(TeamsService teamsService)
        {
            _teamsService = teamsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Teams>>> GetAllTeams()
        {
            var teams = await _teamsService.GetAllTeams();
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Teams>> GetTeamById(int id)
        {
            var @team = await _teamsService.GetTeamById(id);
            if (@team == null)
            {
                return NotFound();
            }
            return @team;
        }
        [HttpPost]
        public async Task<ActionResult<Teams>> AddTeam(Teams newTeam)
        {
            await _teamsService.AddTeam(newTeam);
            return CreatedAtAction(nameof(GetTeamById), new { id = newTeam.IdTeam }, newTeam);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(int id, Teams updatedTeam)
        {
            if (id != updatedTeam.IdTeam)
            {
                return BadRequest();
            }

            await _teamsService.UpdateTeam(updatedTeam);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var userToDelete = await _teamsService.GetTeamById(id);
            if (userToDelete == null)
            {
                return NotFound();
            }

            await _teamsService.DeleteTeam(id);

            return NoContent();
        }
    }
}

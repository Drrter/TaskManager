using System;
using System.Collections.Generic;
using System.Data;
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
    public class TeamMembersController : ControllerBase
    {
        private readonly TeamMembersService _teamMembersService;

        public TeamMembersController(TeamMembersService teamMembersService)
        {
            _teamMembersService = teamMembersService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamMembers>>> GetAllTeamMembers()
        {
            var teamMembers = await _teamMembersService.GetAllTeamMembers();
            return Ok(teamMembers);
        }

        [HttpGet("GetByIdTeam/{idTeam}")]
        public async Task<ActionResult<TeamMembers>> GetByTeamId(int idTeam)
        {
            var teamMember = await _teamMembersService.GetTeamMemberByIdTeam(idTeam);
            if (teamMember == null)
            {
                return NotFound();
            }
            return Ok(teamMember);
        }

        [HttpGet("GetByIdUser/{id}")]
        public async Task<ActionResult<TeamMembers>> GetByUserId(int id)
        {
            var teamMember = await _teamMembersService.GetTeamMemberByIdUser(id);
            if (teamMember == null)
            {
                return NotFound();
            }
            return Ok(teamMember);
        }

        [HttpDelete("{idTeam}/{idUser}")]
        public async Task<ActionResult> Delete(int idTeam, int idUser)
        {
            try
            {
                await _teamMembersService.DeleteTeamMember(idTeam, idUser);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<TeamMembers>> AddMember(TeamMembers newMember)
        {
            await _teamMembersService.AddMember(newMember);
            return CreatedAtAction(nameof(GetAllTeamMembers), new { id = new { newMember.IdTeam, newMember.IdUser } }, newMember);
        }

    }
}

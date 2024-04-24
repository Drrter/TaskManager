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
    /// контроллер для работы с командами
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly TeamsService _teamsService;
        /// <summary>
        /// конструктор контроллера TeamsController
        /// </summary>
        /// <param name="teamsService">сервис команд</param>
        public TeamsController(TeamsService teamsService)
        {
            _teamsService = teamsService;
        }
        /// <summary>
        /// получить список всех команд
        /// </summary>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Teams>>> GetAllTeamsAsync(CancellationToken cancellationToken)
        {
            var teams = await _teamsService.GetAllTeamsAsync(cancellationToken);
            return Ok(teams);
        }
        /// <summary>
        /// получить команду по идентификатору
        /// </summary>
        /// <param name="id">идентификатор команды</param>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Teams>> GetTeamByIdAsync(int id, CancellationToken cancellationToken)
        {
            var @team = await _teamsService.GetTeamByIdAsync(id, cancellationToken);
            if (@team == null)
            {
                return NotFound();
            }
            return @team;
        }
        /// <summary>
        /// добавить новую команду
        /// </summary>
        /// <param name="newTeam">новая команда</param>
        /// <param name="cancellationToken">токен отмаены операции</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Teams>> AddTeamAsync(Teams newTeam, CancellationToken cancellationToken)
        {
            await _teamsService.AddTeamAsync(newTeam, cancellationToken);
            return CreatedAtAction(nameof(GetTeamByIdAsync), new { id = newTeam.IdTeam }, newTeam);
        }
        /// <summary>
        /// обновить существующую команду
        /// </summary>
        /// <param name="id">идентификатор команды</param>
        /// <param name="updatedTeam">обновленная команда</param>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeamAsync(int id, Teams updatedTeam,CancellationToken cancellationToken)
        {
            if (id != updatedTeam.IdTeam)
            {
                return BadRequest();
            }

            await _teamsService.UpdateTeamAsync(updatedTeam, cancellationToken);

            return NoContent();
        }
        /// <summary>
        /// удаление команды
        /// </summary>
        /// <param name="id">идентификатор команды</param>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamAsync(int id, CancellationToken cancellationToken)
        {
            var userToDelete = await _teamsService.GetTeamByIdAsync(id, cancellationToken);
            if (userToDelete == null)
            {
                return NotFound();
            }

            await _teamsService.DeleteTeamAsync(id, cancellationToken);

            return NoContent();
        }
    }
}

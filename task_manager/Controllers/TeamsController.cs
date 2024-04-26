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
    /// Контроллер для работы с командами
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly TeamsService _teamsService;
        /// <summary>
        /// Конструктор контроллера TeamsController
        /// </summary>
        /// <param name="teamsService">Сервис команд</param>
        public TeamsController(TeamsService teamsService)
        {
            _teamsService = teamsService;
        }
        /// <summary>
        /// Получить список всех команд
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список команд</returns>
        [HttpGet]
        public async Task<ActionResult<List<Teams>>> GetAllTeamsAsync(CancellationToken cancellationToken)
        {
            var teams = await _teamsService.GetAllTeamsAsync(cancellationToken);
            return Ok(teams);
        }
        /// <summary>
        /// Получить команду по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор команды</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Команда по указанному идентификатору</returns>
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
        /// Добавить новую команду
        /// </summary>
        /// <param name="newTeam">Новая команда</param>
        /// <param name="cancellationToken">Токен отмаены операции</param>
        /// <returns>Выполнено</returns>
        [HttpPost]
        public async Task<ActionResult<Teams>> AddTeamAsync(Teams newTeam, CancellationToken cancellationToken)
        {
            await _teamsService.AddTeamAsync(newTeam, cancellationToken);
            return CreatedAtAction(nameof(GetTeamByIdAsync), new { id = newTeam.Id }, newTeam);
        }
        /// <summary>
        /// Обновить существующую команду
        /// </summary>
        /// <param name="id">Идентификатор команды</param>
        /// <param name="updatedTeam">Обновленная команда</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Выполнено</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeamAsync(int id, Teams updatedTeam,CancellationToken cancellationToken)
        {
            if (id != updatedTeam.Id)
            {
                return BadRequest();
            }

            await _teamsService.UpdateTeamAsync(updatedTeam, cancellationToken);

            return NoContent();
        }
        /// <summary>
        /// Удаление команды
        /// </summary>
        /// <param name="id">Идентификатор команды</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Выполнено</returns>
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

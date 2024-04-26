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
using TaskManager.Services;

namespace TaskManager.Controllers
{
    /// <summary>
    /// Контроллер для работы с участниками команд
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMembersController : ControllerBase
    {
        private readonly TeamMembersService _teamMembersService;
        /// <summary>
        /// Конструктор контроллера TeamMembersController
        /// </summary>
        /// <param name="teamMembersService">Сервис участников</param>
        public TeamMembersController(TeamMembersService teamMembersService)
        {
            _teamMembersService = teamMembersService;
        }
        /// <summary>
        /// Получить список всех участников команд
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список участников команд</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamMembers>>> GetAllTeamMembersAsync(CancellationToken cancellationToken)
        {
            var teamMembers = await _teamMembersService.GetAllTeamMembersAsync(cancellationToken);
            return Ok(teamMembers);
        }
        /// <summary>
        /// Получить участников по идентификатору команды
        /// </summary>
        /// <param name="idTeam">Идентификатор команды</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Участник команды по указанному идентификатору</returns>
        [HttpGet("GetByIdTeam/{idTeam}")]
        public async Task<ActionResult<TeamMembers>> GetByTeamIdAsync(int idTeam, CancellationToken cancellationToken)
        {
            var teamMember = await _teamMembersService.GetTeamMemberByIdTeamAsync(idTeam, cancellationToken);
            if (teamMember == null)
            {
                return NotFound();
            }
            return Ok(teamMember);
        }
        /// <summary>
        /// Получить участников по идентификатору пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Участник команды по указанному идентификатору</returns>
        [HttpGet("GetByIdUser/{id}")]
        public async Task<ActionResult<TeamMembers>> GetByUserIdAsync(int id, CancellationToken cancellationToken)
        {
            var teamMember = await _teamMembersService.GetTeamMemberByIdUserAsync(id, cancellationToken);
            if (teamMember == null)
            {
                return NotFound();
            }
            return Ok(teamMember);
        }
        /// <summary>
        /// Удалить участников команды
        /// </summary>
        /// <param name="idTeam">Идентификатор команды</param>
        /// <param name="idUser">Идентификатор пользователя</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Выполнено</returns>
        [HttpDelete("{idTeam}/{idUser}")]
        public async Task<ActionResult> DeleteMemberAsync(int idTeam, int idUser,CancellationToken cancellationToken)
        {
            try
            {
                await _teamMembersService.DeleteTeamMemberAsync(idTeam, idUser,cancellationToken);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Добавление участников в команды
        /// </summary>
        /// <param name="newMember">Новый участник команды</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Выполнено</returns>
        [HttpPost]
        public async Task<ActionResult<TeamMembers>> AddMemberAsync(TeamMembers newMember,CancellationToken cancellationToken)
        {
            await _teamMembersService.AddMemberAsync(newMember, cancellationToken);
            return CreatedAtAction(nameof(GetAllTeamMembersAsync), new { id = new { newMember.IdTeam, newMember.IdUser } }, newMember);
        }

    }
}

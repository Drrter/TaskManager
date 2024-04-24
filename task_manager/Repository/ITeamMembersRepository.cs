using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// интерфейс с методами управления участниками команд
    /// </summary>
    public interface ITeamMembersRepository
    {
        /// <summary>
        /// получает список всех участников
        /// </summary>
        /// <returns>список участников</returns>
        Task<IEnumerable<TeamMembers>> GetAllTeamMembersAsync();
        /// <summary>
        /// получает список участников по идентификатору команды
        /// </summary>
        /// <param name="idTeam">идентификатор команды</param>
        /// <returns>команда и участник с указанным идентификатором</returns>
        Task<TeamMembers> GetTeamMemberByIdTeamAsync(int idTeam);
        /// <summary>
        /// получает список участников по идентификатору пользователя
        /// </summary>
        /// <param name="idUser">идентификатор пользователя</param>
        /// <returns>команда и участник с указанным идентификатором</returns>
        Task<TeamMembers> GetTeamMemberByIdUserAsync(int idUser);
        /// <summary>
        /// удаление связи пользователя с командой
        /// </summary>
        /// <param name="idTeam">идентификатор команды</param>
        /// <param name="idUser">идентификатор пользователя</param>
        /// <returns>выполнено</returns>
        Task DeleteTeamMemberAsync(int idTeam, int idUser);
        /// <summary>
        /// добавление новой записи 
        /// </summary>
        /// <param name="newMember">новый участник команды</param>
        /// <returns>выполнено</returns>
        Task AddMemberAsync(TeamMembers newMember);
    }
    /// <summary>
    /// реализация репозитория ITeamMembersRepository
    /// </summary>
    public class TeamMembersRepository : ITeamMembersRepository
    {
        private readonly TaskContext _context;
        /// <summary>
        /// передает TaskContext в конструктор
        /// </summary>
        /// <param name="context">контекст базы данных</param>
        public TeamMembersRepository(TaskContext context)
        {
            _context = context;
        }
        /// <summary>
        /// получает список всех участников
        /// </summary>
        /// <returns>список участников</returns>
        public async Task<IEnumerable<TeamMembers>> GetAllTeamMembersAsync()
        {
            return await _context.TeamMembers.ToListAsync();
        }
        /// <summary>
        /// получает список участников по идентификатору команды
        /// </summary>
        /// <param name="idTeam">идентификатор команды</param>
        /// <returns>команда и участник с указанным идентификатором</returns>
        public async Task<TeamMembers> GetTeamMemberByIdTeamAsync(int idTeam)
        {
            return await _context.TeamMembers.FirstOrDefaultAsync(tm => tm.IdTeam == idTeam);
        }
        /// <summary>
        /// получает список участников по идентификатору пользователя
        /// </summary>
        /// <param name="idUser">идентификатор пользователя</param>
        /// <returns>команда и участник с указанным идентификатором</returns>
        public async Task<TeamMembers> GetTeamMemberByIdUserAsync(int idUser)
        {
            return await _context.TeamMembers.FirstOrDefaultAsync(tm => tm.IdUser == idUser);
        }
        /// <summary>
        /// удаление связи пользователя с командой
        /// </summary>
        /// <param name="idTeam">идентификатор команды</param>
        /// <param name="idUser">идентификатор пользователя</param>
        /// <returns>выполнено</returns>
        public async Task DeleteTeamMemberAsync(int idTeam, int idUser)
        {
            var teamMember = await _context.TeamMembers.FirstOrDefaultAsync(tm => tm.IdTeam == idTeam && tm.IdUser == idUser);
            if (teamMember != null)
            {
                _context.TeamMembers.Remove(teamMember);
                await _context.SaveChangesAsync();
            }
        }
        /// <summary>
        /// добавление новой записи 
        /// </summary>
        /// <param name="newMember">новый участник команды</param>
        /// <returns>выполнено</returns>
        public async Task AddMemberAsync(TeamMembers newMember)
        {
            _context.TeamMembers.Add(newMember);
            await _context.SaveChangesAsync();
        }

    }
    /// <summary>
    /// сервис для управления участниками
    /// </summary>
    public class TeamMembersService
    {
        /// <summary>
        /// зависимость типа ITeamMembersRepository
        /// </summary>
        private readonly ITeamMembersRepository _teamMembersRepository;
        public TeamMembersService(ITeamMembersRepository teamMembersRepository)
        {
            _teamMembersRepository = teamMembersRepository;
        }
        /// <summary>
        /// получает список всех участников
        /// </summary>
        /// <returns>список участников</returns>
        public async Task<IEnumerable<TeamMembers>> GetAllTeamMembersAsync(CancellationToken cancellationToken)
        {
            return await _teamMembersRepository.GetAllTeamMembersAsync();
        }
        /// <summary>
        /// получает список участников по идентификатору команды
        /// </summary>
        /// <param name="idTeam">идентификатор команды</param>
        /// <returns>команда и участник с указанным идентификатором</returns>
        public async Task<TeamMembers> GetTeamMemberByIdTeamAsync(int idTeam, CancellationToken cancellationToken)
        {
            return await _teamMembersRepository.GetTeamMemberByIdTeamAsync(idTeam);
        }
        /// <summary>
        /// получает список участников по идентификатору пользователя
        /// </summary>
        /// <param name="idUser">идентификатор пользователя</param>
        /// <returns>команда и участник с указанным идентификатором</returns>
        public async Task<TeamMembers> GetTeamMemberByIdUserAsync(int idUser, CancellationToken cancellationToken)
        {
            return await _teamMembersRepository.GetTeamMemberByIdUserAsync(idUser);
        }
        /// <summary>
        /// удаление связи пользователя с командой
        /// </summary>
        /// <param name="idTeam">идентификатор команды</param>
        /// <param name="idUser">идентификатор пользователя</param>
        /// <returns>выполнено</returns>
        public async Task DeleteTeamMemberAsync(int idTeam, int idUser, CancellationToken cancellationToken)
        {
            await _teamMembersRepository.DeleteTeamMemberAsync(idTeam, idUser);
        }
        /// <summary>
        /// добавление новой записи 
        /// </summary>
        /// <param name="newMember">новый участник команды</param>
        /// <returns>выполнено</returns>
        public async Task AddMemberAsync(TeamMembers newMember, CancellationToken cancellationToken)
        {
            await _teamMembersRepository.AddMemberAsync(newMember);
        }

    }
}

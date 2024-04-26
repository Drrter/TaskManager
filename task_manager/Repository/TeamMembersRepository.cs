using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// Реализация репозитория ITeamMembersRepository
    /// </summary>
    public class TeamMembersRepository : ITeamMembersRepository
    {
        private readonly TaskContext _context;
        /// <summary>
        /// Передает TaskContext в конструктор
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public TeamMembersRepository(TaskContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Получает список всех участников
        /// </summary>
        /// <returns>Список участников</returns>
        public async Task<IEnumerable<TeamMembers>> GetAllTeamMembersAsync(CancellationToken cancellationToken)
        {
            return await _context.TeamMembers.ToListAsync(cancellationToken);
        }
        /// <summary>
        /// Получает список участников по идентификатору команды
        /// </summary>
        /// <param name="idTeam">Идентификатор команды</param>
        /// <returns>Команда и участник с указанным идентификатором</returns>
        public async Task<TeamMembers> GetTeamMemberByIdTeamAsync(int idTeam, CancellationToken cancellationToken)
        {
            return await _context.TeamMembers.FirstOrDefaultAsync(tm => tm.IdTeam == idTeam,cancellationToken);
        }
        /// <summary>
        /// Получает список участников по идентификатору пользователя
        /// </summary>
        /// <param name="idUser">Идентификатор пользователя</param>
        /// <returns>Команда и участник с указанным идентификатором</returns>
        public async Task<TeamMembers> GetTeamMemberByIdUserAsync(int idUser, CancellationToken cancellationToken)
        {
            return await _context.TeamMembers.FirstOrDefaultAsync(tm => tm.IdUser == idUser, cancellationToken);
        }
        /// <summary>
        /// Удаление связи пользователя с командой
        /// </summary>
        /// <param name="idTeam">Идентификатор команды</param>
        /// <param name="idUser">Идентификатор пользователя</param>
        /// <returns>Выполнено</returns>
        public async Task DeleteTeamMemberAsync(int idTeam, int idUser,CancellationToken cancellationToken)
        {
            var teamMember = await _context.TeamMembers.FirstOrDefaultAsync(tm => tm.IdTeam == idTeam && tm.IdUser == idUser, cancellationToken);
            if (teamMember != null)
            {
                _context.TeamMembers.Remove(teamMember);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
        /// <summary>
        /// Добавление новой записи 
        /// </summary>
        /// <param name="newMember">Новый участник команды</param>
        /// <returns>Выполнено</returns>
        public async Task AddMemberAsync(TeamMembers newMember,CancellationToken cancellationToken)
        {
            _context.TeamMembers.Add(newMember);
            await _context.SaveChangesAsync(cancellationToken);
        }

    }

}

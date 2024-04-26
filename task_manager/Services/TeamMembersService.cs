using TaskManager.DB;
using TaskManager.Repository;

namespace TaskManager.Services
{
    /// <summary>
    /// Сервис для управления участниками
    /// </summary>
    public class TeamMembersService
    {
        /// <summary>
        /// Зависимость типа ITeamMembersRepository
        /// </summary>
        private readonly ITeamMembersRepository _teamMembersRepository;
        public TeamMembersService(ITeamMembersRepository teamMembersRepository)
        {
            _teamMembersRepository = teamMembersRepository;
        }
        /// <summary>
        /// Получает список всех участников
        /// </summary>
        /// <returns>Список участников</returns>
        public async Task<IEnumerable<TeamMembers>> GetAllTeamMembersAsync(CancellationToken cancellationToken)
        {
            return await _teamMembersRepository.GetAllTeamMembersAsync(cancellationToken);
        }
        /// <summary>
        /// Получает список участников по идентификатору команды
        /// </summary>
        /// <param name="idTeam">Идентификатор команды</param>
        /// <returns>Команда и участник с указанным идентификатором</returns>
        public async Task<TeamMembers> GetTeamMemberByIdTeamAsync(int idTeam, CancellationToken cancellationToken)
        {
            return await _teamMembersRepository.GetTeamMemberByIdTeamAsync(idTeam, cancellationToken);
        }
        /// <summary>
        /// Получает список участников по идентификатору пользователя
        /// </summary>
        /// <param name="idUser">Идентификатор пользователя</param>
        /// <returns>Команда и участник с указанным идентификатором</returns>
        public async Task<TeamMembers> GetTeamMemberByIdUserAsync(int idUser, CancellationToken cancellationToken)
        {
            return await _teamMembersRepository.GetTeamMemberByIdUserAsync(idUser, cancellationToken);
        }
        /// <summary>
        /// Удаление связи пользователя с командой
        /// </summary>
        /// <param name="idTeam">Идентификатор команды</param>
        /// <param name="idUser">Идентификатор пользователя</param>
        /// <returns>Выполнено</returns>
        public async Task DeleteTeamMemberAsync(int idTeam, int idUser, CancellationToken cancellationToken)
        {
            await _teamMembersRepository.DeleteTeamMemberAsync(idTeam, idUser,cancellationToken);
        }
        /// <summary>
        /// Добавление новой записи 
        /// </summary>
        /// <param name="newMember">Новый участник команды</param>
        /// <returns>Выполнено</returns>
        public async Task AddMemberAsync(TeamMembers newMember, CancellationToken cancellationToken)
        {
            await _teamMembersRepository.AddMemberAsync(newMember, cancellationToken);
        }

    }
}

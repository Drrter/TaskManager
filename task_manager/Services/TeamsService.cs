using TaskManager.DB;
using TaskManager.Repository;

namespace TaskManager.Services
{
    /// <summary>
    /// Сервис для управления командами
    /// </summary>
    public class TeamsService
    {
        /// <summary>
        /// Зависимость типа ITeamsRepository
        /// </summary>
        private readonly ITeamsRepository _teamsRepository;
        public TeamsService(ITeamsRepository teamRepository)
        {
            _teamsRepository = teamRepository;
        }
        /// <summary>
        /// Получает список всех команд
        /// </summary>
        /// <returns>Список команд</returns>
        public async Task<List<Teams>> GetAllTeamsAsync(CancellationToken cancellationToken)
        {
            return await _teamsRepository.GetAllTeamsAsync(cancellationToken);
        }
        /// <summary>
        /// Получает команду по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор команды</param>
        /// <returns>Команда с указанным идентификатором</returns>
        public async Task<Teams> GetTeamByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _teamsRepository.GetTeamByIdAsync(id,cancellationToken);
        }
        /// <summary>
        /// Добавление новой команды 
        /// </summary>
        /// <param name="newTeam">Новая команда</param>
        /// <returns>Выполнено</returns>
        public async Task AddTeamAsync(Teams newTeam, CancellationToken cancellationToken)
        {
            await _teamsRepository.AddTeamAsync(newTeam, cancellationToken);
        }
        /// <summary>
        /// Изменение существующей команды
        /// </summary>
        /// <param name="id">Идентификатор команды</param>
        /// <param name="updatedTeam">Обновленная команда</param>
        /// <returns>Выполнено</returns>
        public async Task UpdateTeamAsync(Teams updatedTeam, CancellationToken cancellationToken)
        {
            await _teamsRepository.UpdateTeamAsync(updatedTeam.Id, updatedTeam, cancellationToken);
        }
        /// <summary>
        /// Удаление команды
        /// </summary>
        /// <param name="id">Идентификатор команды</param>
        /// <returns>Выполнено</returns>
        public async Task DeleteTeamAsync(int id, CancellationToken cancellationToken)
        {
            await _teamsRepository.DeleteTeamAsync(id, cancellationToken);
        }
    }
}

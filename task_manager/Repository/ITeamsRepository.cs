using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// интерфейс с методами управления командами
    /// </summary>
    public interface ITeamsRepository
    {
        /// <summary>
        /// получает список всех команд
        /// </summary>
        /// <returns>список команд</returns>
        Task<List<Teams>> GetAllTeamsAsync();
        /// <summary>
        /// получает команду по идентификатору
        /// </summary>
        /// <param name="id">идентификатор команды</param>
        /// <returns>команда с указанным идентификатором</returns>
        Task<Teams> GetTeamByIdAsync(int id);
        /// <summary>
        /// добавление новой команды 
        /// </summary>
        /// <param name="newTeam">новая команда</param>
        /// <returns>выполнено</returns>
        Task AddTeamAsync(Teams newTeam);
        /// <summary>
        /// изменение существующей команды
        /// </summary>
        /// <param name="id">идентификатор команды</param>
        /// <param name="updatedTeam">обновленная команда</param>
        /// <returns>выполнено</returns>
        Task UpdateTeamAsync(int id, Teams updatedTeam);
        /// <summary>
        /// удаление команды
        /// </summary>
        /// <param name="id">идентификатор команды</param>
        /// <returns>выполнено</returns>
        Task DeleteTeamAsync(int id);
    }
    /// <summary>
    /// реализация репозитория ITeamsRepository
    /// </summary>
    public class TeamsRepository:ITeamsRepository
    {
        private readonly TaskContext _context;
        /// <summary>
        /// передает taskcontext в конструкторе
        /// </summary>
        /// <param name="context">контекст базы данных</param>
        public TeamsRepository(TaskContext context)
        {
            _context = context;
        }
        /// <summary>
        /// получает список всех команд
        /// </summary>
        /// <returns>список команд</returns>
        public async Task<List<Teams>> GetAllTeamsAsync()
        {
            return await _context.Teams.ToListAsync();
        }
        /// <summary>
        /// получает команду по идентификатору
        /// </summary>
        /// <param name="id">идентификатор команды</param>
        /// <returns>команда с указанным идентификатором</returns>
        public async Task<Teams> GetTeamByIdAsync(int id)
        {
            return await _context.Teams.FindAsync(id);
        }
        /// <summary>
        /// добавление новой команды 
        /// </summary>
        /// <param name="newTeam">новая команда</param>
        /// <returns>выполнено</returns>
        public async Task AddTeamAsync(Teams newTeam)
        {
            _context.Teams.Add(newTeam);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// изменение существующей команды
        /// </summary>
        /// <param name="id">идентификатор команды</param>
        /// <param name="updatedTeam">обновленная команда</param>
        /// <returns>выполнено</returns>
        public async Task UpdateTeamAsync(int id, Teams updatedTeam)
        {
            _context.Entry(updatedTeam).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// удаление команды
        /// </summary>
        /// <param name="id">идентификатор команды</param>
        /// <returns>выполнено</returns>
        public async Task DeleteTeamAsync(int id)
        {
            var teamToDelete = await _context.Teams.FindAsync(id);
            if (teamToDelete != null)
            {
                _context.Teams.Remove(teamToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
    /// <summary>
    /// сервис для управления командами
    /// </summary>
    public class TeamsService
    {
        private readonly ITeamsRepository _teamsRepository;
        /// <summary>
        /// зависимость типа ITeamsRepository
        /// </summary>
        /// <param name="teamRepository"></param>
        public TeamsService(ITeamsRepository teamRepository)
        {
            _teamsRepository = teamRepository;
        }
        /// <summary>
        /// получает список всех команд
        /// </summary>
        /// <returns>список команд</returns>
        public async Task<List<Teams>> GetAllTeamsAsync(CancellationToken cancellationToken)
        {
            return await _teamsRepository.GetAllTeamsAsync();
        }
        /// <summary>
        /// получает команду по идентификатору
        /// </summary>
        /// <param name="id">идентификатор команды</param>
        /// <returns>команда с указанным идентификатором</returns>
        public async Task<Teams> GetTeamByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _teamsRepository.GetTeamByIdAsync(id);
        }
        /// <summary>
        /// добавление новой команды 
        /// </summary>
        /// <param name="newTeam">новая команда</param>
        /// <returns>выполнено</returns>
        public async Task AddTeamAsync(Teams newTeam, CancellationToken cancellationToken)
        {
            await _teamsRepository.AddTeamAsync(newTeam);
        }
        /// <summary>
        /// изменение существующей команды
        /// </summary>
        /// <param name="id">идентификатор команды</param>
        /// <param name="updatedTeam">обновленная команда</param>
        /// <returns>выполнено</returns>
        public async Task UpdateTeamAsync(Teams updatedTeam, CancellationToken cancellationToken)
        {
            await _teamsRepository.UpdateTeamAsync(updatedTeam.IdTeam, updatedTeam);
        }
        /// <summary>
        /// удаление команды
        /// </summary>
        /// <param name="id">идентификатор команды</param>
        /// <returns>выполнено</returns>
        public async Task DeleteTeamAsync(int id, CancellationToken cancellationToken)
        {
            await _teamsRepository.DeleteTeamAsync(id);
        }
    }
}

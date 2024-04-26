using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// Реализация репозитория ITeamsRepository
    /// </summary>
    public class TeamsRepository : ITeamsRepository
    {
        private readonly TaskContext _context;
        /// <summary>
        /// Передает taskcontext в конструкторе
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public TeamsRepository(TaskContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Получает список всех команд
        /// </summary>
        /// <returns>Список команд</returns>
        public async Task<List<Teams>> GetAllTeamsAsync(CancellationToken cancellationToken)
        {
            return await _context.Teams.ToListAsync(cancellationToken);
        }
        /// <summary>
        /// Получает команду по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор команды</param>
        /// <returns>Команда с указанным идентификатором</returns>
        public async Task<Teams> GetTeamByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Teams.FindAsync(id,cancellationToken);
        }
        /// <summary>
        /// Добавление новой команды 
        /// </summary>
        /// <param name="newTeam">Новая команда</param>
        /// <returns>Выполнено</returns>
        public async Task AddTeamAsync(Teams newTeam, CancellationToken cancellationToken)
        {
            _context.Teams.Add(newTeam);
            await _context.SaveChangesAsync(cancellationToken);
        }
        /// <summary>
        /// Изменение существующей команды
        /// </summary>
        /// <param name="id">Идентификатор команды</param>
        /// <param name="updatedTeam">Обновленная команда</param>
        /// <returns>Выполнено</returns>
        public async Task UpdateTeamAsync(int id, Teams updatedTeam,CancellationToken cancellationToken)
        {
            _context.Entry(updatedTeam).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }
        /// <summary>
        /// Удаление команды
        /// </summary>
        /// <param name="id">Идентификатор команды</param>
        /// <returns>Выполнено</returns>
        public async Task DeleteTeamAsync(int id, CancellationToken cancellationToken)
        {
            var teamToDelete = await _context.Teams.FindAsync(id);
            if (teamToDelete != null)
            {
                _context.Teams.Remove(teamToDelete);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// Интерфейс с методами управления командами
    /// </summary>
    public interface ITeamsRepository
    {
        /// <summary>
        /// Получает список всех команд
        /// </summary>
        /// <returns>Список команд</returns>
        Task<List<Teams>> GetAllTeamsAsync(CancellationToken cancellationToken);
        /// <summary>
        /// Получает команду по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор команды</param>
        /// <returns>Команда с указанным идентификатором</returns>
        Task<Teams> GetTeamByIdAsync(int id, CancellationToken cancellationToken);
        /// <summary>
        /// Добавление новой команды 
        /// </summary>
        /// <param name="newTeam">Новая команда</param>
        /// <returns>Выполнено</returns>
        Task AddTeamAsync(Teams newTeam, CancellationToken cancellationToken);
        /// <summary>
        /// Изменение существующей команды
        /// </summary>
        /// <param name="id">Идентификатор команды</param>
        /// <param name="updatedTeam">Обновленная команда</param>
        /// <returns>Выполнено</returns>
        Task UpdateTeamAsync(int id, Teams updatedTeam, CancellationToken cancellationToken);
        /// <summary>
        /// Удаление команды
        /// </summary>
        /// <param name="id">Идентификатор команды</param>
        /// <returns>Выполнено</returns>
        Task DeleteTeamAsync(int id, CancellationToken cancellationToken);
    }
    
    
}

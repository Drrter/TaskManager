using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// Интерфейс с методами управления участниками команд
    /// </summary>
    public interface ITeamMembersRepository
    {
        /// <summary>
        /// Получает список всех участников
        /// </summary>
        /// <returns>Список участников</returns>
        Task<IEnumerable<TeamMembers>> GetAllTeamMembersAsync(CancellationToken cancellationToken);
        /// <summary>
        /// Получает список участников по идентификатору команды
        /// </summary>
        /// <param name="idTeam">Идентификатор команды</param>
        /// <returns>Команда и участник с указанным идентификатором</returns>
        Task<TeamMembers> GetTeamMemberByIdTeamAsync(int idTeam,CancellationToken cancellationToken);
        /// <summary>
        /// Получает список участников по идентификатору пользователя
        /// </summary>
        /// <param name="idUser">Идентификатор пользователя</param>
        /// <returns>Команда и участник с указанным идентификатором</returns>
        Task<TeamMembers> GetTeamMemberByIdUserAsync(int idUser,CancellationToken cancellationToken);
        /// <summary>
        /// Удаление связи пользователя с командой
        /// </summary>
        /// <param name="idTeam">Идентификатор команды</param>
        /// <param name="idUser">Идентификатор пользователя</param>
        /// <returns>Выполнено</returns>
        Task DeleteTeamMemberAsync(int idTeam, int idUser, CancellationToken cancellationToken);
        /// <summary>
        /// Добавление новой записи 
        /// </summary>
        /// <param name="newMember">Новый участник команды</param>
        /// <returns>Выполнено</returns>
        Task AddMemberAsync(TeamMembers newMember, CancellationToken cancellationToken);
    }
    
}

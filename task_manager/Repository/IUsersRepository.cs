using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// Интерфейс с методами управления пользователями
    /// </summary>
    public interface IUsersRepository
    {
        /// <summary>
        /// Получает список всех пользователей
        /// </summary>
        /// <returns>Список пользователей</returns>
        Task<List<Users>> GetAllUsersAsync(CancellationToken cancellationToken);
        /// <summary>
        /// Получает пользователя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Пользователь с указанным идентификатором</returns>
        Task<Users> GetUserByIdAsync(int id, CancellationToken cancellationToken);
        /// <summary>
        /// Добавляет пользователя
        /// </summary>
        /// <param name="newUser">Новый пользователь(согласно классу users)</param>
        /// <returns>Выполнено</returns>
        Task AddUserAsync(Users newUser, CancellationToken cancellationToken);
        /// <summary>
        /// Обновление существующего пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <param name="updatedUser">Обновленный пользователь</param>
        /// <returns>Выполнено</returns>
        Task UpdateUserAsync(int id, Users updatedUser,CancellationToken cancellationToken);
        /// <summary>
        /// Удаление пользоватея
        /// </summary>
        /// <param name="id">Идентификатор пользоватея</param>
        /// <returns>Выполнено</returns>
        Task DeleteUserAsync(int id, CancellationToken cancellationToken);
    }
    
   
}

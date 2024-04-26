using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// Реализация репозитория IUserRepository
    /// </summary>
    public class UsersRepository : IUsersRepository
    {
        private readonly TaskContext _context;
        /// <summary>
        /// Передает taskcontext в конструктор
        /// </summary>
        /// <param name="context">Контекст базы данных для взаимодействия с ней </param>
        public UsersRepository(TaskContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Получает список всех пользователей
        /// </summary>
        /// <returns>Список пользователей</returns>
        public async Task<List<Users>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            return await _context.Users.ToListAsync(cancellationToken);
        }
        /// <summary>
        /// Получает пользователя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Пользователь с указанным идентификатором</returns>
        public async Task<Users> GetUserByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Users.FindAsync(id,cancellationToken);
        }
        /// <summary>
        /// Добавляет пользователя
        /// </summary>
        /// <param name="newUser">Новый пользователь(согласно классу users)</param>
        /// <returns>Выполнено</returns>
        public async Task AddUserAsync(Users newUser, CancellationToken cancellationToken)
        {
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync(cancellationToken);
        }
        /// <summary>
        /// Обновление существующего пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <param name="updatedUser">Обновленный пользователь</param>
        /// <returns>Выполнено</returns>
        public async Task UpdateUserAsync(int id, Users updatedUser, CancellationToken cancellationToken)
        {
            _context.Entry(updatedUser).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }
        /// <summary>
        /// Удаление пользоватея
        /// </summary>
        /// <param name="id">Идентификатор пользоватея</param>
        /// <returns>Выполнено</returns>
        public async Task DeleteUserAsync(int id, CancellationToken cancellationToken)
        {
            var userToDelete = await _context.Users.FindAsync(id);
            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// интерфейс с методами управления пользователями
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// получает список всех пользователей
        /// </summary>
        /// <returns>список пользователей</returns>
        Task<List<Users>> GetAllUsersAsync();
        /// <summary>
        /// получает пользователя по идентификатору
        /// </summary>
        /// <param name="id">идентификатор пользователя</param>
        /// <returns>пользователь с указанным идентификатором</returns>
        Task<Users> GetUserByIdAsync(int id);
        /// <summary>
        /// добавляет пользователя
        /// </summary>
        /// <param name="newUser">новый пользователь(согласно классу users)</param>
        /// <returns>выполнено</returns>
        Task AddUserAsync(Users newUser);
        /// <summary>
        /// обновление существующего пользователя
        /// </summary>
        /// <param name="id">идентификатор пользователя</param>
        /// <param name="updatedUser">обновленный пользователь</param>
        /// <returns>выполнено</returns>
        Task UpdateUserAsync(int id, Users updatedUser);
        /// <summary>
        /// удаление пользоватея
        /// </summary>
        /// <param name="id">идентификатор пользоватея</param>
        /// <returns>выполнено</returns>
        Task DeleteUserAsync(int id);
    }
    /// <summary>
    /// реализация репозитория IUserRepository
    /// </summary>
    public class UserRepository:IUserRepository
    {
        private readonly TaskContext _context;
        /// <summary>
        /// передает taskcontext в конструктор
        /// </summary>
        /// <param name="context">контекст базы данных для взаимодействия с ней </param>
        public UserRepository(TaskContext context)
        {
            _context = context;
        }
        /// <summary>
        /// получает список всех пользователей
        /// </summary>
        /// <returns>список пользователей</returns>
        public async Task<List<Users>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        /// <summary>
        /// получает пользователя по идентификатору
        /// </summary>
        /// <param name="id">идентификатор пользователя</param>
        /// <returns>пользователь с указанным идентификатором</returns>
        public async Task<Users> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        /// <summary>
        /// добавляет пользователя
        /// </summary>
        /// <param name="newUser">новый пользователь(согласно классу users)</param>
        /// <returns>выполнено</returns>
        public async Task AddUserAsync(Users newUser)
        {
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// обновление существующего пользователя
        /// </summary>
        /// <param name="id">идентификатор пользователя</param>
        /// <param name="updatedUser">обновленный пользователь</param>
        /// <returns>выполнено</returns>
        public async Task UpdateUserAsync(int id, Users updatedUser)
        {
            _context.Entry(updatedUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// удаление пользоватея
        /// </summary>
        /// <param name="id">идентификатор пользоватея</param>
        /// <returns>выполнено</returns>
        public async Task DeleteUserAsync(int id)
        {
            var userToDelete = await _context.Users.FindAsync(id);
            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
    /// <summary>
    /// Сервис для управления пользователями
    /// </summary>
    public class UsersService
    {
        /// <summary>
        /// зависимость типа IUserRepository
        /// </summary>
        private readonly IUserRepository _userRepository;
        public UsersService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        /// <summary>
        /// получает список всех пользователей
        /// </summary>
        /// <returns>список пользователей</returns>
        public async Task<List<Users>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllUsersAsync();
        }
        /// <summary>
        /// получает пользователя по идентификатору
        /// </summary>
        /// <param name="id">идентификатор пользователя</param>
        /// <returns>пользователь с указанным идентификатором</returns>
        public async Task<Users> GetUserByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }
        /// <summary>
        /// добавляет пользователя
        /// </summary>
        /// <param name="newUser">новый пользователь(согласно классу users)</param>
        /// <returns>выполнено</returns>
        public async Task AddUserAsync(Users newUser, CancellationToken cancellationToken)
        {
            await _userRepository.AddUserAsync(newUser);
        }
        /// <summary>
        /// обновление существующего пользователя
        /// </summary>
        /// <param name="id">идентификатор пользователя</param>
        /// <param name="updatedUser">обновленный пользователь</param>
        /// <returns>выполнено</returns>
        public async Task UpdateUserAsync(Users updatedUser, CancellationToken cancellationToken)
        {
            await _userRepository.UpdateUserAsync(updatedUser.IdUser, updatedUser);
        }
        /// <summary>
        /// удаление пользоватея
        /// </summary>
        /// <param name="id">идентификатор пользоватея</param>
        /// <returns>выполнено</returns>
        public async Task DeleteUserAsync(int id, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}

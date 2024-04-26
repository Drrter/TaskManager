using TaskManager.DB;
using TaskManager.Repository;

namespace TaskManager.Services
{
    /// <summary>
    /// Сервис для управления пользователями
    /// </summary>
    public class UsersService
    {
        /// <summary>
        /// Зависимость типа IUserRepository
        /// </summary>
        private readonly IUsersRepository _userRepository;
        public UsersService(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }
        /// <summary>
        /// Получает список всех пользователей
        /// </summary>
        /// <returns>Список пользователей</returns>
        public async Task<List<Users>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllUsersAsync(cancellationToken);
        }
        /// <summary>
        /// Получает пользователя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Пользователь с указанным идентификатором</returns>
        public async Task<Users> GetUserByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserByIdAsync(id,cancellationToken);
        }
        /// <summary>
        /// Добавляет пользователя
        /// </summary>
        /// <param name="newUser">Новый пользователь(согласно классу users)</param>
        /// <returns>Выполнено</returns>
        public async Task AddUserAsync(Users newUser, CancellationToken cancellationToken)
        {
            await _userRepository.AddUserAsync(newUser, cancellationToken);
        }
        /// <summary>
        /// Обновление существующего пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <param name="updatedUser">Обновленный пользователь</param>
        /// <returns>Выполнено</returns>
        public async Task UpdateUserAsync(Users updatedUser, CancellationToken cancellationToken)
        {
            await _userRepository.UpdateUserAsync(updatedUser.Id, updatedUser,cancellationToken);
        }
        /// <summary>
        /// Удаление пользоватея
        /// </summary>
        /// <param name="id">Идентификатор пользоватея</param>
        /// <returns>Выполнено</returns>
        public async Task DeleteUserAsync(int id, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteUserAsync(id, cancellationToken);
        }
    }
}

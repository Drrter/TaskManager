using System.ComponentModel.DataAnnotations;

namespace TaskManager.DB
{
    /// <summary>
    /// Сущность пользователей
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public required string Surname { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Почта пользователя
        /// </summary>
        public required string Email { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public required string Password { get; set; }

    }
}

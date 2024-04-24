using System.ComponentModel.DataAnnotations;

namespace TaskManager.DB
{
    /// <summary>
    /// сущность пользователей
    /// </summary>
    public class Users
    {
        /// <summary>
        /// идентификатор пользователя
        /// </summary>
        [Key]public int IdUser { get; set; }
        /// <summary>
        /// фамилия пользователя
        /// </summary>
        public required string Surname { get; set; }
        /// <summary>
        /// имя пользователя
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// почта пользователя
        /// </summary>
        public required string Email { get; set; }
        /// <summary>
        /// пароль
        /// </summary>
        public required string Password { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace TaskManager.DB
{
    /// <summary>
    /// Сущность команд
    /// </summary>
    public class Teams
    {
        /// <summary>
        /// Идентификатор команды
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название команды
        /// </summary>
        public required string TeamName { get; set; }
    }
}

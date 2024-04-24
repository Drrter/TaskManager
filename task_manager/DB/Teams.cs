using System.ComponentModel.DataAnnotations;

namespace TaskManager.DB
{
    /// <summary>
    /// сущность команд
    /// </summary>
    public class Teams
    {
        /// <summary>
        /// идентификатор команды
        /// </summary>
        [Key]public int IdTeam { get; set; }
        /// <summary>
        /// название команды
        /// </summary>
        public required string TeamName { get; set; }
    }
}

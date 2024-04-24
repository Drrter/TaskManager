using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TaskManager.DB
{
    /// <summary>
    /// сущность, показывающая состав команды/принадлежность пользователя команде
    /// </summary>
    public class TeamMembers
    {
        /// <summary>
        /// 1 часть составного ключа, идентификатор команды
        /// </summary>
        [Key]
        [Column(Order = 0)] public int IdTeam { get; set; }
        /// <summary>
        /// 2 часть составного ключа, идентификатор пользователя
        /// </summary>
        [Key]
        [Column(Order = 1)] public int IdUser { get; set; }
        /// <summary>
        /// роль пользователя в команде
        /// </summary>
        public required string Role { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

namespace TaskManager.DB
{
    /// <summary>
    /// Сущность комментариев к задачам
    /// </summary>
    public class Comments
    {
        /// <summary>
        /// уникальный идентификатор комментария
        /// </summary>
        [Key] public int IdComment { get; set; }
        [ForeignKey("IdTask")]
        /// <summary>
        /// идентификатор задачи, к которой относится комментарий
        /// </summary>
        public int IdTask {  get; set; }
        /// <summary>
        /// идентификатор пользователя, написавшего комментарий
        /// </summary>
        [ForeignKey("IdUser")]public int IdUser { get; set; }
        /// <summary>
        /// текст комментария
        /// </summary>
        public required string TextComment { get; set; }
        /// <summary>
        /// дата и время написания комментария
        /// </summary>
        public DateTime Datetime { get; set; }

    }
}

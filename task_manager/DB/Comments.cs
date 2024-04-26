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
        /// Уникальный идентификатор комментария
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Идентификатор задачи, к которой относится комментарий
        /// </summary>
        public int IdTask {  get; set; }
        /// <summary>
        /// Идентификатор пользователя, написавшего комментарий
        /// </summary>
        public int IdUser { get; set; }
        /// <summary>
        /// Текст комментария
        /// </summary>
        public required string TextComment { get; set; }
        /// <summary>
        /// Дата и время написания комментария
        /// </summary>
        public DateTime Datetime { get; set; }

    }
}

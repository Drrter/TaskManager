using System.ComponentModel.DataAnnotations;

namespace TaskManager.DB
{
    /// <summary>
    /// Сущность событий
    /// </summary>
    public class Events
    {
        /// <summary>
        /// Идентификатор события
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название события
        /// </summary>
        public required string EventName { get; set; }
        /// <summary>
        /// Описание события
        /// </summary>
        public required string EventDescription { get; set; }
        /// <summary>
        /// Время проведения события
        /// </summary>
        public DateTime EventDatetime { get; set; }
    }
}

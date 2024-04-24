using System.ComponentModel.DataAnnotations;

namespace TaskManager.DB
{
    /// <summary>
    /// сущность событий
    /// </summary>
    public class Events
    {
        /// <summary>
        /// идентификатор события
        /// </summary>
        [Key] public int IdEvent { get; set; }
        /// <summary>
        /// название события
        /// </summary>
        public required string EventName { get; set; }
        /// <summary>
        /// описание события
        /// </summary>
        public required string EventDescription { get; set; }
        /// <summary>
        /// время проведения события
        /// </summary>
        public DateTime EventDatetime { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TaskManager.DB
{
    /// <summary>
    /// Сущность приоритетов (от низкого к высокому)
    /// </summary>
    public class PrioritiesTask
    {
        /// <summary>
        /// Идентификатор приоритета
        /// </summary>
        public int Id {  get; set; }
        /// <summary>
        /// Имя приоритета
        /// </summary>
        public required string PriorityName { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TaskManager.DB
{
    /// <summary>
    /// сущность приоритетов (от низкого к высокому)
    /// </summary>
    public class PrioritiesTask
    {
        /// <summary>
        /// идентификатор приоритета
        /// </summary>
        [Key] public int IdPriority {  get; set; }
        /// <summary>
        /// имя приоритета
        /// </summary>
        public required string PriorityName { get; set; }
    }
}

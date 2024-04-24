using System.ComponentModel.DataAnnotations;
//using task_manager.DB;

namespace TaskManager.DB
{
    /// <summary>
    /// сущность статусов задач(Создана, выполняется, выполнена, в архиве)
    /// </summary>
    public class StatusTask
    {
        /// <summary>
        /// идентификатор статуса
        /// </summary>
        [Key] public int IdStatus { get; set; }
        /// <summary>
        /// имя статуса
        /// </summary>
        public required string Status { get; set; }
        /// <summary>
        /// описание статуса
        /// </summary>
        public required string DescriptionStat { get; set; }
    }
}

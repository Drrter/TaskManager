using System.ComponentModel.DataAnnotations;
//using task_manager.DB;

namespace TaskManager.DB
{
    /// <summary>
    /// Сущность статусов задач(Создана, выполняется, выполнена, в архиве)
    /// </summary>
    public class StatusTask
    {
        /// <summary>
        /// Идентификатор статуса
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя статуса
        /// </summary>
        public required string Status { get; set; }
        /// <summary>
        /// Описание статуса
        /// </summary>
        public required string DescriptionStat { get; set; }
    }
}

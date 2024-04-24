using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TaskManager.DB
{
    /// <summary>
    /// сущность выполненных (архивных) задач
    /// </summary>
    public class CompletedTasks
    {
        /// <summary>
        /// идентификатор архивной задачи
        /// </summary>
        [Key] public int IdCompltask {  get; set; }
        /// <summary>
        /// название архивной задачи
        /// </summary>
        public required string CompltaskName { get; set; }
        /// <summary>
        /// описание архивной задачи
        /// </summary>
        public required string DescriptionCompltask { get; set; }
        /// <summary>
        /// статус задачи(всегда - 4(в архиве))
        /// </summary>
        [ForeignKey("IdStatus")] public int IdStatus { get; set; }
        /// <summary>
        /// дата выполнения задачи
        /// </summary>
        public DateOnly CompltaskEnddate { get; set; }
        /// <summary>
        /// идентификатор пользователя, выполнявшего задачу
        /// </summary>
        [ForeignKey("IdUser")] public int IdUser {  get; set; }
        /// <summary>
        /// идентификатор создателя задачи
        /// </summary>
        [ForeignKey("IdUsercreator")] public int IdUsercreator { get; set; }
        /// <summary>
        /// идентификатор проекта, к которому отнросилась задача
        /// </summary>
        [ForeignKey("IdProject")] public int IdProject { get; set; }

    }
}

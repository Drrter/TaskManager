using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TaskManager.DB
{
    /// <summary>
    /// Сущность выполненных (архивных) задач
    /// </summary>
    public class CompletedTasks
    {
        /// <summary>
        /// Идентификатор архивной задачи
        /// </summary>
        public int Id {  get; set; }
        /// <summary>
        /// Название архивной задачи
        /// </summary>
        public required string CompltaskName { get; set; }
        /// <summary>
        /// Описание архивной задачи
        /// </summary>
        public required string DescriptionCompltask { get; set; }
        /// <summary>
        /// Статус задачи(всегда - 4(в архиве))
        /// </summary>
        public int IdStatus { get; set; }
        /// <summary>
        /// Дата выполнения задачи
        /// </summary>
        public DateOnly CompltaskEnddate { get; set; }
        /// <summary>
        /// Идентификатор пользователя, выполнявшего задачу
        /// </summary>
        public int IdUser {  get; set; }
        /// <summary>
        /// Идентификатор создателя задачи
        /// </summary>
        public int IdUsercreator { get; set; }
        /// <summary>
        /// Идентификатор проекта, к которому отнросилась задача
        /// </summary>
        public int IdProject { get; set; }

    }
}

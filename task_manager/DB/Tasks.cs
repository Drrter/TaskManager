using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TaskManager.DB
{
    /// <summary>
    /// сущность задач
    /// </summary>
    public class Tasks
    {
        /// <summary>
        /// идентификатор задачи
        /// </summary>
        [Key] public int IdTask { get; set; }
        /// <summary>
        /// название задачи
        /// </summary>
        public required string TaskName { get; set; }
        /// <summary>
        /// описание задачи
        /// </summary>
        public required string DescriptionTask { get; set;}
        /// <summary>
        /// статус задачи(для этой сущности от 1 до 3)
        /// </summary>
        [ForeignKey("IdStatus")] public int IdStatus { get; set; }
        /// <summary>
        /// дата выполнения задачи
        /// </summary>
        public DateOnly Deadline { get; set; }
        /// <summary>
        /// идентификатор пользователя, выполняющего задачу
        /// </summary>
        [ForeignKey("IdUser")] public int IdUser { get; set; }
        /// <summary>
        /// идентификатор создателя задачи
        /// </summary>
        [ForeignKey("IdUsercreator")] public int IdUsercreator {  get; set; }
        /// <summary>
        /// приоритет задачи
        /// </summary>
        [ForeignKey("IdPriority")] public int IdPriority { get; set; }
        /// <summary>
        /// проект, к которому относится задача
        /// </summary>
        [ForeignKey("IdProject")] public int IdProject { get; set; }


    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TaskManager.DB
{
    /// <summary>
    /// Сущность задач
    /// </summary>
    public class Tasks
    {
        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название задачи
        /// </summary>
        public required string TaskName { get; set; }
        /// <summary>
        /// Описание задачи
        /// </summary>
        public required string DescriptionTask { get; set;}
        /// <summary>
        /// Статус задачи(для этой сущности от 1 до 3)
        /// </summary>
        public int IdStatus { get; set; }
        /// <summary>
        /// Дата выполнения задачи
        /// </summary>
        public DateOnly Deadline { get; set; }
        /// <summary>
        /// Идентификатор пользователя, выполняющего задачу
        /// </summary>
        public int IdUser { get; set; }
        /// <summary>
        /// Идентификатор создателя задачи
        /// </summary>
        public int IdUsercreator {  get; set; }
        /// <summary>
        /// Приоритет задачи
        /// </summary>
        public int IdPriority { get; set; }
        /// <summary>
        /// Проект, к которому относится задача
        /// </summary>
        public int IdProject { get; set; }


    }
}

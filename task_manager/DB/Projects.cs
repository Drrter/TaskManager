using System.ComponentModel.DataAnnotations;

namespace TaskManager.DB
{
    /// <summary>
    /// Сущность проектов
    /// </summary>
    public class Projects
    {
        /// <summary>
        /// Идентификатор проекта
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название проекта
        /// </summary>
        public required string ProjectName { get; set; }
        /// <summary>
        /// Описание проекта
        /// </summary>
        public required string Description { get; set; }
        /// <summary>
        /// Дата начала работы над проектом
        /// </summary>
        public DateOnly StartDate { get; set; }
        /// <summary>
        /// Дата окончания работы над проектом
        /// </summary>
        public DateOnly EndDate { get; set;}
    }
}

using System.ComponentModel.DataAnnotations;

namespace TaskManager.DB
{
    /// <summary>
    /// сущность проектов
    /// </summary>
    public class Projects
    {
        /// <summary>
        /// идентификатор проекта
        /// </summary>
        [Key] public int IdProject { get; set; }
        /// <summary>
        /// название проекта
        /// </summary>
        public required string ProjectName { get; set; }
        /// <summary>
        /// описание проекта
        /// </summary>
        public required string Description { get; set; }
        /// <summary>
        /// дата начала работы над проектом
        /// </summary>
        public DateOnly StartDate { get; set; }
        /// <summary>
        /// дата окончания работы над проектом
        /// </summary>
        public DateOnly EndDate { get; set;}
    }
}

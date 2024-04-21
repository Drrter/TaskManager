using System.ComponentModel.DataAnnotations;

namespace TaskManager.DB
{
    public class Projects
    {
        [Key] public int IdProject { get; set; }
        public required string ProjectName { get; set; }
        public required string Description { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set;}
    }
}

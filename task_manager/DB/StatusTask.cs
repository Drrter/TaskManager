using System.ComponentModel.DataAnnotations;
//using task_manager.DB;

namespace TaskManager.DB
{
    public class StatusTask
    {
        [Key] public int IdStatus { get; set; }
        public required string Status { get; set; }
        public required string DescriptionStat { get; set; }
    }
}

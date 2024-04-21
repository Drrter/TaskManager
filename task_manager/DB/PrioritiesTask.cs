using System.ComponentModel.DataAnnotations;

namespace TaskManager.DB
{
    public class PrioritiesTask
    {
        [Key] public int IdPriority {  get; set; }
        public required string PriorityName { get; set; }
    }
}

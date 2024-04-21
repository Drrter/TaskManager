using System.ComponentModel.DataAnnotations;

namespace TaskManager.DB
{
    public class Events
    {
        [Key] public int IdEvent { get; set; }
        public required string EventName { get; set; }
        public required string EventDescription { get; set; }
        public DateTime EventDatetime { get; set; }
    }
}

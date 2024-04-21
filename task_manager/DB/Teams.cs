using System.ComponentModel.DataAnnotations;

namespace TaskManager.DB
{
    public class Teams
    {
        [Key]public int IdTeam { get; set; }
        public required string TeamName { get; set; }
    }
}

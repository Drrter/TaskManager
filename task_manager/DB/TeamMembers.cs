using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TaskManager.DB
{
    public class TeamMembers
    {
        [Key]
        [Column(Order = 0)] public int IdTeam { get; set; }
        [Key]
        [Column(Order = 1)] public int IdUser { get; set; }
        public required string Role { get; set; }

    }
}

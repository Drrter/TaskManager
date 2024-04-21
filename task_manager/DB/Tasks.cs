using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TaskManager.DB
{
    public class Tasks
    {
        [Key] public int IdTask { get; set; }
        public required string TaskName { get; set; }
        public required string DescriptionTask { get; set;}
        [ForeignKey("IdStatus")] public int IdStatus { get; set; }
        public DateOnly Deadline { get; set; }
        [ForeignKey("IdUser")] public int IdUser { get; set; }
        [ForeignKey("IdUsercreator")] public int IdUsercreator {  get; set; }
        [ForeignKey("IdPriority")] public int IdPriority { get; set; }
        [ForeignKey("IdProject")] public int IdProject { get; set; }


    }
}

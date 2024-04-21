using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TaskManager.DB
{
    public class CompletedTasks
    {
       [Key] public int IdCompltask {  get; set; }
        public required string CompltaskName { get; set; }
        public required string DescriptionCompltask { get; set; }
        [ForeignKey("IdStatus")] public int IdStatus { get; set; }
        public DateOnly CompltaskEnddate { get; set; }
        [ForeignKey("IdUser")] public int IdUser {  get; set; }
        [ForeignKey("IdUsercreator")] public int IdUsercreator { get; set; }
        [ForeignKey("IdProject")] public int IdProject { get; set; }

    }
}

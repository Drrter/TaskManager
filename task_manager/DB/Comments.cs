using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

namespace TaskManager.DB
{
    public class Comments
    {
        [Key] public int IdComment { get; set; }
        [ForeignKey("IdTask")]
        public int IdTask {  get; set; }
        [ForeignKey("IdUser")]public int IdUser { get; set; }
        public required string TextComment { get; set; }
        public DateTime Datetime { get; set; }

    }
}

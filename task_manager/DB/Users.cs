using System.ComponentModel.DataAnnotations;

namespace TaskManager.DB
{
    public class Users
    {
        [Key]public int IdUser { get; set; }
        public required string Surname { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

    }
}

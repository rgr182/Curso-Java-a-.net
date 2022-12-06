using System.ComponentModel.DataAnnotations;

namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string UserPassword { get; set; }
    }
}

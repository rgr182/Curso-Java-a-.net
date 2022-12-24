using System.ComponentModel.DataAnnotations;

namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class Members
    {
        [Key]
        public int MembersId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int CurrentLocationId { get; set; }
        public DateTime MemberRegistratior { get; set; } = DateTime.UtcNow;
        public string Email { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}

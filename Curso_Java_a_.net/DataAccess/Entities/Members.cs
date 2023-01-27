using System.ComponentModel.DataAnnotations;

namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class Members
    {
        [Key]
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public int CurrentLocationId { get; set; }
        public DateTime MemberRegistration { get; set; } = DateTime.UtcNow;
        public string Email { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public bool? isAdmin { get; set; }
        public bool? isMentor { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CV { get; set; }
        public string? Feedback { get; set; }
        public int StatusId { get; set; }

    }
}

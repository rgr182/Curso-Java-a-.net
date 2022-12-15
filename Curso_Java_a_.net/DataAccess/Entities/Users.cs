using System.ComponentModel.DataAnnotations;

namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class Users
    {
        
        [Key]
        public long Id { get; set; }
        public int AppUserId { get; set; }
        public string Uuid { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public long SchoolId { get; set; }
        public long CompanyId { get; set; }
        public long SchoolKeyId { get; set; }
        public long RoleId { get; set; }
        public long LevelId { get; set; }
        public long TutorId { get; set; }
        public string Email { get; set; }
        public int Grade { get; set; }
        public string Avatar { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime MemberSince { get; set; }
        public System.DateTime LastLogin { get; set; }
        public bool VerifiedEmail { get; set; }
        public string RememberToken { get; set; }
        public System.DateTime DeletedAt { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public long ActiveThinkific { get; set; }
        public long ActivePhpfox { get; set; }
        
    }
}

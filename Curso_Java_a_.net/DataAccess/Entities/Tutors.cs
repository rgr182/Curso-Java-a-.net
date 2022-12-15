namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class Tutor
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long? RoleId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Role Role { get; set; }
    }

}

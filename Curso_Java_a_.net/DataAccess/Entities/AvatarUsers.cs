namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class AvatarUsers
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long AvatarId { get; set; }
        public string CustomName { get; set; }
        public string AvatarPath { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

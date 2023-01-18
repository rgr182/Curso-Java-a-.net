namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class Groups
    {
        public long GroupId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public long TeacherId { get; set; }
        public long SchoolId { get; set; }
        public int Grade { get; set; }
        public byte IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

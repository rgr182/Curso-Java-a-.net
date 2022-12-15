namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class Role
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int? ThisOrder { get; set; }
        public int? RoleNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Special { get; set; }
    }

}

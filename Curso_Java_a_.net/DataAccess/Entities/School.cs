namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class School
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
        public long? CurrentUser { get; set; }
        public bool HasKinder { get; set; }
        public bool HasH2D { get; set; }
        public bool HasClPlus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}

namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class Grade
    {
        public long Id { get; set; }
        public int GradeNumber { get; set; }
        public string GradeName { get; set; } = "";
        public string SchoolLevel { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
    }
}

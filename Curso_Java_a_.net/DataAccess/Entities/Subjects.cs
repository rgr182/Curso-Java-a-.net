using System.ComponentModel.DataAnnotations;
namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class Subjects
    {
        [Key]
        public long SubjectId { get; set; }
        public string Name { get; set; } = "";
        public string Schedule { get; set; } = "";
    }
}

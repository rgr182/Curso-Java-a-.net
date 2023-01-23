using Curso_Java_a_.net.DataAccess.Enumerables;
using System.ComponentModel.DataAnnotations;

namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class Grades
    {
        [Key]
        public int GradesId { get; set; }
        public string Period { get; set; }
        public int Grade { get; set; }
        public GradesEnumerable GradesE{ get; set; }
        public int EvaluationId { get; set; }
        public int MemberId { get; set; }
        public DateTime GradeDate { get; set; } = DateTime.UtcNow;        
    }
}

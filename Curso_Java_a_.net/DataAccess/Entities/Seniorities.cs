using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class Seniorities
    {
        [Key]
        public int SeniorityId { get; set; }
        public string Name { get; set; }
    }
}

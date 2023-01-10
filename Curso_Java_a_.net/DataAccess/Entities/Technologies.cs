using System.ComponentModel.DataAnnotations;

namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class Technologies
    {
        [Key]
        public int TechnologyId { get; set; }
        public string Name { get; set; }
    }
}

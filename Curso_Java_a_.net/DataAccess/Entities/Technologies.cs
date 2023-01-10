using System.ComponentModel.DataAnnotations;

namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class Tecnologies
    {
        [Key]
        public int TechnologyIdId { get; set; }
        public string Name { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curso_Java_a_.net.DataAccess.Models
{
    public class Materias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMateria { get; set; }
        public string Nombre { get; set; }
        public string Horario { get; set; }
        public string Maestro { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Curso_Java_a_.net.DataAccess.Models
{
    public class materiasusuarios
    {
        [Key]
        public int idmateriasusarios { get; set; }
        public int calificacion { get; set; }
        public virtual materias Course { get; set; }
        public virtual usuarios Student { get; set; }
    }
}
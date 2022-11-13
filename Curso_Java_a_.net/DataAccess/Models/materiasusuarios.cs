using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curso_Java_a_.net.DataAccess.Models
{
    public class materiasusuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idmateriausuario { get; set; }
        public int calificacion { get; set; }
        public int idmateria { get; set; }
        public int idusuario { get; set; }
        
        [ForeignKey("idmateria")]
        public virtual materias materia { get; set; }
        
        [ForeignKey("idusuario")]
        public virtual usuarios usuarios { get; set; }
    }
}
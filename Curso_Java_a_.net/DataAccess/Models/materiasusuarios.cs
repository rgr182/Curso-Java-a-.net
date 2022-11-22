using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curso_Java_a_.net.DataAccess.Models
{
    public class MateriasUsuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMateriaUsuario { get; set; }
        public int Calificacion { get; set; }
        public int IdMateria { get; set; }
        public int IdUsuario { get; set; }
        
        [ForeignKey("IdMateria")]
        public virtual Materias Materia { get; set; }
        
        [ForeignKey("IdUsuario")]
        public virtual Usuarios Usuarios { get; set; }
    }
}

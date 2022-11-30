using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class MateriasUsuarios
    {        
        public int IdMateriaUsuario { get; set; }
        public int Calificacion { get; set; }
        public int IdMateria { get; set; }
        public int IdUsuario { get; set; }


        #region one to many

        public virtual List<Materias> Materia { get; set; }        
        
        public virtual List<Usuarios> Usuario { get; set; }

        #endregion
    }
}

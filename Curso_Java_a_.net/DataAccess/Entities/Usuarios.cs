using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class Usuarios
    {        
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; }
        public int Edad { get; set; }
    }
}

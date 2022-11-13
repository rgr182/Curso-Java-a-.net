using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curso_Java_a_.net.DataAccess.Models
{
    public class materias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idmateria { get; set; }
        public string nombre { get; set; }
        public string horario { get; set; }
        public string maestro { get; set; }

    }
}
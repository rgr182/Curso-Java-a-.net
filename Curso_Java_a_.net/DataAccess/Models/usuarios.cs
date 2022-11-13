using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curso_Java_a_.net.DataAccess.Models
{
    public class usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idusuario { get; set; }
        public string nombre { get; set; }
        public string genero { get; set; }
        public DateTime fechanacimiento { get; set; }
        public string correo { get; set; }
        public int edad { get; set; }
    }
}
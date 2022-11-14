using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Curso_Java_a_.Classes
{
    public class Usuarios
    {
        public int IdUsuario { set; get; }
        private string Nombre { set; get; }
        private string Correo { set; get; }
        private int Edad { set; get; }
        private char Genero { set; get; }
        private string FechaNacimiento { set; get; }


        public Usuarios()
        {
            Nombre = "";
            Correo = "";
            FechaNacimiento = "";
        }

    }

    public class Consulta : IConsulta
    {
        Usuarios usuario = new Usuarios();
        usuario.
        private string connstring;
        private string sql;
        private List<Usuarios> ListaUsuarios;

        public int showUsuarios()
        {
            connstring = "Data Source=DESKTOP-8JM1EC1\\SQLEXPRESS;Initial Catalog=Escuela;Integrated Security=True";
            sql = "SELECT * FROM Usuarios";
            ListaUsuarios = new List<Usuarios>();

            using (var connection = new SqlConnection(connstring))
            {
                connection.Open();
                ListaUsuarios = (List<Usuarios>)connection.Query<Usuarios>(sql);
            }

            return ListaUsuarios.Count;
        }
    }

    public interface IConsulta
    {
        public int showUsuarios();
    }
}

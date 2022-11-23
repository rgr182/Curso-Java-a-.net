using Dapper;
using System.Data.SqlClient;

namespace Curso_Java_a_.net.DataAccess.Models
{
    public class Consulta : IConsulta
    {
        private string ConnString;
        private string SQL;
        private List<Usuarios> ListaUsuarios;

        public int ShowUsuarios()
        {
            ConnString = "Data Source=DESKTOP-8JM1EC1\\SQLEXPRESS;Initial Catalog=Escuela;Integrated Security=True";
            SQL = "SELECT * FROM Usuarios";
            ListaUsuarios = new List<Usuarios>();
            
            using (var connection = new SqlConnection(ConnString))
            {
                connection.Open();
                ListaUsuarios = (List<Usuarios>)connection.Query<Usuarios>(SQL);
            }
            
            return ListaUsuarios.Count;
        }
    }
    
    public interface IConsulta
    {
        public int ShowUsuarios();
    }
}

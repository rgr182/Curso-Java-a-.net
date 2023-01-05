using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class HomeworkRepository : IHomeworkRepository
    {
        internal ClubLiaContext _context;
        public HomeworkRepository(ClubLiaContext context)
        {
            _context = context;
        }

        public Task<Homework> GetHomework(long UserId)
        {
            throw new NotImplementedException();
        }
        public class resultado
        {
            public Homework homework { get; set; }
            public string custom_name { get; set; }
            public Activity activity { get; set; }
            public string file { get; set; }
            public string url { get; set; }
            public string file_path { get; set; }
            public string url_path { get; set; }
            public long id { get; set; }
            public string group_name { get; set; }
            public string teachers_name { get; set; }
        }
        
        public Task<List<resultado>> GetHomeworks(long UserId,int Role, long GroupId, bool isActive, string OrderDate, string Status)
        {
            string[] roles = { "5", "13", "6", "18", "19", "20", "21", "34", "35", "36" };
            string query = @"SELECT homework.*, custom_subjects.custom_name, activity.*, activity.file_path as file, activity.url_path as url, homework.file_path as file_path, homework.url_path as url_path, homework.id as id,
                            groups.name as group_name, CONCAT(COALESCE(users.name,''), ' ', COALESCE(users.second_name+' ',''), COALESCE(users.last_name,'')) as teachers_name
                            FROM homework
                            INNER JOIN activity ON homework.activity_id = activity.id
                            INNER JOIN custom_subjects ON activity.subject_id = custom_subjects.id
                            INNER JOIN groups ON activity.group_id = groups.id
                            INNER JOIN users ON groups.teacher_id = users.id
                            WHERE homework.student_id = " + UserId;
            if (roles.Contains(Role.ToString()))
            {
                query += " AND activity.is_active = 1";
            }
            if (GroupId != 0)
            {
                query += " AND activity.group_id = "+GroupId;
            }
            if (isActive)
            {
                query += " AND activity.finish_date > '"+DateTime.Now+"'";
            }
            else
            {
                query += " AND activity.finish_date < '" + DateTime.Now + "'";
            }
            if (Status != null)
            {
                query += " AND homework.status = '" + Status + "'";
            }
            query += " ORDER BY activity.created_at " + OrderDate;
            //return _context.Database.GetDbConnection().QueryAsync<Homework>(query, new { UserId, GroupId, isActive, OrderDate, Status });

            string ConnString;
            string SQL;
            List<resultado> ListaUsuarios;
            ConnString = Environment.GetEnvironmentVariable("Connection");
            SQL = "SELECT * FROM Usuarios";

            using (var connection = new MySqlConnection(ConnString))
            {
                ListaUsuarios = (List<resultado>)connection.Query<resultado>(query);
            }
            return Task.FromResult(ListaUsuarios);
        }

        public Task<Homework> GetHomeworksByActivityId(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Homework>> GetHomeworks(long UserId, long GroupId, bool isActive, string OrderDate, string Status)
        {
            throw new NotImplementedException();
        }
    }
}

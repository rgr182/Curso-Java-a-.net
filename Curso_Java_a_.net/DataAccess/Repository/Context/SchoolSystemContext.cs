using Microsoft.EntityFrameworkCore;
using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Repository.Context
{
    public class SchoolSystemContext : DbContext
    {

        private static SchoolSystemContext schoolSystemContext = null;

        public SchoolSystemContext()
        {
        }

        public SchoolSystemContext(DbContextOptions<SchoolSystemContext> options)
            : base(options) 
        {
        }
        
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<UsersSubjects> UsersSubjects { get; set; }
        public DbSet<Session> Session { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<Technologies> Technologies { get; set; }



        public  static SchoolSystemContext Create()
        {
            if (schoolSystemContext == null)
                schoolSystemContext = new SchoolSystemContext();
            return schoolSystemContext;
        }
    }
}

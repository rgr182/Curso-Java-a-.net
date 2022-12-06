using Microsoft.EntityFrameworkCore;
using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Repository.Context
{
    public class SchoolSystemContext : DbContext
    {
        public SchoolSystemContext(DbContextOptions<SchoolSystemContext> options) 
            : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<UsersSubjects> UsersSubjects { get; set; }
        public DbSet<Session> Session { get; set; }
    }
}

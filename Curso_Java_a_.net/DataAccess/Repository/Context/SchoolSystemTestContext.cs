using Microsoft.EntityFrameworkCore;
using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Repository.Context
{
    public class SchoolSystemTestContext : DbContext
    {
        public SchoolSystemTestContext(DbContextOptions<SchoolSystemTestContext> options) 
            : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<UsersSubjects> UsersSubjects { get; set; }
        public DbSet<Tokens> Tokens { get; set; }
    }
}

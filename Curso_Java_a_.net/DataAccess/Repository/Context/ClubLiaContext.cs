using Microsoft.EntityFrameworkCore;
using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Repository.Context
{
    public class ClubLiaContext : DbContext
    {
        public ClubLiaContext(DbContextOptions<ClubLiaContext> options)
            : base(options) 
        {
        }
        public DbSet<Session> Session { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}

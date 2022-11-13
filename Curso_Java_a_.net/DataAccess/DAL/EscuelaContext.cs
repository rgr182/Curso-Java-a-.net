using System.Collections.Generic;
using System.Data.SqlClient;
using Curso_Java_a_.net.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.DAL
{
    public class EscuelaContext : DbContext
    {
        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
        {
            
        }
        public DbSet<usuarios> usuarios { get; set; }
        public DbSet<materiasusuarios> materiasusuarios { get; set; }
        public DbSet<materias> materias { get; set; }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=Drakko5257\\SQLEXPRESS;Database=Escuela;Trusted_Connection=True;MultipleActiveResultSets=true");
        }*/
    }
}
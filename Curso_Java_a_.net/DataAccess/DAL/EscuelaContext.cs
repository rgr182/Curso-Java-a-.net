using System.Collections.Generic;
using System.Data.SqlClient;
using Curso_Java_a_.net.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.DAL
{
    public class EscuelaContext : DbContext
    {
        public DbSet<usuarios> Estudiantes { get; set; }
        public DbSet<materiasusuarios> MateriasEstudiantes { get; set; }
        public DbSet<materias> Materias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Escuela;Trusted_Connection=True");
        }
    }
}
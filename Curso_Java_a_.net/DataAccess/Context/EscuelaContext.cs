using System.Collections.Generic;
using System.Data.SqlClient;
using Curso_Java_a_.net.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.Context.DAL
{
    public class EscuelaContext : DbContext
    {
        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
        {
            
        }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<MateriasUsuarios> MateriasUsuarios { get; set; }
        public DbSet<Materias> Materias { get; set; }
    }
}
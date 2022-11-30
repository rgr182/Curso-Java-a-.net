using System.Collections.Generic;
using Curso_Java_a_.net.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.Repository.Context
{
    public class TrainingSystemContext : DbContext
    {
        public TrainingSystemContext(DbContextOptions<TrainingSystemContext> options) : base(options)
        {
            
        }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<MateriasUsuarios> MateriasUsuarios { get; set; }
        public DbSet<Materias> Materias { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Entities.Mapping
{
    public class MateriasUsuariosMapping : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            #region Keys

            modelBuilder.Entity<MateriasUsuarios>()
            .HasKey(s => s.IdMateriaUsuario);

            #endregion


            #region Foreign Keys

            modelBuilder.Entity<MateriasUsuarios>()
              .HasMany(s => s.Materia);


            modelBuilder.Entity<MateriasUsuarios>()
              .HasMany(s => s.Usuario);

            #endregion

            //Property Configurations
            modelBuilder.Entity<MateriasUsuarios>()
                .Property(s => s.IdMateriaUsuario)
                .ValueGeneratedOnAdd()
                .HasColumnName("IdMateriaUsuario")
                .IsRequired();
        }
    }
}

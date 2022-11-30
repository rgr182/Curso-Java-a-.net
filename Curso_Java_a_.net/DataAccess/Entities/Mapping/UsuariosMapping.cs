using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Entities.Mapping
{
    public class UsuariosMapping : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            #region Primary Keys

            modelBuilder.Entity<Usuarios>()
              .HasKey(s => s.IdUsuario);

            #endregion


            //Property Configurations
            modelBuilder.Entity<Usuarios>()
                .Property(s => s.IdUsuario)
                .ValueGeneratedOnAdd()
                .HasColumnName("IdUsuario")
                .IsRequired();
        }
    }
}

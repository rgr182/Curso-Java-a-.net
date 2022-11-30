using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Entities.Mapping
{
    public class MateriasMapping : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            #region Primary Keys

            modelBuilder.Entity<Materias>()
              .HasKey(s => s.IdMateria);

            #endregion


            //Property Configurations
            modelBuilder.Entity<Materias>()
                .Property(s => s.IdMateria)
                .ValueGeneratedOnAdd()
                .HasColumnName("IdMateria")
                .IsRequired();
        }
    }
}

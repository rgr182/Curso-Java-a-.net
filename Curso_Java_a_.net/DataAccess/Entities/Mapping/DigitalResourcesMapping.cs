using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Entities.Mapping
{
    public class DigitalResourcesMapping : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region DigitalResources
            modelBuilder.Entity<DigitalResources>()
                .ToTable("digital_resources");
            #region Primary Keys
            modelBuilder.Entity<DigitalResources>()
                .HasKey(x => x.Id)
                .HasName("id");
            #endregion
            #region Properties
            modelBuilder.Entity<DigitalResources>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id")
                .IsRequired();
            modelBuilder.Entity<DigitalResources>()
                .Property(x => x.Bloque)
                .HasColumnName("bloque")
                .IsRequired();
            modelBuilder.Entity<DigitalResources>()
                .Property(x => x.Grade)
                .HasColumnName("grade")
                .IsRequired();
            modelBuilder.Entity<DigitalResources>()
                .Property(x => x.Level)
                .HasColumnName("level")
                .IsRequired();
            modelBuilder.Entity<DigitalResources>()
                .Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired();
            modelBuilder.Entity<DigitalResources>()
                .Property(x => x.UrlResource)
                .HasColumnName("url_resource")
                .IsRequired();
            modelBuilder.Entity<DigitalResources>()
                .Property(x => x.IdMateriaBase)
                .HasColumnName("id_materia_base")
                .IsRequired();
            modelBuilder.Entity<DigitalResources>()
                .Property(x => x.IdCategory)
                .HasColumnName("id_category")
                .IsRequired();
            modelBuilder.Entity<DigitalResources>()
                .Property(x => x.Description)
                .HasColumnName("description")
                .IsRequired();
            modelBuilder.Entity<DigitalResources>()
                .Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
            modelBuilder.Entity<DigitalResources>()
                .Property(x => x.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired();
            #endregion
            #endregion


        }
    }
}

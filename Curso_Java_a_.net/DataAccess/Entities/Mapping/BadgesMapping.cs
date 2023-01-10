using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Entities.Mapping
{
    public class BadgesMapping : DbContext
    {
        protected override void OnModelCreating (ModelBuilder modelBuilder)        
        {
            #region Badges
            modelBuilder.Entity<Badges>()
                .ToTable("badges");
            #region Primary Keys
            modelBuilder.Entity<Badges>()
                .HasKey(x => x.Id)
                .HasName("id");
            #endregion
            #region Properties
            modelBuilder.Entity<Badges>()
                .Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired();
            modelBuilder.Entity<Badges>()
                .Property(x => x.Description)
                .HasColumnName("description");
            modelBuilder.Entity<Badges>()
                .Property(x => x.Badge)
                .HasColumnName("badge")
                .IsRequired();
            modelBuilder.Entity<Badges>()
                .Property(x => x.Score)
                .HasColumnName("score");
               
                
            #endregion
            #endregion
        }
    }
}

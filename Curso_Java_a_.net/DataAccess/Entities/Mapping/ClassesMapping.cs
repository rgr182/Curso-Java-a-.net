using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Entities.Mapping
{
    public class ClassesMapping : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Classes
            modelBuilder.Entity<Classes>()
                .ToTable("classes");
            #endregion
            #region Primary Keys
            modelBuilder.Entity<Classes>()
                .HasKey(x => x.ClassesId)
                .HasName("Id");
            #endregion
            #region Properties
            modelBuilder.Entity<Classes>()
                .Property(x => x.TeacherId)
                .HasColumnName("TeacherId")
                .IsRequired();
            modelBuilder.Entity<Classes>()
                .Property(x => x.MeetingId)
                .HasColumnName("MeetingId")
                .IsRequired();
            modelBuilder.Entity<Classes>()
                .Property(x => x.GroupId)
                .HasColumnName("GroupId")
                .IsRequired();
            modelBuilder.Entity<Classes>()
                .Property(x => x.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();
            modelBuilder.Entity<Classes>()
                .Property(x => x.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .IsRequired();
            #endregion
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Entities.Mapping
{
    public class SubjectsMapping : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Subjects
            modelBuilder.Entity<Subjects>()
                .ToTable("subjects");
            #region Primary Keys
            modelBuilder.Entity<Subjects>()
                .HasKey(x => x.SubjectId)
                .HasName("SubjectId");
            #endregion
            #region Properties
                
            modelBuilder.Entity<Subjects>()
                .Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired();
            modelBuilder.Entity<Subjects>()
                .Property(x => x.Schedule)
                .HasColumnName("Schedule")
                .IsRequired();
            #endregion
            #endregion
        }
    }
}

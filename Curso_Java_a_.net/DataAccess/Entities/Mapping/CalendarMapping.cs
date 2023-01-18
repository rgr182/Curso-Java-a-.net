using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Entities.Mapping
{
    public class CalendarMapping : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Calendar
            modelBuilder.Entity<Calendar>()
                .ToTable("calendar");
            #endregion
            #region Primary Keys
            modelBuilder.Entity<Calendar>()
                .HasKey(x => x.Id)
                .HasName("Id");
            #endregion
            #region Properties
            modelBuilder.Entity<Calendar>()
                .Property(x => x.CalendarId)
                .HasColumnName("CalendarId")
                .IsRequired();
            modelBuilder.Entity<Calendar>()
                .Property(x => x.SubjectId)
                .HasColumnName("SubjectId")
                .IsRequired();
            modelBuilder.Entity<Calendar>()
                .Property(x => x.Gmail)
                .HasColumnName("Gmail")
                .IsRequired();
            modelBuilder.Entity<Calendar>()
                .Property(x => x.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();
            modelBuilder.Entity<Calendar>()
                .Property(x => x.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .IsRequired();
            #endregion
        }
    }
}

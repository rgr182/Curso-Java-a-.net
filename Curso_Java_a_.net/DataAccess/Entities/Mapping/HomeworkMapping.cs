using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Entities.Mapping
{
    public class HomeworkMapping : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Homework
            modelBuilder.Entity<Homework>()
                .ToTable("homework");
            #region Primary Keys
            modelBuilder.Entity<Homework>()
                .HasKey(x => x.Id)
                .HasName("id");
            #endregion
            #region Properties
            modelBuilder.Entity<Homework>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id")
                .IsRequired();
            modelBuilder.Entity<Homework>()
                .Property(x => x.StudentId)
                .HasColumnName("student_id")
                .IsRequired();
            modelBuilder.Entity<Homework>()
                .Property(x => x.ActivityId)
                .HasColumnName("activity_id")
                .IsRequired();
            modelBuilder.Entity<Homework>()
                .Property(x => x.Status)
                .HasColumnName("status")
                .IsRequired();
            modelBuilder.Entity<Homework>()
                .Property(x => x.Score)
                .HasColumnName("score")
                .IsRequired();
            modelBuilder.Entity<Homework>()
                .Property(x => x.FilePath)
                .HasColumnName("file_path")
                .IsRequired();
            modelBuilder.Entity<Homework>()
                .Property(x => x.UrlPath)
                .HasColumnName("url_path")
                .IsRequired();
            modelBuilder.Entity<Homework>()
                .Property(x => x.IsActive)
                .HasColumnName("is_active")
                .IsRequired();
            modelBuilder.Entity<Homework>()
                .Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
            modelBuilder.Entity<Homework>()
                .Property(x => x.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired();
            modelBuilder.Entity<Homework>()
                .Property(x => x.DeliveryDate)
                .HasColumnName("delivery_date")
                .IsRequired();
            modelBuilder.Entity<Homework>()
                .Property(x => x.ScoredDate)
                .HasColumnName("scored_date")
                .IsRequired();
            #endregion
            #endregion
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Entities.Mapping
{
    public class ActivityMapping : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Activity
            modelBuilder.Entity<Activity>()
                .ToTable("activity");
            #region Primary Keys
            modelBuilder.Entity<Activity>()
                .HasKey(x => x.Id)
                .HasName("id");
            #endregion
            #region Properties
            modelBuilder.Entity<Activity>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id")
                .IsRequired();
            modelBuilder.Entity<Activity>()
                .Property(x => x.TeacherId)
                .HasColumnName("teacher_id")
                .IsRequired();
            modelBuilder.Entity<Activity>()
                .Property(x => x.GroupId)
                .HasColumnName("group_id")
                .IsRequired();
            modelBuilder.Entity<Activity>()
                .Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired();
            modelBuilder.Entity<Activity>()
                .Property(x => x.Theme)
                .HasColumnName("theme")
                .IsRequired();
            modelBuilder.Entity<Activity>()
                .Property(x => x.Platform)
                .HasColumnName("platform")
                .IsRequired();
            modelBuilder.Entity<Activity>()
                .Property(x => x.Instructions)
                .HasColumnName("instructions")
                .IsRequired();
            modelBuilder.Entity<Activity>()
                .Property(x => x.FilePath)
                .HasColumnName("file_path")
                .IsRequired();
            modelBuilder.Entity<Activity>()
                .Property(x => x.UrlPath)
                .HasColumnName("url_path")
                .IsRequired();
            modelBuilder.Entity<Activity>()
                .Property(x => x.Resources)
                .HasColumnName("resources")
                .IsRequired();
            modelBuilder.Entity<Activity>()
                .Property(x => x.PublicDay)
                .HasColumnName("public_day")
                .IsRequired();
            modelBuilder.Entity<Activity>()
                .Property(x => x.FinishDate)
                .HasColumnName("finish_date")
                .IsRequired();
            modelBuilder.Entity<Activity>()
                .Property(x => x.IsActive)
                .HasColumnName("is_active")
                .IsRequired();
            modelBuilder.Entity<Activity>()
                .Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
            modelBuilder.Entity<Activity>()
                .Property(x => x.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired();
            modelBuilder.Entity<Activity>()
                .Property(x => x.SubjectId)
                .HasColumnName("subject_id")
                .IsRequired();
            #endregion
            #endregion
        }
    }
}

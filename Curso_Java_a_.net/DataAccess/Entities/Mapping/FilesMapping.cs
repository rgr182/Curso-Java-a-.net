using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Entities.Mapping
{
    public class FilesMapping : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Files
            modelBuilder.Entity<Files>()
                .ToTable("files");
            #region Primary Keys
            modelBuilder.Entity<Files>()
                .HasKey(x => x.Id)
                .HasName("id");
            #endregion
            #region Properties
            modelBuilder.Entity<Files>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id")
                .IsRequired();
            modelBuilder.Entity<Files>()
                .Property(x => x.UserId)
                .HasColumnName("user_id")
                .IsRequired();
            modelBuilder.Entity<Files>()
                .Property(x => x.FileUrl)
                .HasColumnName("file_url")
                .IsRequired();
            modelBuilder.Entity<Files>()
                .Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
            modelBuilder.Entity<Files>()
                .Property(x => x.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired();
            #endregion
            #endregion
        }
    }
}

using Microsoft.EntityFrameworkCore;
namespace Curso_Java_a_.net.DataAccess.Entities.Mapping
{
    public class AvatarMapping :DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Avatar
            modelBuilder.Entity<Avatar>()
                .ToTable("avatar");
            #region Primary Keys
            modelBuilder.Entity<Avatar>()
                .HasKey(x => x.Id)
                .HasName("id");
            #endregion
            #region Properties

            modelBuilder.Entity<Avatar>()
                .Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired();
            modelBuilder.Entity<Avatar>()
                .Property(x => x.Description)
                .HasColumnName("description");
            modelBuilder.Entity<Avatar>()
                .Property(x => x.Type)
                .HasColumnName("type")
                .IsRequired();
            modelBuilder.Entity<Avatar>()
                .Property(x => x.Path)
                .HasColumnName("path")
                .IsRequired();
            modelBuilder.Entity<Avatar>()
                .Property(x => x.CreatedAt)
                .HasColumnName("created_at");
            modelBuilder.Entity<Avatar>()
            .Property(x => x.UpdatedAt)
            .HasColumnName("updated_at");
            #endregion
            #endregion

        }
    }
}

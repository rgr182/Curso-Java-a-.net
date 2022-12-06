using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Entities.Mapping
{
    public class AvatarUsersMapping : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region AvatarUsers
            modelBuilder.Entity<AvatarUsers>()
                .ToTable("avatar_users");
            #region Primary Keys
            modelBuilder.Entity<AvatarUsers>()
                .HasKey(x => x.Id)
                .HasName("id");
            #endregion
            #region Properties
            modelBuilder.Entity<AvatarUsers>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id")
                .IsRequired();
            modelBuilder.Entity<AvatarUsers>()
                .Property(x => x.UserId)
                .HasColumnName("user_id")
                .IsRequired();
            modelBuilder.Entity<AvatarUsers>()
                .Property(x => x.AvatarId)
                .HasColumnName("avatar_id")
                .IsRequired();
            modelBuilder.Entity<AvatarUsers>()
                .Property(x => x.CustomName)
                .HasColumnName("custom_name")
                .IsRequired();
            modelBuilder.Entity<AvatarUsers>()
                .Property(x => x.AvatarPath)
                .HasColumnName("avatar_path")
                .IsRequired();
            modelBuilder.Entity<AvatarUsers>()
                .Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
            modelBuilder.Entity<AvatarUsers>()
                .Property(x => x.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired();
            #endregion
            #endregion
        }
    }
}

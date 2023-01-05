using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Entities.Mapping
{
    public class UsersMapping : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region users
            modelBuilder.Entity<Users>()
                .ToTable("users")
                .HasKey(x => x.id);
            #region Primary Keys
            modelBuilder.Entity<Users>()
                .HasKey(x => x.id)
                .HasName("id");
            #endregion
            #region Properties
            modelBuilder.Entity<Users>()
                .Property(x => x.id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(x => x.AppUserId)
                .HasColumnName("AppUserId")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(x => x.Uuid)
                .HasColumnName("uuid")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(x => x.Username)
                .HasColumnName("username")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(x => x.SecondName)
                .HasColumnName("second_name")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(x => x.LastName)
                .HasColumnName("last_name")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(x => x.SecondLastName)
                .HasColumnName("second_last_name")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(x => x.SchoolId)
                .HasColumnName("school_id")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(x => x.CompanyId)
                .HasColumnName("company_id")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(x => x.SchoolKeyId)
                .HasColumnName("school_key_id")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(x => x.RoleId)
                .HasColumnName("role_id")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(x => x.LevelId)
                .HasColumnName("level_id")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(x => x.TutorId)
                .HasColumnName("tutor_id")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(x => x.Email)
                .HasColumnName("email")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(x => x.Grade)
                .HasColumnName("grade")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(x => x.Avatar)
                .HasColumnName("avatar")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(x => x.Password)
                .HasColumnName("password")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(x => x.IsActive)
                .HasColumnName("is_active")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(x => x.MemberSince)
                .HasColumnName("member_since")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(x => x.LastLogin)
                .HasColumnName("last_login")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(x => x.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired();
            #endregion
            #endregion
            


        }
    }
}

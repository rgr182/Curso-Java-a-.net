using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Entities.Mapping
{
    public class UsersMapping : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Users
            modelBuilder.Entity<Users>()
                .ToTable("users");
            #region Primary Keys
            modelBuilder.Entity<Users>()
                .HasKey(x => x.UserId)
                .HasName("UserId");
            #endregion
            #region Properties
            modelBuilder.Entity<Users>()
                .Property(x => x.UserId)
                .ValueGeneratedOnAdd()
                .HasColumnName("UserId")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(x => x.Gender)
                .HasColumnName("Gender")
                .IsRequired();
            modelBuilder.Entity<Users>().
                Property(x => x.Email)
                .HasColumnName("Email")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(x => x.Age)
                .HasColumnName("Age")
                .IsRequired();
            modelBuilder.Entity<Users>()
                .Property(x => x.Password)
                .HasColumnName("Password")
                .IsRequired();
            #endregion
            #endregion
        }
    }
}

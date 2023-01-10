using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Entities.Mapping
{
    public class UsersSubjectsMapping : DbContext
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
            #region UsersSubjects
            modelBuilder.Entity<UsersSubjects>()
                .ToTable("userssubjects");
            #region Primary Keys
            modelBuilder.Entity<UsersSubjects>()
                .HasKey(x => x.SubjectIdUsuario)
                .HasName("SubjectIdUsuario");
            #endregion
            #region Properties
            modelBuilder.Entity<UsersSubjects>()
                .Property(x => x.SubjectIdUsuario)
                .ValueGeneratedOnAdd()
                .HasColumnName("SubjectIdUsuario")
                .IsRequired();
            modelBuilder.Entity<UsersSubjects>()
                .Property(x => x.SubjectId)
                .HasColumnName("SubjectId")
                .IsRequired();
            modelBuilder.Entity<UsersSubjects>()
                .Property(x => x.UserId)
                .HasColumnName("UserId")
                .IsRequired();
            modelBuilder.Entity<UsersSubjects>()
                .Property(x => x.Grade)
                .HasColumnName("Grade")
                .IsRequired();
            #endregion
            #endregion
        }
    }
}

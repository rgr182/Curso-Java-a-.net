using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Entities.Mapping
{
    public class BadgeRelationsMapping : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region BadgesRelations
            modelBuilder.Entity<BadgeRelations>()
                .ToTable("badges_relations_");
            #region Primary Keys
            modelBuilder.Entity<BadgeRelations>()
                .HasKey(x => x.Id)
                .HasName("id");
            #endregion
            #region Properties
            modelBuilder.Entity<BadgeRelations>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id")
                .IsRequired();
            modelBuilder.Entity<BadgeRelations>()
                .Property(x => x.BadgeId)
                .HasColumnName("badge_id")
                .IsRequired();
            modelBuilder.Entity<BadgeRelations>()
                .Property(x => x.TaskId)
                .HasColumnName("task_id")
                .IsRequired();
            modelBuilder.Entity<BadgeRelations>()
                .Property(x => x.StudentId)
                .HasColumnName("student_id")
                .IsRequired();
            modelBuilder.Entity<BadgeRelations>()
                .Property(x => x.TeacherId)
                .HasColumnName("teacher_id")
                .IsRequired();
            modelBuilder.Entity<BadgeRelations>()
                .Property(x => x.BadgesData)
                .HasColumnName("badges_data")
                .IsRequired();
            #endregion
            #endregion
        }
    }
}

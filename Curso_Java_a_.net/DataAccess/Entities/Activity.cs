using System.ComponentModel.DataAnnotations;

namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class Activity
    {
        [Key]
        public long Id { get; set; }
        public long TeacherId { get; set; }
        public long GroupId { get; set; }
        public string Name { get; set; }
        public string Theme { get; set; }
        public string Platform { get; set; }
        public string Instructions { get; set; }
        public string FilePath { get; set; }
        public string UrlPath { get; set; }
        public string Resources { get; set; }
        public DateTime PublicDay { get; set; }
        public DateTime FinishDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long SubjectId { get; set; }
    }
}

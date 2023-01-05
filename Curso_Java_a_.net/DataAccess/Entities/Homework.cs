namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class Homework
    {
        public long Id { get; set; }
        public long StudentId { get; set; }
        public long ActivityId { get; set; }
        public string Status { get; set; }
        public decimal Score { get; set; }
        public string FilePath { get; set; }
        public string UrlPath { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime ScoredDate { get; set; }
    }
}

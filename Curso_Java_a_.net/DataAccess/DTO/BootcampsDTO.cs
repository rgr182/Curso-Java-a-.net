namespace Curso_Java_a_.net.DataAccess.DTO
{
    public class BootcampsDTO
    {
        public int BootcampId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Feedback1 { get; set; }
        public string? Feedback2 { get; set; }
        public string? Feedback3 { get; set; }
        public int StatusId { get; set; }
        public int CurrentLocationId { get; set; }
    }
}

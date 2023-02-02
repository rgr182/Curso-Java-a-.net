namespace Curso_Java_a_.net.DataAccess.DTO
{
    public class BootcampCandidatesDTO
    {
        public int BootcampCandidateId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Feedback { get; set; }
        public int StatusId { get; set; }
        public int BootcampId { get; set; }
    }
}

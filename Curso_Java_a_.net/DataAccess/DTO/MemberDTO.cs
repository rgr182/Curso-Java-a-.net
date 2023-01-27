namespace Curso_Java_a_.net.DataAccess.DTO
{
    public class MemberDTO
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string Email { get; set; }
        public int CurrentLocationId { get; set; }
        public DateTime MemberRegistration { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string CV { get; set; }
        public bool? isAdmin { get; set; }
        public bool? isMentor { get; set; }
        public string? Feedback { get; set; }
    }
}

namespace Curso_Java_a_.net.DataAccess.DTO
{
    public class MemberDTO
    {
        public int MembersId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public int CurrentLocationId { get; set; }
        public DateTime MemberRegistratior { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public string PhoneNumber { get; set; }
        //public string CV { get; set; }
    }
}

namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class User
    {
        public long Id { get; set; }
        public long AppUserId { get; set; }
        public string UUID { get; set; }
        public string UserName { get; set; }
        public long RoleId { get; set; }
        public long LevelId { get; set; }
        public long TutorId { get; set; }
        public long SchoolId { get; set; }
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string Email { get; set; }
        public long Grade { get; set; }
        public string Avatar { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
    }
}

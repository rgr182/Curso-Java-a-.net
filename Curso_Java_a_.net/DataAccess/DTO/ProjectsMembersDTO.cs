namespace Curso_Java_a_.net.DataAccess.DTO
{
    public class ProjectsMembersDTO
    {
        public int ProjectMemberId { get; set; }
        public int MemberId { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string City { get; set; }
    }
}

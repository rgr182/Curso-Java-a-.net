namespace Curso_Java_a_.net.DataAccess.DTO
{
    public class ProjectsDTO
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StatusId { get; set; }
        public int CurrentLocationId { get; set; }
    }
}

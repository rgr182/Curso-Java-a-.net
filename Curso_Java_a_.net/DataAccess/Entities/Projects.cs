using System.ComponentModel.DataAnnotations;

namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class Projects
    {
        [Key]
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime EndDate { get; set; } = DateTime.UtcNow;
        public int StatusId { get; set; }
        public int CurrentLocationId { get; set; }
     }
}

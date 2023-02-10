using System.ComponentModel.DataAnnotations;

namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class TechMembers
    {
        [Key]
        public int TechMemberId { get; set; }
        public int SeniorityId { get; set; }
        public int MemberId { get; set; }
        public int TechnologyId { get; set; }
    }
}

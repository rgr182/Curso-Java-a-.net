using System.ComponentModel.DataAnnotations;

namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class ProjectsMembers
    {
        [Key]
        public int ProjectMemberId { get; set; }
        public int MemberId { get; set; }
        public int ProjectId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Curso_Java_a_.net.DataAccess.DTO
{
    public class TechMembersDTO
    {
        [Key]
        public int TechMemberId { get; set; }
        public int MemberId { get; set; }
        public string Tech { get; set; }
        public string Seniority { get; set; }
    }
}

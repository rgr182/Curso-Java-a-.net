using System.ComponentModel.DataAnnotations;

namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class UsersSubjects
    {
        [Key]
        public long SubjectIdUsuario { get; set; }
        public long SubjectId { get; set; }
        public long UserId { get; set; }
        public int Grade { get; set; }
    }
}

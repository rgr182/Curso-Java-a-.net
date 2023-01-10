using System.ComponentModel.DataAnnotations;

namespace Curso_Java_a_.net.DataAccess.Entities
{
    public partial class Session
    {
        [Key]        
        public long UserId { get; set; }

        [Required]

        public string UserToken { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public DateTime ExpirationDate { get; set; }
    }
}

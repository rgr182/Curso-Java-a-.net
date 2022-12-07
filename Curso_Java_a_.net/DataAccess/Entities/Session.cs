using System.ComponentModel.DataAnnotations;

namespace Curso_Java_a_.net.DataAccess.Entities
{
    public partial class Session
    {
        [Key]
        public int SessionId { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(250)]

        public String UserToken { get; set; } = new Guid().ToString();

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public DateTime ExpirationDate { get; set; }
    }
}

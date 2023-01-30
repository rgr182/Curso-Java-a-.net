using System.ComponentModel.DataAnnotations;

namespace Curso_Java_a_.net.DataAccess.Entities
{
    public partial class Sessions
    {
        [Key]
        public int SessionId { get; set; }

        public int MemberId { get; set; }

        [Required]

        public string UserToken { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public DateTime ExpirationDate { get; set; }
        public bool isAdmin { get; set; }
    }
}

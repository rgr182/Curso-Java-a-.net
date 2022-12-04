using System.ComponentModel.DataAnnotations;

namespace Curso_Java_a_.net.DataAccess.Entities
{
    public partial class Tokens
    {

        [Key]
        public int TokenId { get; set; }

        //public int UserId { get; set; }


        [Required]
        [StringLength(250)]

        public string? RealToken { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ExpiresDate { get; set; }

       






    }

}

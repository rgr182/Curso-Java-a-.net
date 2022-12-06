using System.ComponentModel.DataAnnotations;

namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class Avatar
    {
        public long Id { get; set; }  
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public string Path { get; set; }        
        public DateTime CreatedAt { get; set; }      
        public DateTime UpdatedAt { get;set; }
    }
}

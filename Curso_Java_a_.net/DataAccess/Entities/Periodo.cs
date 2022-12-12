namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class Periodos
    {
        public long Id { get; set; }
        public int Periodo { get; set; }
        public string Name { get; set; }  
        public string Description { get; set; }
        public byte IsCurrent { get; set; }
        public byte IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
    }
}

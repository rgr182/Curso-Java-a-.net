namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class DigitalResources
    {
        public long Id { get; set; }
        public int Bloque { get; set; }
        public int Grade { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public string UrlResource { get; set; }
        public long IdMateriaBase { get; set; }
        public long IdCategory { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

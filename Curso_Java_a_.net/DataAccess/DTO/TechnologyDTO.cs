using System.Text.Json.Serialization;

namespace Curso_Java_a_.net.DataAccess.DTO
{
    public class TechnologyDTO
    {
        [JsonIgnore]
        public int TechnologyId { get; set; }
        public string Name { get; set; }
    }
}

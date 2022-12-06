using NuGet.Protocol.Plugins;

namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class BadgeRelations
    {
        public long Id { get; set; }
        public long BadgeId { get; set; }
        public long TaskId { get; set; }
        public long StudentId { get; set; }
        public long TeacherId { get; set; }
        public string BadgesData { get; set; }
    }
}

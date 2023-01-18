namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class NonPlannedResources
    {
        public long NonPlannedResourcesId { get; set; }
        public long ClassId { get; set; }
        public long CalendarId { get; set; }
        public long ResourceId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

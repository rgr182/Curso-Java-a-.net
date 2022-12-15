using System.ComponentModel;

namespace Curso_Java_a_.net.DataAccess.Entities
{
    public class SchoolKey
    {
        public long Id { get; set; }
        public long SchoolId { get; set; }
        public string LicenseId { get; set; }
        public long RoleId { get; set; }
        public bool IsActive { get; set; }
        public DateTime EndOfLicense { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //public virtual License License { get; set; }
        public virtual Role Role { get; set; }
        public virtual School School { get; set; }
    }
}

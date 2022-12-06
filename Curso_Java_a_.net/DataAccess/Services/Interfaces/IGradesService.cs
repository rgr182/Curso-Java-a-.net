using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Services.Interfaces
{
    public interface IGradesService
    {
        public Task<List<Grades>> GetGradesByMembersByIdAndPeriod(int MemberId, string Period);
    }
}

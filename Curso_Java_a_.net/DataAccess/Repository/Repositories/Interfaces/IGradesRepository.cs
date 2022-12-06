using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{
    public interface IGradesRepository
    {
        public Task<List<Grades>> GetGradesByMembersByIdAndPeriod(int MemberId, string Period);
        public void PostGrades(Grades user);
        public void PutGrades(Grades user);
        public void DeleteGrades(int GradesId);
    }
}

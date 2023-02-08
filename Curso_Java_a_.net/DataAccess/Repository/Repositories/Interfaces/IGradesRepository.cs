using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{
    public interface IGradesRepository
    {
        public Task<Grades> GetGrade(int memberId);
        public Task<List<Grades>> GetGrades();
        public Task<Grades> PostGradesAsync(Grades memberId);
        public Task<Grades> UpdateGradesAsync(Grades memberId);
        public Task<Grades> DeleteGrades(int memberId);
    }
}

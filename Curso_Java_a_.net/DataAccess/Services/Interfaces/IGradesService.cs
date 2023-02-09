using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Services.Interfaces
{
    public interface IGradesService
    {
        public Task<Grades> GetGrade(int memberId);
        public Task<List<Grades>> GetGrades();
        public Task<Grades> PostGradesAsync(Grades memberId);
        public Task<Grades> UpdateGradesAsync(Grades memberId);
        public Task<Grades> DeleteGrades(int memberId);
    }
}

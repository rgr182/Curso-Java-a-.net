using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class GradesRepository : IGradesRepository
    {
        internal SchoolSystemContext _context;
        public GradesRepository(SchoolSystemContext context)
        {
            _context = context;
        }
        public async Task<Grades> DeleteGrades(int memberId)
        {
            Grades grades = _context.Grades.Find(memberId);
            _context.Grades.Remove(grades);
            _context.SaveChanges();
            return grades;
        }
        public Task<Grades> GetGrade(int memberId) =>
                  _context.Grades
                  .Where(g => g.MemberId == memberId)
                       .FirstOrDefaultAsync();
        public async Task<List<Grades>> GetGrades() =>
            await _context.Grades.ToListAsync();

        public async Task<Grades> PostGradesAsync(Grades memberId)
        {
            await _context.Grades.AddAsync(memberId);
            await _context.SaveChangesAsync();
            return memberId;
        }
        public async Task<Grades> UpdateGradesAsync(Grades memberId)
        {
            Grades grades = _context.Grades.Find(memberId);
            _context.Grades.Update(grades);
            _context.SaveChanges();
            return grades;
        }
    }
}

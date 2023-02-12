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
        public async Task<Grades> DeleteGrades(int gradeId)
        {
            Grades grades = await _context.Grades.FindAsync(gradeId);
            if (grades == null)
            {
                return null;
            }
                _context.Grades.Remove(grades);
            await _context.SaveChangesAsync();
            return grades;
        }
        public async Task<Grades> GetGrade(int memberId) =>
                  await _context.Grades
                  .Where(g => g.MemberId == memberId)
                       .FirstOrDefaultAsync();
        public async Task<List<Grades>> GetGrades() =>
            await _context.Grades.ToListAsync();

        public async Task<Grades> PostGradesAsync(Grades grade)
        {
            await _context.Grades.AddAsync(grade);
            await _context.SaveChangesAsync();
            return grade;
        }
        public async Task<Grades> UpdateGradesAsync(Grades grade)
        {
            Grades grades = await _context.Grades.FindAsync(grade.GradesId);
            if (grades == null)
            {
                return null;
            }
            _context.Grades.Update(grades);
            await _context.SaveChangesAsync();
            return grades;
        }
    }
}

using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class GradesRepository : IGradesRepository
    {
        internal SchoolSystemContext _context;
        public GradesRepository(SchoolSystemContext context)     {
            _context = context;
        }

        public void DeleteGrades(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Grades>>GetGradesByMembersByIdAndPeriod(int MemberId, string Period)
        {
           return  _context.Grades
                  .Where(g => g.MembersId == MemberId &
                       g.Period.ToLower() == Period.ToLower())
                       .ToListAsync();
        }

        public async Task PostGradesAsync(Grades grade)
        {
            await _context.Grades.AddAsync(grade);
            await _context.SaveChangesAsync();
        }

        public async Task PutGradesAsync(Grades grade)
        {
            _context.Grades.Attach(grade);
            _context.Entry(grade).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

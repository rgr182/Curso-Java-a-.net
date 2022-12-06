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

        public void PostGrades(Grades user)
        {
            throw new NotImplementedException();
        }

        public void PutGrades(Grades user)
        {
            throw new NotImplementedException();
        }
    }
}

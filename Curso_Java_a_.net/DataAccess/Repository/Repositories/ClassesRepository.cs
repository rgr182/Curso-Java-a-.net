using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class ClassesRepository //: IClassesRepository
    {
        internal SchoolSystemTestContext _context;
        public ClassesRepository(SchoolSystemTestContext context)
        {
            _context = context;
        }

        //public Task<Groups> GetGroupStudent()
        //{
        //    //return _context.Groups
        //    //    .Where(x => x.SubjectId == Id)
        //    //    .FirstOrDefaultAsync();
        //}
    }
}

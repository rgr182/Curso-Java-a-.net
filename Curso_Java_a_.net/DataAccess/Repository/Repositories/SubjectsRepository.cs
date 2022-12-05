using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class SubjectsRepository : ISubjectsRepository
    {
        internal SchoolSystemTestContext _context;
        public SubjectsRepository(SchoolSystemTestContext context)
        {
            _context = context;
        }

        public void DeleteSubject(int id)
        {
            Subjects subject = _context.Subjects.Find(id);
            _context.Subjects.Remove(subject);
            _context.SaveChanges();
        }
        public Task<Subjects> GetSubjectById(int id)
        {
            return _context.Subjects
                .Where(x => x.SubjectId == id)
                .FirstOrDefaultAsync();
        }

        public void PostSubject(Subjects subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
        }
        public void PutSubject(Subjects subject)
        {
            Subjects sub = _context.Subjects.Find(subject.SubjectId);
            sub.Name = subject.Name;
            sub.Schedule = subject.Schedule;
            _context.SaveChanges();
        }
    }
}

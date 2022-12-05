using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class UsersSubjectsRepository : IUsersSubjectsRepository
    {
        internal SchoolSystemTestContext _context;
        public UsersSubjectsRepository(SchoolSystemTestContext context)
        {
            _context = context;
        }
        public void DeleteUserSubject(int id)
        {
            UsersSubjects userSubject = _context.UsersSubjects.Find(id);
            _context.UsersSubjects.Remove(userSubject);
            _context.SaveChanges();
        }
        public Task<UsersSubjects> GetUserSubjectById(int id)
        {
            return _context.UsersSubjects
                .Where(x => x.SubjectIdUsuario == id)
                .FirstOrDefaultAsync();
        }
        public Task<List<result>> GetUserSubjects(int id)
        {
            var  query= from us in _context.UsersSubjects
                   join s in _context.Subjects
                       on us.SubjectId equals s.SubjectId
                   join u in _context.Users
                       on us.UserId equals u.UserId
                   where us.UserId == id
                   select new
                   {
                       id = us.SubjectIdUsuario,
                       name = u.Name,
                       materia = s.Name,
                       horario = s.Schedule,
                       calificacion = us.Grade
                   };
            var result = query.Select(x => new result
            {
                Id = x.id,
                Name = x.name,
                Materia = x.materia,
                Horario = x.horario,
                Calificacion = x.calificacion
            }).ToListAsync();
            return result;
        }
        

        public void PostUserSubject(UsersSubjects userSubject)
        {
            _context.UsersSubjects.Add(userSubject);
            _context.SaveChanges();
        }
        public void PutUserSubject(UsersSubjects userSubject)
        {
            UsersSubjects us = _context.UsersSubjects.Find(userSubject.SubjectIdUsuario);
            us.SubjectId = userSubject.SubjectId;
            us.UserId = userSubject.UserId;
            _context.SaveChanges();
        }
    }
}

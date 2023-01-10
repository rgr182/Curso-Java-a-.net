using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class TechnologieRepository : ITechnologiesRepository
    {
        internal SchoolSystemContext _context;
        public TechnologieRepository(SchoolSystemContext context)     {
            _context = context;
        }

        public void DeleteTechnologies(Tecnologies name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tecnologies>> GetTechnologiesByName(string name)
        {
           return  _context.Tecnologies
                 .ToListAsync();
        }

        public async Task<Tecnologies> PostTechnologiesAsync(Tecnologies name)
        {
            await _context.Tecnologies.AddAsync(name);
            await _context.SaveChangesAsync();
            return name;
        }

        public async Task<Tecnologies> UpdateTechnologiesAsync(Tecnologies name)
        {
            var res = "";

            Tecnologies Name = _context.Tecnologies.Find(name);
            members1.Name = members.Name;
            members1.FirstName = members.FirstName;
            members1.SecondName = members.SecondName;
            members1.CurrentLocationId = members.CurrentLocationId;
            members1.MemberRegistratior = members.MemberRegistratior;
            members1.Email = members.Email;
            members1.User = members.User;
            members1.Password = members.Password;
            _context.Members.Update(members1);
            await _context.SaveChangesAsync();
            return members1;
        }
    }
}

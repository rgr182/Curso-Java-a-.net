using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Repository.Repostitories
{

    public interface IMateriasUsuarioRepository
    {
        public Task<MateriasUsuarios> GetEscuelaByIdAsync(int id);
    }


    public class MateriasUsuarioRepository : IMateriasUsuarioRepository
    {
        internal TrainingSystemContext _context;

        public MateriasUsuarioRepository(TrainingSystemContext context)
        {
            _context = context;
        }

        public Task<MateriasUsuarios> GetEscuelaByIdAsync(int id)
        {           

            return _context.MateriasUsuarios
                     .Where(e => e.IdMateria == id)
                     .FirstOrDefaultAsync<MateriasUsuarios>();       
        }
    }
}

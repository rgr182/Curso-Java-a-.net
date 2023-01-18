using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{
    public interface ITechnologiesRepository
    {
        public Task<List<Technologies>> GetTechnologiesByName(string name);
        public Task<Technologies> PostTechnologiesAsync(TechnologyDTO name);
        public Task<Technologies> UpdateTechnologiesAsync(TechnologyDTO name);
        public Task DeleteTechnologiesById(int technologyId);
    }
}

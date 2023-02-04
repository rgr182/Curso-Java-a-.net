using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{
    public interface ITechnologiesRepository
    {
        public Task<Technologies> GetTechnologyAsync(int technologyId);
        public Task<List<Technologies>> GetTechnologiesAsync();
        public Task<Technologies> PostTechnologiesAsync(TechnologyDTO tech);
        public Task<Technologies> UpdateTechnologiesAsync(TechnologyDTO tech);
        public Task<Technologies> DeleteTechnologiesById(int technologyId);
    }
}

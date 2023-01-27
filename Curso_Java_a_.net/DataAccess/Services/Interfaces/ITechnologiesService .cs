using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Services.Interfaces
{
    public interface ITechnologiesService
    {
        public Task<List<Technologies>> GetTechnologiesByNameAsync(string name);
        public Task<Technologies> PostTechnologiesAsync(TechnologyDTO name);
        public Task<Technologies> UpdateTechnologiesAsync(TechnologyDTO name);
        public Task DeleteTechnologiesById(int technologyId);
    }
}

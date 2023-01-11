using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Services.Interfaces
{
    public interface ITechnologiesService
    {
        public Task<List<Technologies>> GetTechnologiesByName(string name);
        public Task<Technologies> PostTechnologiesAsync(TechnologyDTO name);
        public Task<Technologies> PutTechnologiesAsync(TechnologyDTO name);
        public Task<Technologies> DeleteTechnologiesById(int technologyId);
       
    }

}

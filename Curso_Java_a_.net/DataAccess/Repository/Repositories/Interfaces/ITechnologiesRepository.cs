using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{
    public interface ITechnologiesRepository
    {
        public Task<List<Tecnologies>> GetTechnologiesByName(string name);
        public Task<Tecnologies> PostTechnologiesAsync(Tecnologies name);
        public Task<Tecnologies> UpdateTechnologiesAsync(Tecnologies name);
        public void DeleteTechnologies(Tecnologies name);
    }
}

using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Services.Interfaces
{
    public interface ITechnologiesService
    {
        public  Task<List<Technologies>> GetTechnologiesByName(string name);
        public Task PostTechnologiesAsync(TechnologyDTO name);
        public Task PutTechnologiesAsync(Technologies name);
        public void DeleteTechnologies(Technologies name);
       
    }

}

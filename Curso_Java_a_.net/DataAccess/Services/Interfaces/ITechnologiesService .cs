using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Services.Interfaces
{
    public interface ITechnologiesService
    {
        public  Task<List<Tecnologies>> GetTechnologiesByName(string name);
        public Task PostTechnologiesAsync(Tecnologies name);
        public Task PutTechnologiesAsync(Tecnologies name);
        public void DeleteTechnologies(Tecnologies name);
       
    }

}

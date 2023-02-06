using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{
    public interface IBootcampsRepository
    {
        public Task<Bootcamps> GetBootcamps(int bootcampId);
        public Task<List<Bootcamps>> GetBootcamps();
        public Task<Bootcamps> PostBootcamps(BootcampsDTO name);
        public Task<Bootcamps> UpdateBootcamps(BootcampsDTO name);
        public Task<Bootcamps> DeleteBootcamps(int bootcampId);
    }
}

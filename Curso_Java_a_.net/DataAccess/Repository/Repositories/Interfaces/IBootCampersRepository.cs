using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{
    public interface IBootCampersRepository
    {
        public Task<BootCampers> GetBootCamperByUserAndPassword(string user, string pass);
        public Task SaveBootCamperAsync(BootCampers member);
        public Task<BootCampers> GetBootCamper(int id);
        public Task<List<BootCampers>> GetBootCamper();
        public Task<BootCampers> PostBootCamper(BootCamperDTO member);
        public Task<BootCampers> UpdateBootCamper(BootCamperDTO member);
        public Task<BootCampers> DeleteBootCamper(int BootCamperId);
    }
}

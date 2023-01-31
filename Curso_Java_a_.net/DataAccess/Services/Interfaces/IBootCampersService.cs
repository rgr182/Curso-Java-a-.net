using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Services.Interfaces
{
    public interface IBootCampersService
    {
        public Task<BootCampers> GetBootCamperByUserAndPassword(string user, string pass);
        public Task<BootCampers> SaveBootCampersAsync(BootCampers member);
        public Task<BootCampers> GetBootCamper(int memberId);
        public Task<List<BootCampers>> GetBootCampers();
        public Task<BootCamperDTO> PostBootCampers(BootCamperDTO member);
        public Task<BootCampers> UpdateBootCampers(BootCamperDTO member);
        public Task<BootCampers> DeleteBootCampers(int BootCamperId);
    }
}

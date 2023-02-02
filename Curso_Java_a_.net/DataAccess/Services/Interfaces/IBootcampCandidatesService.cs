using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Services.Interfaces
{
    public interface IBootcampCandidatesService
    {
        public Task<List<BootcampCandidates>> GetBootcampCandidate(int bootcampCandidateId);
        public Task<BootcampCandidates> PostBootcampCandidate(BootcampCandidatesDTO name);
        public Task<BootcampCandidates> UpdateBootcampCandidate(BootcampCandidatesDTO name);
        public Task<BootcampCandidates> DeleteBootcampCandidate(int bootcampCandidateId);
    }
}

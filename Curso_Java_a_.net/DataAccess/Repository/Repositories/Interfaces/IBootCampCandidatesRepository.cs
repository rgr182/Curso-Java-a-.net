using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{
    public interface IBootcampCandidatesRepository
    {
        public Task<BootcampCandidates> GetBootcampCandidate(int bootcampCandidateId);
        public Task<List<BootcampCandidates>> GetBootcampCandidates();
        public Task<BootcampCandidates> PostBootcampCandidate(BootcampCandidatesDTO name);
        public Task<BootcampCandidates> UpdateBootcampCandidate(BootcampCandidatesDTO name);
        public Task<BootcampCandidates> DeleteBootcampCandidate(int bootcampCandidateId);
    }
}

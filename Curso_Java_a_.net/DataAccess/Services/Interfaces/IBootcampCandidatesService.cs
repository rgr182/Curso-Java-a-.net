using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Services.Interfaces
{
    public interface IBootcampCandidatesService
    {
        public Task<BootcampCandidates> GetBootcampCandidate(int bootcampCandidateId);
        public Task<List<BootcampCandidates>> GetBootcampCandidates();
        public Task<BootcampCandidates> PostBootcampCandidate(BootcampCandidates bootcampCandidateId);
        public Task<BootcampCandidates> UpdateBootcampCandidate(BootcampCandidates bootcampCandidateId);
        public Task<BootcampCandidates> DeleteBootcampCandidate(int bootcampCandidateId);
    }
}

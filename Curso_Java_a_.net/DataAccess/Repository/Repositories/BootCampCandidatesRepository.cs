using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class BootCampCandidatesRepository : IBootcampCandidatesRepository
    {
        internal SchoolSystemContext _context;
        public BootCampCandidatesRepository(SchoolSystemContext context)
        {
            _context = context;
        }

        public async Task<List<BootcampCandidates>> GetBootcampCandidates()
        {
            return await _context.BootcampCandidates.ToListAsync();
        }

        public async Task<BootcampCandidates> GetBootcampCandidate(int bootcampCandidateId) =>
            await _context.BootcampCandidates
           .Where(x => x.BootcampCandidateId == bootcampCandidateId)
              .FirstOrDefaultAsync();

        public async Task<BootcampCandidates> PostBootcampCandidate(BootcampCandidatesDTO bootcampCandidateId)
        {
            var bootcampCandidate = bootcampCandidateId.Map();
            await _context.BootcampCandidates.AddAsync(bootcampCandidate);
            await _context.SaveChangesAsync();
            return bootcampCandidate;
        }

        public async Task<BootcampCandidates> UpdateBootcampCandidate(BootcampCandidatesDTO bootcampCandidateId)
        {
            var bootcampCandidate = bootcampCandidateId.Map();
            _context.BootcampCandidates.Update(bootcampCandidate);
            await _context.SaveChangesAsync();
            return bootcampCandidate;
        }

        public async Task<BootcampCandidates> DeleteBootcampCandidate(int bootcampCandidateId)
        {
            BootcampCandidates bootcampCandidate = await _context.BootcampCandidates.FindAsync(bootcampCandidateId);
            if (bootcampCandidate == null)
            {
                return null;
            }
            _context.BootcampCandidates.Remove(bootcampCandidate);
            await _context.SaveChangesAsync();
            return bootcampCandidate;
        }

        public async Task<List<BootcampCandidatesDTO>> bootcampsCandidates()
        {
            string connstring, sql;
            connstring = Environment.GetEnvironmentVariable("Connection");
            sql = $"EXEC sp_getBootcampers";
            List<BootcampCandidatesDTO> bootcampCandidatesDTO = new List<BootcampCandidatesDTO>();

            using (var connection = new SqlConnection(connstring))
            {
                connection.Open();
                bootcampCandidatesDTO = (List<BootcampCandidatesDTO>)connection.Query<BootcampCandidatesDTO>(sql);
            }
            return bootcampCandidatesDTO;
        }
        public async Task<List<BootcampCandidatesDTO>> bootcampsCandidatesByBootcampId(int bootcampId)
        {
            string connstring, sql;
            connstring = Environment.GetEnvironmentVariable("Connection");
            List<BootcampCandidatesDTO> bootcampCandidatesDTO = new List<BootcampCandidatesDTO>(bootcampId);

            using (var connection = new SqlConnection(connstring))
            {
                var parameters = new { BootcampId = bootcampId };
                var candidates = await connection.QueryAsync<BootcampCandidatesDTO>(
                    "sp_getBootcampersById",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return candidates.ToList();
            }
        }
    }
}

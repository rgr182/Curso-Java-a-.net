using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;

namespace Curso_Java_a_.net.DataAccess.Services
{
    public class GradesService : IGradesService
    {
        readonly ILogger<GradesService> _logger;
        IGradesRepository _gradesRepository;
        public GradesService(IGradesRepository gradesRepository, ILogger<GradesService> logger)
        {
            _gradesRepository = gradesRepository;
            _logger = logger;
        }

        public async Task<List<Grades>> GetGradesByMembersByIdAndPeriod(int MemberId, string Period)
        {
            return await _gradesRepository.GetGradesByMembersByIdAndPeriod(MemberId, Period);
        }
    }
}

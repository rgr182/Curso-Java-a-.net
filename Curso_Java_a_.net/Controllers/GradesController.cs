using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Mvc;
using Curso_Java_a_.net.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Curso_Java_a_.net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GradesController : ControllerBase
    {
        public readonly IGradesService _gradesService;
        
        public ILogger<GradesController> _logger;

        public GradesController(IGradesService gradesService, ILogger<GradesController> logger)
        {
            _gradesService = gradesService;
            _logger = logger;
        }

        /// <summary>
        /// This endpoint is used to provide grades related to different categories just like 
        /// English, Tech , Soft Skills... etc
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/GetGrades")]
        public async Task<ActionResult<Members>> GetGrades(int UserId, string period)
        {
            try
            {
                var grades =  await _gradesService.GetGradesByMembersByIdAndPeriod(UserId, period);
                return Ok(grades);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("Session Expired");
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }
    }
}

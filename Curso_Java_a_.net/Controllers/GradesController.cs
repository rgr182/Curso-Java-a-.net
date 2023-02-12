using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Mvc;
using Curso_Java_a_.net.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.Services;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using System.Diagnostics;
using Curso_Java_a_.net.DataAccess.Repository.Context;

namespace Curso_Java_a_.net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GradesController : ControllerBase
    {
        public readonly IGradesService _gradesService;        
        public ILogger<GradesController> _logger;
        internal SchoolSystemContext _context;

        public GradesController(IGradesService gradesService, ILogger<GradesController> logger, SchoolSystemContext context)
        {
            _gradesService = gradesService;
            _logger = logger;
        }
        [HttpGet]
        [Route("/Grade")]
        public async Task<ActionResult<Grades>> GetGrade(int memberId)
        {
            try
            {
                var grade = await _gradesService.GetGrade(memberId);
                if (grade == null)
                {
                    return NoContent();
                }
                return Ok(grade);
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
        [HttpGet]
        [Route("/Grades")]
        public async Task<ActionResult<List<Grades>>> GetGrades()
        {
            try
            {
                var grades = await _gradesService.GetGrades();
                if (grades == null)
                {
                    return NoContent();
                }
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
        [HttpPost]
        [Route("/Grade")]
        public async Task<ActionResult<Grades>> PostGradesAsync(Grades memberId)
        {
            try
            {
                var grade = await _gradesService.PostGradesAsync(memberId);
                return Ok(grade);
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("duplicate"))
                    return BadRequest("Grade already exist");
                else
                    return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpPut]
        [Route("/Grade")]
        public async Task<ActionResult<Grades>> UpdateGradesAsync(Grades memberId)
        {
            try
            {
                var gradeUpdate = _gradesService.UpdateGradesAsync(memberId);
                if (gradeUpdate == null)
                {
                    return BadRequest("Grade don´t exist");
                }
                return Ok(gradeUpdate);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpDelete]
        [Route("/Grade")]
        [AllowAnonymous]
        public async Task<ActionResult<Grades>> DeleteGrades(int memberId)
        {
            try
            {
                var gradeUpdate = _gradesService.DeleteGrades(memberId);
                if (gradeUpdate == null)
                {
                    return BadRequest("Grade don´t exist");
                }
                return Ok(gradeUpdate);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }
    }
}

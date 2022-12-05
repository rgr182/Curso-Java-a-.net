using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using MySqlConnector;
using Dapper;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Mvc;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.Controllers
{
    public class SubjectsController : ControllerBase
    {
        public readonly ISubjectsService _subjectsService;
        public SubjectsController(ISubjectsService subjectsService)
        {
            _subjectsService = subjectsService;
        }

        [HttpGet]
        [Route("/GetSubject")]
        public async Task<ActionResult<Subjects>> GetSubject(int id)
        {
            try
            {
                var subject = await _subjectsService.GetSubjectById(id);

                return Ok(subject);
            }
            catch (Exception ex)
            {
                return Problem(ex.ToString());
            }
        }
    }
}

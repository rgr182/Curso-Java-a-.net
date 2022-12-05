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
using Curso_Java_a_.net.DataAccess.Repository.Repositories;

namespace Curso_Java_a_.net.Controllers
{
    public class UsersSubjectsController : ControllerBase
    {
        public readonly IUsersSubjectsService _userSubjectsService;
        public UsersSubjectsController(IUsersSubjectsService userSubjectsService)
        {
            _userSubjectsService = userSubjectsService;
        }
        [HttpGet]
        [Route("/userSubjects")]
        public async Task<ActionResult> GetUserSubjects(int id)
        {
            try
            {
                var materias = await _userSubjectsService.GetUserSubjects(id);
                if (materias == null)
                {
                    return NotFound("Usuario sin materias");
                }
                return Ok(materias);
            }
            catch (Exception ex)
            {
                return Problem(ex.ToString());
            }
            
        }
    }
}

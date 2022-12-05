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
    public class UsersController : ControllerBase
    {
        public readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        [Route("/ShowUsuarios")]
        public async Task<ActionResult<Users>> GetUsers(int id)
        {
            try
            {
                var user = await _usersService.GetUserById(id);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return Problem(ex.ToString());
            }
        }
        [HttpPost]
        [Route("/Login")]
        public async Task<ActionResult> Login(string user, string password)
        {
            try
            {
                var User = await _usersService.LoginUser(user, password);
                if (User == null)
                {
                     return Unauthorized("Usuario o contraseña incorrectos");
                }
                return Ok(User);
            }
            catch (Exception ex)
            {
                return Problem(ex.ToString());
            }
        }
    }
}

using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using MySqlConnector;
using Dapper;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Mvc;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using Curso_Java_a_.net.DataAccess.Entities;


namespace Curso_Java_a_.net.Controllers
{
    public class UsersController : ControllerBase
    {
        public readonly IUsersService _usersService;
        public ILogger<UsersController> _logger;

        public UsersController(IUsersService usersService, ILogger<UsersController> logger)
        {
            _usersService = usersService;
            _logger = logger;
        }

        [HttpGet]
        [Route("/ShowUsuarios")]
        public async Task<ActionResult<Users>> GetUsers(string usuario, string pass)

        {
            try
            {
                var user = await _usersService.GetUserByUserAndPassword(usuario, pass);

                string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                return Ok(token);
            }
            catch (UnauthorizedAccessException uex) {
                _logger.LogError(uex, "User and password does not match");
                return Unauthorized("User and password does not match");
            }
            catch (Exception uex)
            {
                
                return Problem("Some error happened please contact Sys Admin");
            }
        }


        
    }
}

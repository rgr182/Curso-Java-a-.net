using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using System.Web.Http;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using Microsoft.AspNetCore.Mvc;
using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.Controllers
{
    public class SecurityController : ControllerBase
    {
        public readonly ISessionService _sessionService;
        public readonly IUsersService _usersService;
        public ILogger<SecurityController> _logger;

        public SecurityController(ISessionService securityService,
                                  ILogger<SecurityController> logger,
                                  IUsersService usersService)
        {
            _sessionService = securityService;
            _logger = logger;
            _usersService = usersService;
        }

        [HttpPost]
        [Route("/Session")]
        public async Task<ActionResult<Session>> SaveSession(string User, string Password)
        {
            try
            {
                var user = await _usersService.GetUserByUserAndPassword(User, Password);
                await _sessionService.SaveSession(user.UserId);
                var session = await _sessionService.GetSession(user.UserId);


                return Ok(session);
            }
            catch (UnauthorizedAccessException uex) {                
                return Unauthorized("User and password does not match");
            }
            catch (Exception ex)
            {
                
                return Problem("Some error happened please contact Sys Admin");
            }
        }       

    }
}

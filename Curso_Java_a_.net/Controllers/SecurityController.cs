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
        public readonly IMembersService _membersService;
        public ILogger<SecurityController> _logger;

        public SecurityController(ISessionService securityService,
                                  ILogger<SecurityController> logger,
                                  IMembersService membersService)
        {
            _sessionService = securityService;
            _logger = logger;
            _membersService = membersService;
        }

        [HttpPost]
        [Route("/Session")]
        public async Task<ActionResult<Session>> SaveSession(string User, string Password)
        {
            try
            {
                var user = await _membersService.GetMemberByUserAndPassword(User, Password);
                await _sessionService.SaveSession(user.MembersId);
                var session = await _sessionService.GetSession(user.MembersId);


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

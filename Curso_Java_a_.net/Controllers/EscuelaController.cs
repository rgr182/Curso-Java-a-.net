using Curso_Java_a_.net.DataAccess.DAL;
using Curso_Java_a_.net.DataAccess.Models;
using Curso_Java_a_.net.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Curso_Java_a_.net.Controllers
{
    public class EscuelaController : Controller
    {
        private readonly ILogger<EscuelaController> _logger;
        private EscuelaContext _escuelaContext;
        public EscuelaController(ILogger<EscuelaController> logger,
            EscuelaContext escuelaContext)
        {
            _escuelaContext = escuelaContext;
        }
        [HttpGet]
        [Route("/GetMaterias")]
        public IEnumerable<materias> GetMaterias()
        {
            return _escuelaContext.materias.ToList();
        }
        [HttpGet]
        [Route("/GetMateriasUsuarios")]
        public IEnumerable<materiasusuarios> GetMateriasUsuarios()
        {
            return _escuelaContext.materiasusuarios.ToList();
        }
        [HttpGet]
        [Route("/GetUsuarios")]
        public IEnumerable<usuarios> GetUsuarios()
        {
            return _escuelaContext.usuarios.ToList();
        }
    }
}

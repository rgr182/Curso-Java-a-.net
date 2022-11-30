using Curso_Java_a_.net.DataAccess.Services;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;

namespace Curso_Java_a_.net.Controllers
{
    public class MateriasUsuariosController : Controller
    {
        IMateriasUsuariosService _materiasUsuarioService;

        public MateriasUsuariosController(IMateriasUsuariosService materiasUsuarioService)
        {

            _materiasUsuarioService = materiasUsuarioService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetCalificacionPorId(int id)
        {

            try
            {
                var calificacion = await _materiasUsuarioService.GetCalificacionPorIdAsync(id);
                return (IHttpActionResult)Ok(calificacion);
            }
            catch (Exception ex)
            {
                return (IHttpActionResult)Problem();
            }            
        }
    }
}

using Curso_Java_a_.net.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Curso_Java_a_.net.Context.DAL;

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

        #region GetsTodo
        [HttpGet]
        [Route("/Materias")]
        public IEnumerable<materias> GetMaterias()
        {
            return _escuelaContext.materias.ToList();
        }
        [HttpGet]
        [Route("/MateriasUsuarios")]
        public string GetMateriasUsuarios()
        {
            var result = _escuelaContext.materiasusuarios
                            .Join(_escuelaContext.materias,
                                m => m.idmateria,
                                mu => mu.idmateria,
                                (mu, m) => new {
                                    id=mu.idmateriausuario,
                                    mu.idusuario,
                                    materia = m.nombre,
                                    m.horario,
                                    mu.calificacion,
                                    m.maestro
                                })

                            .Join(_escuelaContext.usuarios,
                                mu => mu.idusuario,
                                u => u.idusuario,
                                (mu, u) => new {
                                    mu.id,
                                    mu.idusuario,
                                    mu.materia,
                                    mu.horario,
                                    mu.calificacion,
                                    mu.maestro,
                                    name=u.nombre,
                                    u.edad,
                                    u.correo
                                });

            var final ="";
            foreach (var r in result)
            {
                final += ("id: " + r.id + " nombre: " + r.name + " edad: " + r.edad + " correo: " + r.correo + " materia: " + r.materia + " maestro: " + r.maestro + " horario: " + r.horario + " calificacion: " + r.calificacion + "\n");
            }
            return final;
        }
        [HttpGet]
        [Route("/Usuarios")]
        public IEnumerable<usuarios> GetUsuarios()
        {
            return _escuelaContext.usuarios.ToList();
        }
        #endregion

        #region usuarios
        [HttpPost]
        [Route("/PostUsuario")]
        public string InsertUsuario(string nombre, string genero, DateTime fechaNacimiento, string correo,int edad)
        {
            var res = "";
            try
            {
                usuarios usuario = new usuarios();
                usuario.nombre = nombre;
                usuario.genero = genero;
                usuario.correo = correo;
                usuario.edad = edad;
                usuario.fechanacimiento = fechaNacimiento;
                _escuelaContext.usuarios.Add(usuario);
                _escuelaContext.SaveChanges();
                return "Usuario agregado";
            }
            catch (Exception ex)
            {
                res = "Hubo problemas: " + ex.Message;
            }
            return res;
        }
        [HttpPut]
        [Route("/PutUsuario")]
        public string UpdateUsuario(int idusuario, string nombre, string genero, DateTime fechaNacimiento, string correo, int edad)
        {
            var res = "";
            try
            {
                usuarios usuario = _escuelaContext.usuarios.Find(idusuario);
                usuario.nombre = nombre;
                usuario.genero = genero;
                usuario.correo = correo;
                usuario.edad = edad;
                usuario.fechanacimiento = fechaNacimiento;
                _escuelaContext.usuarios.Update(usuario);
                _escuelaContext.SaveChanges();
                return "Usuario actualizado";
            }
            catch (Exception ex)
            {
                res = "Hubo problemas: " + ex.Message;
            }
            return res;
        }
        [HttpDelete]
        [Route("/DeleteUsuario")]
        public string DeleteUsuario(int idusuario)
        {
            var res = "";
            try
            {
                usuarios usuario = _escuelaContext.usuarios.Find(idusuario);
                _escuelaContext.usuarios.Remove(usuario);
                _escuelaContext.SaveChanges();
                return "Usuario eliminado";

            }
            catch (Exception ex)
            {
                res = "Hubo problemas: " + ex.Message;
            }
            return res;
        }
        #endregion
        #region Materias
        [HttpPost]
        [Route("/PostMateria")]
        public string InsertMateria(string nombre, string horario, string maestro)
        {
            var res = "";
            try
            {
                materias materia = new materias();
                materia.nombre = nombre;
                materia.horario = horario;
                materia.maestro = maestro;
                _escuelaContext.materias.Add(materia);
                _escuelaContext.SaveChanges();
                return "Materia agregada";
            }
            catch (Exception ex)
            {
                res = "Hubo problemas: " + ex.Message;
            }
            return res;
        }
        [HttpPut]
        [Route("/PutMateria")]
        public string UpdateMateria(int idmateria, string nombre, string horario, string maestro)
        {
            var res = "";
            try
            {
                materias materia = _escuelaContext.materias.Find(idmateria);
                materia.nombre = nombre;
                materia.horario = horario;
                materia.maestro = maestro;
                _escuelaContext.materias.Update(materia);
                _escuelaContext.SaveChanges();
                return "Materia actualizada";
            }
            catch (Exception ex)
            {
                res = "Hubo problemas: " + ex.Message;
            }
            return res;
        }
        [HttpDelete]
        [Route("/DeleteMateria")]
        public string DeleteMateria(int idmateria)
        {
            var res = "";
            try
            {
                materias materia = _escuelaContext.materias.Find(idmateria);
                _escuelaContext.materias.Remove(materia);
                _escuelaContext.SaveChanges();
                return "Materia eliminada";

            }
            catch (Exception ex)
            {
                res = "Hubo problemas: " + ex.Message;
            }
            return res;
        }
        #endregion
        #region MateriasUsuarios
        [HttpPost]
        [Route("/PostMateriaUsuario")]
        public string InsertMateriaUsuario(int idmateria, int idusuario)
        {
            var res = "";
            try
            {
                materiasusuarios materiausuario = new materiasusuarios();
                materiausuario.idmateria = idmateria;
                materiausuario.idusuario = idusuario;
                _escuelaContext.materiasusuarios.Add(materiausuario);
                _escuelaContext.SaveChanges();
                return "MateriaUsuario agregada";
            }
            catch (Exception ex)
            {
                res = "Hubo problemas: " + ex.Message;
            }
            return res;
        }
        [HttpPut]
        [Route("/PutMateriaUsuario")]
        public string UpdateMateriaUsuario(int idmateriausuario, int idmateria, int idusuario)
        {
            var res = "";
            try
            {
                materiasusuarios materiausuario = _escuelaContext.materiasusuarios.Find(idmateriausuario);
                materiausuario.idmateria = idmateria;
                materiausuario.idusuario = idusuario;
                _escuelaContext.materiasusuarios.Update(materiausuario);
                _escuelaContext.SaveChanges();
                return "MateriaUsuario actualizada";
            }
            catch (Exception ex)
            {
                res = "Hubo problemas: " + ex.Message;
            }
            return res;
        }
        [HttpDelete]
        [Route("/DeleteMateriaUsuario")]
        public string DeleteMateriaUsuario(int idmateriausuario)
        {
            var res = "";
            try
            {
                materiasusuarios materiausuario = _escuelaContext.materiasusuarios.Find(idmateriausuario);
                _escuelaContext.materiasusuarios.Remove(materiausuario);
                _escuelaContext.SaveChanges();
                return "MateriaUsuario eliminada";
            }
            catch (Exception ex)
            {
                res = "Hubo problemas: " + ex.Message;
            }
            return res;
        }
        #endregion
    }
}

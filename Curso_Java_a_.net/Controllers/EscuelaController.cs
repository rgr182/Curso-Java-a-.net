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
        public IEnumerable<Materias> GetMaterias()
        {
            return _escuelaContext.Materias.ToList();
        }
        [HttpGet]
        [Route("/MateriasUsuarios")]
        public string GetMateriasUsuarios()
        {
            var result = _escuelaContext.MateriasUsuarios
                            .Join(_escuelaContext.Materias,
                                m => m.IdMateria,
                                mu => mu.IdMateria,
                                (mu, m) => new {
                                    id=mu.IdMateriaUsuario,
                                    mu.IdUsuario,
                                    Materia = m.Nombre,
                                    m.Horario,
                                    mu.Calificacion,
                                    m.Maestro
                                })

                            .Join(_escuelaContext.Usuarios,
                                mu => mu.IdUsuario,
                                u => u.IdUsuario,
                                (mu, u) => new {
                                    mu.id,
                                    mu.IdUsuario,
                                    mu.Materia,
                                    mu.Horario,
                                    mu.Calificacion,
                                    mu.Maestro,
                                    Name=u.Nombre,
                                    u.Edad,
                                    u.Correo
                                });

            var final ="";
            foreach (var r in result)
            {
                final += ("id: " + r.id + " Nombre: " + r.Name + " Edad: " + r.Edad + " Correo: " + r.Correo + " materia: " + r.Materia + " Maestro: " + r.Maestro + " Horario: " + r.Horario + " calificacion: " + r.Calificacion + "\n");
            }
            return final;
        }
        [HttpGet]
        [Route("/Usuarios")]
        public IEnumerable<Usuarios> GetUsuarios()
        {
            return _escuelaContext.Usuarios.ToList();
        }
        #endregion

        #region Usuarios
        [HttpPost]
        [Route("/PostUsuario")]
        public string InsertUsuario(string Nombre, string Genero, DateTime FechaNacimiento, string Correo,int Edad)
        {
            var res = "";
            try
            {
                Usuarios usuario = new Usuarios();
                usuario.Nombre = Nombre;
                usuario.Genero = Genero;
                usuario.Correo = Correo;
                usuario.Edad = Edad;
                usuario.FechaNacimiento = FechaNacimiento;
                _escuelaContext.Usuarios.Add(usuario);
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
        public string UpdateUsuario(int IdUsuario, string Nombre, string Genero, DateTime FechaNacimiento, string Correo, int Edad)
        {
            var res = "";
            try
            {
                Usuarios usuario = _escuelaContext.Usuarios.Find(IdUsuario);
                usuario.Nombre = Nombre;
                usuario.Genero = Genero;
                usuario.Correo = Correo;
                usuario.Edad = Edad;
                usuario.FechaNacimiento = FechaNacimiento;
                _escuelaContext.Usuarios.Update(usuario);
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
        public string DeleteUsuario(int IdUsuario)
        {
            var res = "";
            try
            {
                Usuarios usuario = _escuelaContext.Usuarios.Find(IdUsuario);
                _escuelaContext.Usuarios.Remove(usuario);
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
        public string InsertMateria(string Nombre, string Horario, string Maestro)
        {
            var res = "";
            try
            {
                Materias materia = new Materias();
                materia.Nombre = Nombre;
                materia.Horario = Horario;
                materia.Maestro = Maestro;
                _escuelaContext.Materias.Add(materia);
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
        public string UpdateMateria(int IdMateria, string Nombre, string Horario, string Maestro)
        {
            var res = "";
            try
            {
                Materias materia = _escuelaContext.Materias.Find(IdMateria);
                materia.Nombre = Nombre;
                materia.Horario = Horario;
                materia.Maestro = Maestro;
                _escuelaContext.Materias.Update(materia);
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
        public string DeleteMateria(int IdMateria)
        {
            var res = "";
            try
            {
                Materias materia = _escuelaContext.Materias.Find(IdMateria);
                _escuelaContext.Materias.Remove(materia);
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
        public string InsertMateriaUsuario(int IdMateria, int IdUsuario)
        {
            var res = "";
            try
            {
                MateriasUsuarios materiausuario = new MateriasUsuarios();
                materiausuario.IdMateria = IdMateria;
                materiausuario.IdUsuario = IdUsuario;
                _escuelaContext.MateriasUsuarios.Add(materiausuario);
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
        public string UpdateMateriaUsuario(int IdMateriausuario, int IdMateria, int IdUsuario)
        {
            var res = "";
            try
            {
                MateriasUsuarios materiausuario = _escuelaContext.MateriasUsuarios.Find(IdMateriausuario);
                materiausuario.IdMateria = IdMateria;
                materiausuario.IdUsuario = IdUsuario;
                _escuelaContext.MateriasUsuarios.Update(materiausuario);
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
        public string DeleteMateriaUsuario(int IdMateriausuario)
        {
            var res = "";
            try
            {
                MateriasUsuarios materiausuario = _escuelaContext.MateriasUsuarios.Find(IdMateriausuario);
                _escuelaContext.MateriasUsuarios.Remove(materiausuario);
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

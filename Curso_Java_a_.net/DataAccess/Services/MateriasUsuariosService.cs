using Curso_Java_a_.net.DataAccess.Repository.Repostitories;

namespace Curso_Java_a_.net.DataAccess.Services
{

    public interface IMateriasUsuariosService
    {
        public Task<int> GetCalificacionPorIdAsync(int id);
    }

    public class MateriasUsuariosService : IMateriasUsuariosService
    {
        readonly ILogger<MateriasUsuariosService> logger;

        IMateriasUsuarioRepository _materiasUsuarioRepository;

        public MateriasUsuariosService(IMateriasUsuarioRepository materiasUsuarioRepository, ILogger<MateriasUsuariosService> logger)
        {
            _materiasUsuarioRepository = materiasUsuarioRepository;
            this.logger = logger;
        }


        public async Task<int> GetCalificacionPorIdAsync(int id)
        {
            try
            {
                var usuario = await _materiasUsuarioRepository.GetEscuelaByIdAsync(id);
                return usuario.Calificacion;
            }
            catch (Exception ex)
            {
                throw ex;
                logger.LogError(ex, "Some error happened on Materias Usuario Service : 32");
            }        
        }

    }
}

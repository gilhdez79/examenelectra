using ApiExamen.Model;
using Microsoft.AspNetCore.Components.Web;

namespace ApiExamen.Repositorio
{
    public interface IProfesorEscuela
    {
        public Task<bool> RegistraProfesorEscuela(ProfesorEscuela entity);
        public Task<IEnumerable<ProfesorEscuelaDto>> GetProfesorEscuela(int idprofesor);
        public Task<IEnumerable<ProfesorEscuelaDto>> GetAlumnosInscritosXProfesor(int idprofesor);
    }
}

using ApiExamen.Dto;
using ApiExamen.Model;

namespace ApiExamen.Repositorio
{
    public interface IEscuela
    {
        public Task<bool> RegistraEscuela(EscuelaDto entity);
        public Task<bool> ActualizaEscuela(EscuelaDto entity);
        public Task<bool> EliminaEscuela(int Id);

    }
}

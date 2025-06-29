using ApiExamen.Model;

namespace ApiExamen.Repositorio
{
    public interface IEscuela
    {
        public Task<Escuela> RegistraEscuela(Escuela entity);
        public Task<Escuela> ActualizaEscuela(Escuela entity);
        public Task<bool> EliminaEscuela(int Id);

    }
}

using ApiExamen.Dto;
using ApiExamen.Model;

namespace ApiExamen.Repositorio
{
    public interface IProfesores
    {
        public Task<bool> RegistraProfesor(ProfesoresDto profits);
        public Task<bool> ActualizaProfesor(ProfesoresDto profits);
        public Task<bool> EliminaProfesor(int Id);

    }
}

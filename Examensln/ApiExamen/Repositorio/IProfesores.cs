using ApiExamen.Model;

namespace ApiExamen.Repositorio
{
    public interface IProfesores
    {
        public Task<Profesore> RegistraProfesor(Profesore profits);
        public Task<Profesore> ActualizaProfesor(Profesore profits);
        public Task<bool> EliminaProfesor(int Id);

    }
}

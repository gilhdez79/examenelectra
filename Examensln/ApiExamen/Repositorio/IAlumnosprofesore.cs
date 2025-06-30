using ApiExamen.Model;

namespace ApiExamen.Repositorio
{
    public interface IAlumnosprofesore
    {
        public Task<Alumnosprofesore> RegistraAlumnoProfesor(Alumnosprofesore entity);
    }
}

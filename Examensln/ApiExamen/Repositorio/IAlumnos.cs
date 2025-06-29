
using ApiExamen.Model;

namespace ApiExamen.Repositorio
{
    public interface IAlumnos
    {
        public Task<Alumno> RegistraAlumno(Alumno entity);
        public Task<Alumno> ActualizaAlumno(Alumno entity);
        public Task<bool> EliminaAlumno(int Idd);


    }
}

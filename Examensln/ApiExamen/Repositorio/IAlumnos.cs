
using ApiExamen.Dto;
using ApiExamen.Model;

namespace ApiExamen.Repositorio
{
    public interface IAlumnos
    {
        public Task<bool> RegistraAlumno(AlumnoDto entity);
        public Task<bool> ActualizaAlumno(AlumnoDto entity);
        public Task<bool> EliminaAlumno(int Idd);


    }
}

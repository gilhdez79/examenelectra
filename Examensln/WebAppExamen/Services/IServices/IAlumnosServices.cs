using Entyties.Models;

namespace WebAppExamen.Services.IServices
{
    public interface IAlumnosServices
    {
        Task<IEnumerable<Alumno>> FindAllAlumnos();
        Task<Alumno> FindAlumnosById(int id);
        Task<bool> CreateAlumnos(AlumnoDto alumno);
        Task<bool> UpdateAlumnos(AlumnoDto alumno);




    }
}

using ApiExamen.Dto;
using ApiExamen.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace ApiExamen.Repositorio
{
    public class AlumnoReposotory : IAlumnos
    {
        public EscuelaMusicContext context { get; set; }

        public AlumnoReposotory(EscuelaMusicContext _context)
        {
            context = _context;
        }
        public async Task<bool> ActualizaAlumno(AlumnoDto entity)
        {
            var prmIdAlumno = new SqlParameter("@idAlumno", entity.IdAlumno);
            var prmNombre = new SqlParameter("@Nombre", entity.Nombre);
            var prmApaterno = new SqlParameter("@aPaterno", entity.Apaterno);
            var prmMpaterno = new SqlParameter("@aMaterno", entity.Amaterno);
            SqlParameter[] parameters = new SqlParameter[] { prmNombre, prmApaterno, prmMpaterno, prmIdAlumno };

            var result =  await    context.Database.ExecuteSqlRawAsync($"dbo.ActualiuzaAlumno @idAlumno, @Nombre, @aPaterno,@aMaterno", parameters);

            return   result > 0 ;
        }

        public async Task<bool> EliminaAlumno(int Idd)
        {
            var prmIdAlumno = new SqlParameter("@idAlumno", Idd);

            SqlParameter[] parameters = new SqlParameter[] { prmIdAlumno };

            var result = await context.Database.ExecuteSqlRawAsync($"dbo.EliminaAlumno @idAlumno", parameters);

            return result > 0;
        }

        public async Task<bool> RegistraAlumno(AlumnoDto entity)
        {
            var prmNombre = new SqlParameter("@Nombre", entity.Nombre);
            var prmApaterno = new SqlParameter("@aPaterno", entity.Apaterno);
            var prmMpaterno = new SqlParameter("@aMaterno", entity.Amaterno);
            SqlParameter[] parameters = new SqlParameter[] { prmNombre, prmApaterno, prmMpaterno };

            var result = await context.Database.ExecuteSqlRawAsync($"dbo.RegistraAlumno @Nombre, @aPaterno,@aMaterno", parameters);

            return result>0;
        }

        public async Task<IEnumerable<Alumno>> GetAllAlumnos()
        {
            var result =    context.Alumnos.AsEnumerable();

            return result ;
        }
    }
}

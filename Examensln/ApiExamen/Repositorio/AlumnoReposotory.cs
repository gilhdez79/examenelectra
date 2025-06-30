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
            var prmNombre = new SqlParameter("@Nombre", entity.Nombre);
            var prmApaterno = new SqlParameter("@aPaterno", entity.Apaterno);
            var prmMpaterno = new SqlParameter("@aMaterno", entity.Amaterno);
            SqlParameter[] parameters = new SqlParameter[] { prmNombre, prmApaterno, prmMpaterno };

            var result =  await    context.Database.ExecuteSqlRawAsync($"dbo.RegistraAlumno @Nombre, @aPaterno,@aMaterno", parameters);

            return   result > 0 ;
        }

        public Task<bool> EliminaAlumno(int Idd)
        {
            throw new NotImplementedException();
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
    }
}

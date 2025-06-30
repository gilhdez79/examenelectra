using ApiExamen.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ApiExamen.Repositorio
{
    public class ProfesorEscuelaRepository : IProfesorEscuela
    {
        public EscuelaMusicContext context { get; set; }
        public ProfesorEscuelaRepository(EscuelaMusicContext _context)
        {
            context = _context;
        }
        public async Task<bool> RegistraProfesorEscuela(ProfesorEscuela entity)
        {
            var prmEscuela = new SqlParameter("@idEscuela", entity.IEscuela);
            var prmProfesor = new SqlParameter("@IdProfesor", entity.IdProfesor);

            var result = await context.Database.ExecuteSqlAsync($"Exec dbo.RegistraprofesoresEscuela {prmEscuela}, {prmProfesor}");

            return result>0;
        }

        public async Task<IEnumerable<ProfesorEscuelaDto>> GetProfesorEscuela(int idprofesor)
        {

            var prmProfesor = new SqlParameter("@IdProfesor", idprofesor);
            var sqlParameters = new[]
    {
        prmProfesor
    };

            var result =    context.Database.SqlQueryRaw<ProfesorEscuelaDto>($"Exec dbo.GetEscuelasProfesor @IdProfesor", sqlParameters).ToList();
         //  var resobj =  System.Text.Json.JsonSerializer.Deserialize<ProfesorEscuelaDto>(result);

            return result;
        }

        public Task<IEnumerable<ProfesorEscuelaDto>> GetAlumnosInscritosXProfesor(int idprofesor)
        {
            throw new NotImplementedException();
        }
    }

}


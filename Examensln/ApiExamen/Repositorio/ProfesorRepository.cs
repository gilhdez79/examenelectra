using ApiExamen.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ApiExamen.Repositorio
{
    public class ProfesorRepository : IProfesorEscuela
    {
        public EscuelaMusicContext context { get; set; }
        public ProfesorRepository(EscuelaMusicContext _context)
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
    }

}


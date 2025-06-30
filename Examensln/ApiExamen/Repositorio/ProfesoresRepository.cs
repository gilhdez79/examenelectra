using ApiExamen.Dto;
using ApiExamen.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiExamen.Repositorio
{
    public class ProfesoresRepository : IProfesores
    {
        public EscuelaMusicContext context { get; set; }
        public ProfesoresRepository(EscuelaMusicContext _context)
        {
            context=_context;
        }
        public Task<bool> ActualizaProfesor(ProfesoresDto profits)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminaProfesor(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegistraProfesor(ProfesoresDto profits)
        {
            var prmNombre = new SqlParameter("@Nombre", profits.Nombre);
            var prmDesc = new SqlParameter("@Apellido", profits.Apellido);

            SqlParameter[] parameters = new SqlParameter[] { prmNombre, prmDesc };

            var result = await context.Database.ExecuteSqlRawAsync($"dbo.RegistraProfesor @Nombre, @Apellido", parameters);

            return result>0;
        }
    }
}

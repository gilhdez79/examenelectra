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
        public async Task<bool> ActualizaProfesor(ProfesoresDto profits)
        {
            var prmIdEscuela = new SqlParameter("@idProfesor", profits.IdProfesor);
            var prmNombre = new SqlParameter("@Nombre", profits.Nombre);
            var prmDesc = new SqlParameter("@Apellido", profits.Apellido);

            SqlParameter[] parameters = new SqlParameter[] { prmNombre, prmDesc };

            var result = await context.Database.ExecuteSqlRawAsync($"dbo.ActualizaProfesor @idProfesor, @Nombre, @Apellido", parameters);

            return result>0;
        }

        public async Task<bool> EliminaProfesor(int Id)
        {
            var prmIdProfesor = new SqlParameter("@idProfesor", Id);


            SqlParameter[] parameters = new SqlParameter[] { prmIdProfesor };

            var result = await context.Database.ExecuteSqlRawAsync($"dbo.EliminaProfesor @idProfesor", parameters);

            return result>0;
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

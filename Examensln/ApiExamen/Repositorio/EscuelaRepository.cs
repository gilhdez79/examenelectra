using ApiExamen.Dto;
using ApiExamen.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiExamen.Repositorio
{
    public class EscuelaRepository : IEscuela
    {
        public EscuelaMusicContext context { get; set; }
        public EscuelaRepository(EscuelaMusicContext _context)
        {
            context=_context;
        }
        public async Task<bool> ActualizaEscuela(EscuelaDto entity)
        {
            var prmIdEscuela = new SqlParameter("@idEscuela", entity.IdEscuela);
            var prmNombre = new SqlParameter("@Nombre", entity.Nombre);
            var prmDesc = new SqlParameter("@Descripcion", entity.Descripcion);

            SqlParameter[] parameters = new SqlParameter[] { prmNombre, prmDesc };

            var result = await context.Database.ExecuteSqlRawAsync($"dbo.ActualiuzaAlumno @idEscuela, @Nombre, @Descripcion", parameters);

            return result>0;
        }

        public async Task<bool> EliminaEscuela(int Id)
        {
            var prmIdEscuela = new SqlParameter("@idEscuela", Id);


            SqlParameter[] parameters = new SqlParameter[] { prmIdEscuela };

            var result = await context.Database.ExecuteSqlRawAsync($"dbo.ActualiuzaAlumno @idEscuela, @Nombre, @Descripcion", parameters);

            return result>0;
        }

        public async Task<bool> RegistraEscuela(EscuelaDto entity)
        {
            var prmNombre = new SqlParameter("@Nombre", entity.Nombre);
            var prmDesc = new SqlParameter("@Descripcion", entity.Descripcion);

            SqlParameter[] parameters = new SqlParameter[] { prmNombre, prmDesc };

            var result = await context.Database.ExecuteSqlRawAsync($"dbo.RegistraEscuela @Nombre, @Descripcion", parameters);

            return result>0;
        }
    }
}

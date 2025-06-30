using ApiExamen.Model;
using ApiExamen.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiExamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorEscuelaController : ControllerBase
    {
        public IProfesorEscuela _profesorEscuela { get; set; }

        public ProfesorEscuelaController(IProfesorEscuela profesorEscuela)
        {
            _profesorEscuela = profesorEscuela;
        }
        [HttpPost]
        public  async Task<ActionResult> RegistraProfesorEscuela(ProfesorEscuela entity)
        {
            try
            {
                var result = await _profesorEscuela.RegistraProfesorEscuela(entity);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("GetEscuelasProfesor/{idprofesor}")]
        public async Task<ActionResult> GetEscuelasProfesor(int idprofesor)
        {
            try
            {
                var result = await _profesorEscuela.GetProfesorEscuela(idprofesor);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}

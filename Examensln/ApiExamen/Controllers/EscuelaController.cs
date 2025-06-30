using ApiExamen.Dto;
using ApiExamen.Model;
using ApiExamen.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiExamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscuelaController : ControllerBase
    {
        public IEscuela _escuela { get; set; }
        public EscuelaController(IEscuela escuela)
        {
            _escuela = escuela;
        }
        [HttpPost]
        public async Task<ActionResult> RegistraEscuela(EscuelaDto entity)
        {
            try
            {
                var result = await _escuela.RegistraEscuela(entity);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}

using ApiExamen.Dto;
using ApiExamen.Model;
using ApiExamen.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiExamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        public IProfesores _profesores { get; set; }
        public ProfesorController(IProfesores profesores)
        {
            _profesores=profesores;
        }
        [HttpPost]
        public async Task<ActionResult> RegistraProfesores(ProfesoresDto entity)
        {
            try
            {
                var result = await _profesores.RegistraProfesor(entity);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpPut]
        public async Task<ActionResult> ActualizarProfesores(ProfesoresDto entity)
        {
            try
            {
                var result = await _profesores.ActualizaProfesor(entity);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> EliminaProfesores(int id)
        {
            try
            {
                var result = await _profesores.EliminaProfesor(id);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}

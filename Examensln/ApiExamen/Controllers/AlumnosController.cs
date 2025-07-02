using ApiExamen.Dto;
using ApiExamen.Model;
using ApiExamen.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiExamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        public IAlumnos _Alumno { get; set; }

        public AlumnosController(IAlumnos  alumnos)
        {
            _Alumno = alumnos;
        }

        [HttpPost]
        public async Task<ActionResult> RegistraAlumno(AlumnoDto entity)
        {
            try
            {
                var result = await _Alumno.RegistraAlumno(entity);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpPut]
        public async Task<ActionResult> ActualizaAlumno(AlumnoDto entity)
        {
            try
            {
                var result = await _Alumno.ActualizaAlumno(entity);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpPost("EliminaAlumno/{idAlumno}")]
        public async Task<ActionResult> EliminaAlumno(int idAlumno)
        {
            try
            {
                var result = await _Alumno.EliminaAlumno(idAlumno);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetAllAlumnos")]
        public async Task<ActionResult> GetAllAlumnos()
        {
            try
            {
                var result = await _Alumno.GetAllAlumnos();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
      }

}

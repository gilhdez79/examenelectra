using System.ComponentModel.DataAnnotations;

namespace ApiExamen.Dto
{
    public class AlumnoDto
    {
        public int IdAlumno { get; set; }

        [Required(ErrorMessage ="El Nombre es Requerido")]
        public string? Nombre { get; set; }

        public string? Amaterno { get; set; }

        [Required(ErrorMessage = "El Apellido paterno es Requerido")]
        public string? Apaterno { get; set; }

    }
}

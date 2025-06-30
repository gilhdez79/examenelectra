using System;
using System.Collections.Generic;

namespace ApiExamen.Model;

public partial class Escuela
{
    public int IdEscuela { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Alumno> IdAlumnos { get; set; } = new List<Alumno>();

    public virtual ICollection<Profesore> Idprofesors { get; set; } = new List<Profesore>();
}

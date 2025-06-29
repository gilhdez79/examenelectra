using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace ApiExamen.Model;

public partial class Escuela
{
    public int IdEscuela { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    [JsonIgnore]
    public virtual ICollection<Alumno> IdAlumnos { get; set; } = new List<Alumno>();

    [JsonIgnore]
    public virtual ICollection<Profesore> Idprofesors { get; set; } = new List<Profesore>();
}

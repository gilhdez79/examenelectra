using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ApiExamen.Model;

public partial class Alumno
{
    public int IdAlumno { get; set; }

    public string? Nombre { get; set; }

    public string? Amaterno { get; set; }

    public string? Apaterno { get; set; }


    [JsonIgnore]
    public virtual ICollection<Escuela> IdEscuelas { get; set; } = new List<Escuela>();
}

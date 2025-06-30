using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ApiExamen.Model;

public partial class Profesore
{
    public int IdProfesor { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    [JsonIgnore]
    public virtual ICollection<Escuela> IdEscuelas { get; set; } = new List<Escuela>();
}
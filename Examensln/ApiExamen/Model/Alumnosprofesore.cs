using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ApiExamen.Model;

public partial class Alumnosprofesore
{
    public int? IdAlumno { get; set; }

    public int? IdProfesor { get; set; }


    [JsonIgnore]
    public virtual Alumno? IdAlumnoNavigation { get; set; }


    [JsonIgnore]
    public virtual Profesore? IdProfesorNavigation { get; set; }
}

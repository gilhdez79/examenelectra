using System;
using System.Collections.Generic;

namespace Entyties.Models;

[Serializable]
public partial class ProfesorEscuelaDto
{
    public string? Escuela { get; set; }

    public string? Profesor { get; set; }

    public string? Alumno { get; set; }
}

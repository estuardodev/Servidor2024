using System;
using System.Collections.Generic;

namespace ServidorASP.Models;

public partial class Termino
{
    public long Id { get; set; }

    public string NombrePropietario { get; set; } = null!;

    public string NombreDeUsuario { get; set; } = null!;

    public string Contenido { get; set; } = null!;

    public DateTime UltimaActualizacion { get; set; }

    public bool Estado { get; set; }
}

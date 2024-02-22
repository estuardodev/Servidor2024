using System;
using System.Collections.Generic;

namespace ServidorASP.Models;

public partial class PortafolioProyecto
{
    public long Id { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    public string? Imagen { get; set; }

    public string? TextoEnlace { get; set; }

    public string? Enlace { get; set; }

    public string? AltImagen { get; set; }
}

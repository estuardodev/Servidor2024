using System;
using System.Collections.Generic;

namespace ServidorASP.Models;

public partial class InformacionJano
{
    public long Id { get; set; }

    public string Icono { get; set; } = null!;

    public string? Portada { get; set; }

    public string Frase { get; set; } = null!;

    public string? Texto { get; set; }

    public string Imagen { get; set; } = null!;

    public DateTime UltimaActualizacion { get; set; }

    public bool Estado { get; set; }
}

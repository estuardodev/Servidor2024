using System;
using System.Collections.Generic;

namespace ServidorASP.Models;

public partial class PortafolioCertificacione
{
    public long Id { get; set; }

    public string? Imagen { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Enlace { get; set; } = null!;
}

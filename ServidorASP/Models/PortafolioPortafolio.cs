using System;
using System.Collections.Generic;

namespace ServidorASP.Models;

public partial class PortafolioPortafolio
{
    public long Id { get; set; }

    public string? Imagen { get; set; }

    public string TextoLargo { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace ServidorASP.Models;

public partial class IdentificadoresEmail
{
    public long Id { get; set; }

    public string Identificador { get; set; } = null!;

    public bool Estado { get; set; }
}

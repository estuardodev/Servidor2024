using System;
using System.Collections.Generic;

namespace ServidorASP.Models;

public partial class RedesSocialesJano
{
    public long Id { get; set; }

    public string? NombreRedSocial { get; set; }

    public string EnlaceRedSocial { get; set; } = null!;

    public string ImagenFondoRedSocial { get; set; } = null!;

    public string IconoRedSocial { get; set; } = null!;

    public bool Estado { get; set; }
}

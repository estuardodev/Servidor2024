using System;
using System.Collections.Generic;

namespace ServidorASP.Models;

public partial class Formulariocontacto
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Mensaje { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public bool EsSpam { get; set; }

    public bool Terminos { get; set; }
}

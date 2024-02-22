using System;
using System.Collections.Generic;

namespace ServidorASP.Models;

public partial class Categorium
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<ArticuloCategoria> ArticuloCategoria { get; set; } = new List<ArticuloCategoria>();
}

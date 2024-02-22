using System;
using System.Collections.Generic;

namespace ServidorASP.Models;

public partial class EstadoArticulo
{
    public long Id { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();
}

using System;
using System.Collections.Generic;

namespace ServidorASP.Models;

public partial class ArticuloAutor
{
    public long Id { get; set; }

    public long ArticuloId { get; set; }

    public long AutoresId { get; set; }

    public virtual Articulo Articulo { get; set; } = null!;

    public virtual Autore Autores { get; set; } = null!;
}

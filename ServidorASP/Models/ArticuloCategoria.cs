using System;
using System.Collections.Generic;

namespace ServidorASP.Models;

public partial class ArticuloCategoria
{
    public long Id { get; set; }

    public long ArticuloId { get; set; }

    public long CategoriaId { get; set; }

    public virtual Articulo Articulo { get; set; } = null!;

    public virtual Categorium Categoria { get; set; } = null!;
}

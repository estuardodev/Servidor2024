using System;
using System.Collections.Generic;

namespace ServidorASP.Models;

public partial class Autore
{
    public long Id { get; set; }

    public string NombreAutor { get; set; } = null!;

    public virtual ICollection<ArticuloAutor> ArticuloAutors { get; set; } = new List<ArticuloAutor>();
}

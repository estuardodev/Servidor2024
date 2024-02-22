using System;
using System.Collections.Generic;

namespace ServidorASP.Models;

public partial class DjangoSite
{
    public int Id { get; set; }

    public string Domain { get; set; } = null!;

    public string Name { get; set; } = null!;
}

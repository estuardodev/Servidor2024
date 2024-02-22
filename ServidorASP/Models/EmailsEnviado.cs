using System;
using System.Collections.Generic;

namespace ServidorASP.Models;

public partial class EmailsEnviado
{
    public long Id { get; set; }

    public string From { get; set; } = null!;

    public string To { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string Body { get; set; } = null!;

    public DateOnly Datetime { get; set; }
}

using System;
using System.Collections.Generic;

namespace ServidorASP.Models;

public partial class PortafolioEmail
{
    public long Id { get; set; }

    public string EmailAddress { get; set; } = null!;

    public bool SubscribeToNewsletter { get; set; }
}

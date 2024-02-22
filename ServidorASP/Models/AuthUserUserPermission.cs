﻿using System;
using System.Collections.Generic;

namespace ServidorASP.Models;

public partial class AuthUserUserPermission
{
    public long Id { get; set; }

    public int UserId { get; set; }

    public int PermissionId { get; set; }

    public virtual AuthPermission Permission { get; set; } = null!;

    public virtual AuthUser User { get; set; } = null!;
}

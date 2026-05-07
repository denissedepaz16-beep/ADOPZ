using System;
using System.Collections.Generic;

namespace ADOPZ.Entities;

public partial class User
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public string Handle { get; set; } = null!;

    public string? SecretHash { get; set; }

    public virtual Role Role { get; set; } = null!;
}

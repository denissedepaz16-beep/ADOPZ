using System;
using System.Collections.Generic;

namespace ADOPZ.Entities;

public partial class Role
{
    public int Id { get; set; }

    public string? PositionName { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<User> Users { get; set; } = [];

    public Role(ICollection<User> users)
    {
        this.Users = users;
    }
}

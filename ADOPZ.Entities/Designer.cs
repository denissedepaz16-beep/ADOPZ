using System;
using System.Collections.Generic;

namespace ADOPZ.Entities;

public partial class Designer
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public virtual ICollection<Garment> Garments { get; set; } = new List<Garment>();
}

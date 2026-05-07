using System;
using System.Collections.Generic;

namespace ADOPZ.Entities;

public partial class Garment
{
    public long Id { get; set; }

    public int DesignerId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal? MarketPrice { get; set; }

    public int? Quantity { get; set; }

    public virtual Designer Designer { get; set; } = null!;
}

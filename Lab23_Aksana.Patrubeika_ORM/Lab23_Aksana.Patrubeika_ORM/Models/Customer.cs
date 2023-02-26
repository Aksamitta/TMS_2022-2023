using System;
using System.Collections.Generic;

namespace Lab23_Aksana.Patrubeika_ORM.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public int? CustomerDiscount { get; set; }

    public int StoreId { get; set; }

    public virtual Store Store { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace Lab23_Aksana.Patrubeika_ORM.Models;

public partial class Store
{
    public int StoreId { get; set; }

    public string StoreName { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();
}

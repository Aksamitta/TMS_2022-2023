using System;
using System.Collections.Generic;

namespace Lab26_EFCore_Practice.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string ClientName { get; set; } = null!;

    public string ClientSname { get; set; } = null!;

    public virtual ICollection<Magazine> Magazines { get; } = new List<Magazine>();
}

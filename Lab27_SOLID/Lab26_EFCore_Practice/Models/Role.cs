using System;
using System.Collections.Generic;

namespace Lab26_EFCore_Practice.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public int RoleSalaty { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}

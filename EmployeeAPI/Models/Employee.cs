using System;
using System.Collections.Generic;

namespace EmployeeAPI.Models;

public partial class Employee
{
    public int IdEmployee { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int? IdPosition { get; set; }

    public virtual Position? oPosition { get; set; }
}

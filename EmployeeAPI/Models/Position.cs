using System;
using System.Collections.Generic;

namespace EmployeeAPI.Models;

public partial class Position
{
    public int IdPosition { get; set; }

    public string? PositionDescription { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}

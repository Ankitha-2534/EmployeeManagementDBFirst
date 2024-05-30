using System;
using System.Collections.Generic;

namespace DomainModelLayer.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Uid { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Email { get; set; }

    public string? MobileNumber { get; set; }

    public DateTime? JoinDate { get; set; }

    public int? RoleId { get; set; }

    public int? ManagerId { get; set; }

    public int? ProjectId { get; set; }

    public virtual Manager? Manager { get; set; }

    public virtual Project? Project { get; set; }

    public virtual Role? Role { get; set; }
}

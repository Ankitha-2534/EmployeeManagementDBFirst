using System;
using System.Collections.Generic;

namespace DomainModelLayer.Models;

public partial class Location
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}

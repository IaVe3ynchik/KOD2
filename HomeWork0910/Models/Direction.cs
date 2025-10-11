using System;
using System.Collections.Generic;

namespace HomeWork0910.Models;

public partial class Direction
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}

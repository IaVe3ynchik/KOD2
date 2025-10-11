using System;
using System.Collections.Generic;

namespace HomeWork0910.Models;

public partial class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int DirectionId { get; set; }

    public int CourseId { get; set; }

    public int ProjectId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Direction Direction { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}

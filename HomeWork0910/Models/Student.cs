using System;
using System.Collections.Generic;

namespace HomeWork0910.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Phone { get; set; } = null!;

    public string VkProfileLink { get; set; } = null!;

    public int UserId { get; set; }

    public virtual ICollection<Attempt> Attempts { get; set; } = new List<Attempt>();

    public virtual ICollection<TestResult> TestResults { get; set; } = new List<TestResult>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}

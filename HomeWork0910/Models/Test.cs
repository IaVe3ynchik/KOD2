using System;
using System.Collections.Generic;

namespace HomeWork0910.Models;

public partial class Test
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsRepeatable { get; set; }

    public string Type { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime PublishedAt { get; set; }

    public DateTime Deadline { get; set; }

    public int? DurationMinutes { get; set; }

    public bool IsPublic { get; set; }

    public int? PassingScore { get; set; }

    public int? MaxAttempts { get; set; }

    public virtual ICollection<Attempt> Attempts { get; set; } = new List<Attempt>();

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<TestResult> TestResults { get; set; } = new List<TestResult>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Direction> Directions { get; set; } = new List<Direction>();

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}

using System;
using System.Collections.Generic;

namespace HomeWork0910.Models;

public partial class TestResult
{
    public int Id { get; set; }

    public bool Passed { get; set; }

    public int TestId { get; set; }

    public int AttemptId { get; set; }

    public int StudentId { get; set; }

    public virtual Attempt Attempt { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Test Test { get; set; } = null!;
}

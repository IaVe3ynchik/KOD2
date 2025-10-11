using System;
using System.Collections.Generic;

namespace HomeWork0910.Models;

public partial class Attempt
{
    public int Id { get; set; }

    public DateTime StartedAt { get; set; }

    public DateTime? SubmittedAt { get; set; }

    public int? Score { get; set; }

    public int TestId { get; set; }

    public int StudentId { get; set; }

    public virtual Student Student { get; set; } = null!;

    public virtual Test Test { get; set; } = null!;

    public virtual ICollection<TestResult> TestResults { get; set; } = new List<TestResult>();

    public virtual ICollection<UserAttemptAnswer> UserAttemptAnswers { get; set; } = new List<UserAttemptAnswer>();
}

using System;
using System.Collections.Generic;

namespace HomeWork0910.Models;

public partial class UserAttemptAnswer
{
    public int Id { get; set; }

    public bool? IsCorrect { get; set; }

    public int ScoreAwarded { get; set; }

    public int AttemptId { get; set; }

    public int QuestionId { get; set; }

    public virtual Attempt Attempt { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;

    public virtual ICollection<UserSelectedOption> UserSelectedOptions { get; set; } = new List<UserSelectedOption>();

    public virtual UserTextAnswer? UserTextAnswer { get; set; }
}

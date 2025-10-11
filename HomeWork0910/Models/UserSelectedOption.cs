using System;
using System.Collections.Generic;

namespace HomeWork0910.Models;

public partial class UserSelectedOption
{
    public int Id { get; set; }

    public int UserAttemptAnswerId { get; set; }

    public int AnswerId { get; set; }

    public virtual Answer Answer { get; set; } = null!;

    public virtual UserAttemptAnswer UserAttemptAnswer { get; set; } = null!;
}

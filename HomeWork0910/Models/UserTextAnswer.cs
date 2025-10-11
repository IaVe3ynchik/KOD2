using System;
using System.Collections.Generic;

namespace HomeWork0910.Models;

public partial class UserTextAnswer
{
    public int Id { get; set; }

    public string TextAnswer { get; set; } = null!;

    public int UserAttemptAnswerId { get; set; }

    public virtual UserAttemptAnswer UserAttemptAnswer { get; set; } = null!;
}

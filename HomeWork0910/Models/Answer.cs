using System;
using System.Collections.Generic;

namespace HomeWork0910.Models;

public partial class Answer
{
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public bool IsCorrect { get; set; }

    public int QuestionId { get; set; }

    public virtual Question Question { get; set; } = null!;

    public virtual ICollection<UserSelectedOption> UserSelectedOptions { get; set; } = new List<UserSelectedOption>();
}

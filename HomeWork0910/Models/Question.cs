using System;
using System.Collections.Generic;

namespace HomeWork0910.Models;

public partial class Question
{
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public int Number { get; set; }

    public string? Description { get; set; }

    public string AnswerType { get; set; } = null!;

    public bool IsScoring { get; set; }

    public int? MaxScore { get; set; }

    public int TestId { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual Test Test { get; set; } = null!;

    public virtual ICollection<UserAttemptAnswer> UserAttemptAnswers { get; set; } = new List<UserAttemptAnswer>();
}

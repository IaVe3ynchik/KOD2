using System;
using System.Collections.Generic;

namespace HomeWork0910.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public int Role { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Student? Student { get; set; }
}

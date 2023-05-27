using System;
using System.Collections.Generic;

namespace Model.Entites;

public partial class User
{
    public int UserId { get; set; }

    public int? CustomerId { get; set; }

    public int? EmployeeId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Levels { get; set; }

    public string? Salt { get; set; }

    public decimal? Debit { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateUpdate { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Role LevelsNavigation { get; set; } = null!;

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}

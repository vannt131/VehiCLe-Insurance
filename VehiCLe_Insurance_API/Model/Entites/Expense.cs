using System;
using System.Collections.Generic;

namespace Model.Entites;

public partial class Expense
{
    public int ExpenseId { get; set; }

    public int ExpenseType { get; set; }

    public DateTime ExpenseDate { get; set; }

    public decimal ExpenseAmount { get; set; }

    public int ClaimId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public int UserIdcreated { get; set; }

    public int? UserIdupdated { get; set; }

    public virtual ClaimInsurance Claim { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}

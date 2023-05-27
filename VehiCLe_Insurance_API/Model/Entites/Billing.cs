using System;
using System.Collections.Generic;

namespace Model.Entites;

public partial class Billing
{
    public int BillId { get; set; }

    public string BillNumber { get; set; } = null!;

    public int PaymentId { get; set; }

    public string? BankInfo { get; set; }

    public DateTime PayDate { get; set; }

    public int? PolicyId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public int UserIdcreated { get; set; }

    public int? UserIdupdated { get; set; }

    public virtual InsurancePolicy? Policy { get; set; }
}

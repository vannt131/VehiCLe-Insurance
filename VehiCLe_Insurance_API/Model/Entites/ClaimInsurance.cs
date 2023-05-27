using System;
using System.Collections.Generic;

namespace Model.Entites;

public partial class ClaimInsurance
{
    public int ClaimId { get; set; }

    public string ClaimNumber { get; set; } = null!;

    public int PolicyId { get; set; }

    public string PlaceIncident { get; set; } = null!;

    public DateTime DateIncident { get; set; }

    public decimal InsureAmount { get; set; }

    public decimal ClaimAmount { get; set; }

    public int EmployeeId { get; set; }

    /// <summary>
    /// 1 - Đã thanh toán; 0 - Chưa thanh toán
    /// </summary>
    public int StatusPay { get; set; }

    /// <summary>
    /// 0 - Chưa duyệt; 1 - Đã duyệt
    /// </summary>
    public int StatusApprove { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public int UserIdcreated { get; set; }

    public int? UserIdupdated { get; set; }

    public virtual ICollection<ClaimDocument> ClaimDocuments { get; set; } = new List<ClaimDocument>();

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public virtual InsurancePolicy Policy { get; set; } = null!;
}

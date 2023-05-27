using System;
using System.Collections.Generic;

namespace Model.Entites;

public partial class InsurancePolicy
{
    public int PolicyId { get; set; }

    public string PolicyNumber { get; set; } = null!;

    public int InsuranceFeeId { get; set; }

    public int CustomerId { get; set; }

    public int VehicleId { get; set; }

    public bool IsPersonWith { get; set; }

    public DateTime DateStart { get; set; }

    public DateTime DateEnd { get; set; }

    public int DurationId { get; set; }

    public decimal InsurancePrice { get; set; }

    public decimal PersonwithPrice { get; set; }

    public decimal ToltalPrice { get; set; }

    public int EmployeeId { get; set; }

    public byte StatusPay { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public int UserIdcreated { get; set; }

    public int? UserIdupdated { get; set; }

    public virtual ICollection<Billing> Billings { get; set; } = new List<Billing>();

    public virtual ICollection<ClaimInsurance> ClaimInsurances { get; set; } = new List<ClaimInsurance>();

    public virtual Customer Customer { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<HistorySending> HistorySendings { get; set; } = new List<HistorySending>();

    public virtual InsuranceFee InsuranceFee { get; set; } = null!;

    public virtual Vehicle Vehicle { get; set; } = null!;
}

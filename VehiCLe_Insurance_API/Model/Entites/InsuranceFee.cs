using System;
using System.Collections.Generic;

namespace Model.Entites;

public partial class InsuranceFee
{
    public int FeeId { get; set; }

    public int InsuranceInfoId { get; set; }

    public string FeeName { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public int UserIdcreated { get; set; }

    public int? UserIdupdated { get; set; }

    public virtual InsuranceInfo InsuranceInfo { get; set; } = null!;

    public virtual ICollection<InsurancePolicy> InsurancePolicies { get; set; } = new List<InsurancePolicy>();
}

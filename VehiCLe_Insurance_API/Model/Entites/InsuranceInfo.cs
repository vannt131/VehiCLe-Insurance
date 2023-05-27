using System;
using System.Collections.Generic;

namespace Model.Entites;

public partial class InsuranceInfo
{
    public int Id { get; set; }

    public string InsuranceName { get; set; } = null!;

    public string InsuranceObject { get; set; } = null!;

    public string CompensationScope { get; set; } = null!;

    public string Duration { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public DateTime? DateUpdate { get; set; }

    public int UserIdcreated { get; set; }

    public int? UserIdupdated { get; set; }

    public virtual ICollection<InsuranceFee> InsuranceFees { get; set; } = new List<InsuranceFee>();
}

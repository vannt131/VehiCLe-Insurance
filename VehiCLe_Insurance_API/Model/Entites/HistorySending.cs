using System;
using System.Collections.Generic;

namespace Model.Entites;

public partial class HistorySending
{
    public int SendId { get; set; }

    public int CustomerId { get; set; }

    public DateTime SendDate { get; set; }

    public string SendUrl { get; set; } = null!;

    public int PolicyId { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public int UserIdcreated { get; set; }

    public int? UserIdupdated { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual InsurancePolicy Policy { get; set; } = null!;
}

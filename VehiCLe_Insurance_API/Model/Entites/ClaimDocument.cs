using System;
using System.Collections.Generic;

namespace Model.Entites;

public partial class ClaimDocument
{
    public int Id { get; set; }

    public int ClaimId { get; set; }

    public string? UrlFile { get; set; }

    public virtual ClaimInsurance Claim { get; set; } = null!;
}

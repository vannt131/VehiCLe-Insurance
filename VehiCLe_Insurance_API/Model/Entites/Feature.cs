using System;
using System.Collections.Generic;

namespace Model.Entites;

public partial class Feature
{
    public int FeatureId { get; set; }

    public string FeatureName { get; set; } = null!;

    public string Descreption { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public DateTime? DateUpdate { get; set; }

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}

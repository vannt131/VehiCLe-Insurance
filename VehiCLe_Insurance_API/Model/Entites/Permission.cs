using System;
using System.Collections.Generic;

namespace Model.Entites;

public partial class Permission
{
    public int PermissionId { get; set; }

    public int UserId { get; set; }

    public int FeatureId { get; set; }

    public bool Views { get; set; }

    public bool New { get; set; }

    public bool Edit { get; set; }

    public bool Deleted { get; set; }

    public bool Prints { get; set; }

    public bool Approved { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateUpdated { get; set; }

    public virtual Feature Feature { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

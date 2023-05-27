using System;
using System.Collections.Generic;

namespace Model.Entites;

public partial class DicWard
{
    public int DicWardsId { get; set; }

    public string WardsCode { get; set; } = null!;

    public string WardsName { get; set; } = null!;

    public int DicDistrictId { get; set; }

    public int CityId { get; set; }

    public virtual DicCity City { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual DicDistrict DicDistrict { get; set; } = null!;
}

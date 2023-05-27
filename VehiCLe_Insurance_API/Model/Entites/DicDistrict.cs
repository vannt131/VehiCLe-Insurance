using System;
using System.Collections.Generic;

namespace Model.Entites;

public partial class DicDistrict
{
    public int DicDistrictId { get; set; }

    public string DistrictCode { get; set; } = null!;

    public string DistrictName { get; set; } = null!;

    public int CityId { get; set; }

    public virtual DicCity City { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<DicWard> DicWards { get; set; } = new List<DicWard>();
}

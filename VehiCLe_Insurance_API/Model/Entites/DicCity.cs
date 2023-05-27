using System;
using System.Collections.Generic;

namespace Model.Entites;

public partial class DicCity
{
    public int DicCityId { get; set; }

    public string CityCode { get; set; } = null!;

    public string CityName { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<DicDistrict> DicDistricts { get; set; } = new List<DicDistrict>();

    public virtual ICollection<DicWard> DicWards { get; set; } = new List<DicWard>();
}

using System;
using System.Collections.Generic;

namespace Model.Entites;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerCode { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int CityId { get; set; }

    public int? DistrictId { get; set; }

    public int? WardsId { get; set; }

    /// <summary>
    /// Có phải xe chính chủ hay không
    /// </summary>
    public bool IsGoverment { get; set; }

    public string? OwnerName { get; set; }

    public string? AddOwner { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public int UserIdcreated { get; set; }

    public int? UserIdupdated { get; set; }

    public virtual DicCity City { get; set; } = null!;

    public virtual DicDistrict? District { get; set; }

    public virtual ICollection<HistorySending> HistorySendings { get; set; } = new List<HistorySending>();

    public virtual ICollection<InsurancePolicy> InsurancePolicies { get; set; } = new List<InsurancePolicy>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual DicWard? Wards { get; set; }
}

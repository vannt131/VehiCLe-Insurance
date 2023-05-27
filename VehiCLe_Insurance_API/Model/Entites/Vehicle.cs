using System;
using System.Collections.Generic;

namespace Model.Entites;

public partial class Vehicle
{
    public int VehicleId { get; set; }

    public int TypeId { get; set; }

    public int VehicleType { get; set; }

    public string VehicleBrand { get; set; } = null!;

    public string ModelCode { get; set; } = null!;

    public string? VehicleColor { get; set; }

    public string NumberPlate { get; set; } = null!;

    public string EngineNumber { get; set; } = null!;

    public string ChassisNumber { get; set; } = null!;

    public int Slot { get; set; }

    public int SeatCapacity { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateUpdate { get; set; }

    public int UserIdcreated { get; set; }

    public int? UserIdupdated { get; set; }

    public virtual ICollection<InsurancePolicy> InsurancePolicies { get; set; } = new List<InsurancePolicy>();
}

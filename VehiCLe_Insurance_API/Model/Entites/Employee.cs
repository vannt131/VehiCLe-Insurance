using System;
using System.Collections.Generic;

namespace Model.Entites;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmployeeCode { get; set; } = null!;

    public string EmployeeName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public int Gender { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string? CitizenIdentity { get; set; }

    public string Position { get; set; } = null!;

    public string DepartmentActive { get; set; } = null!;

    public string? Descreption { get; set; }

    /// <summary>
    /// 0 - Không hoạt động; 1 - Hoạt động
    /// </summary>
    public int Status { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public int UserIdcreated { get; set; }

    public int? UserIdupdated { get; set; }

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public virtual ICollection<InsurancePolicy> InsurancePolicies { get; set; } = new List<InsurancePolicy>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}

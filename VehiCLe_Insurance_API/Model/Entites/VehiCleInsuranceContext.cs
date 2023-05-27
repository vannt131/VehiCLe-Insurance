using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model.Entites;

public partial class VehiCleInsuranceContext : DbContext
{
    public VehiCleInsuranceContext()
    {
    }

    public VehiCleInsuranceContext(DbContextOptions<VehiCleInsuranceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Billing> Billings { get; set; }

    public virtual DbSet<ClaimDocument> ClaimDocuments { get; set; }

    public virtual DbSet<ClaimInsurance> ClaimInsurances { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DicCity> DicCities { get; set; }

    public virtual DbSet<DicDistrict> DicDistricts { get; set; }

    public virtual DbSet<DicWard> DicWards { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<Feature> Features { get; set; }

    public virtual DbSet<HistorySending> HistorySendings { get; set; }

    public virtual DbSet<InsuranceFee> InsuranceFees { get; set; }

    public virtual DbSet<InsuranceInfo> InsuranceInfos { get; set; }

    public virtual DbSet<InsurancePolicy> InsurancePolicies { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-6NB8RFR;Initial Catalog=VehiCLe_Insurance;Integrated Security=True;TrustServerCertificate=Yes");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Billing>(entity =>
        {
            entity.HasKey(e => e.BillId);

            entity.ToTable("Billing");

            entity.Property(e => e.BillId).HasColumnName("BillID");
            entity.Property(e => e.BankInfo).HasMaxLength(200);
            entity.Property(e => e.BillNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.PayDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.PolicyId).HasColumnName("PolicyID");
            entity.Property(e => e.UserIdcreated).HasColumnName("UserIDCreated");
            entity.Property(e => e.UserIdupdated).HasColumnName("UserIDUpdated");

            entity.HasOne(d => d.Policy).WithMany(p => p.Billings)
                .HasForeignKey(d => d.PolicyId)
                .HasConstraintName("FK_Billing_InsurancePolicy");
        });

        modelBuilder.Entity<ClaimDocument>(entity =>
        {
            entity.ToTable("ClaimDocument");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClaimId).HasColumnName("ClaimID");
            entity.Property(e => e.UrlFile)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.Claim).WithMany(p => p.ClaimDocuments)
                .HasForeignKey(d => d.ClaimId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClaimDocument_Claim");
        });

        modelBuilder.Entity<ClaimInsurance>(entity =>
        {
            entity.HasKey(e => e.ClaimId).HasName("PK_Claim");

            entity.ToTable("ClaimInsurance");

            entity.Property(e => e.ClaimId).HasColumnName("ClaimID");
            entity.Property(e => e.ClaimAmount).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.ClaimNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateIncident).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.InsureAmount).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.PlaceIncident).HasMaxLength(200);
            entity.Property(e => e.PolicyId).HasColumnName("PolicyID");
            entity.Property(e => e.StatusApprove).HasComment("0 - Chưa duyệt; 1 - Đã duyệt");
            entity.Property(e => e.StatusPay).HasComment("1 - Đã thanh toán; 0 - Chưa thanh toán");
            entity.Property(e => e.UserIdcreated).HasColumnName("UserIDCreated");
            entity.Property(e => e.UserIdupdated).HasColumnName("UserIDUpdated");

            entity.HasOne(d => d.Policy).WithMany(p => p.ClaimInsurances)
                .HasForeignKey(d => d.PolicyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Claim_InsurancePolicy1");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("CustomerID");
            entity.Property(e => e.AddOwner).HasMaxLength(500);
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CustomerCode).HasMaxLength(50);
            entity.Property(e => e.CustomerName).HasMaxLength(200);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.DistrictId).HasColumnName("DistrictID");
            entity.Property(e => e.IsGoverment).HasComment("Có phải xe chính chủ hay không");
            entity.Property(e => e.OwnerName).HasMaxLength(200);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.UserIdcreated).HasColumnName("UserIDCreated");
            entity.Property(e => e.UserIdupdated).HasColumnName("UserIDUpdated");
            entity.Property(e => e.WardsId).HasColumnName("WardsID");

            entity.HasOne(d => d.City).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_DicCity");

            entity.HasOne(d => d.District).WithMany(p => p.Customers)
                .HasForeignKey(d => d.DistrictId)
                .HasConstraintName("FK_Customer_DicDistrict");

            entity.HasOne(d => d.Wards).WithMany(p => p.Customers)
                .HasForeignKey(d => d.WardsId)
                .HasConstraintName("FK_Customer_DicWards");
        });

        modelBuilder.Entity<DicCity>(entity =>
        {
            entity.ToTable("DicCity");

            entity.Property(e => e.DicCityId).HasColumnName("DicCityID");
            entity.Property(e => e.CityCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CityName).HasMaxLength(150);
        });

        modelBuilder.Entity<DicDistrict>(entity =>
        {
            entity.ToTable("DicDistrict");

            entity.Property(e => e.DicDistrictId).HasColumnName("DicDistrictID");
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.DistrictCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DistrictName).HasMaxLength(150);

            entity.HasOne(d => d.City).WithMany(p => p.DicDistricts)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DicDistrict_DicCity");
        });

        modelBuilder.Entity<DicWard>(entity =>
        {
            entity.HasKey(e => e.DicWardsId);

            entity.Property(e => e.DicWardsId).HasColumnName("DicWardsID");
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.DicDistrictId).HasColumnName("DicDistrictID");
            entity.Property(e => e.WardsCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.WardsName).HasMaxLength(150);

            entity.HasOne(d => d.City).WithMany(p => p.DicWards)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DicWards_DicCity");

            entity.HasOne(d => d.DicDistrict).WithMany(p => p.DicWards)
                .HasForeignKey(d => d.DicDistrictId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DicWards_DicDistrict");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.CitizenIdentity)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.DepartmentActive).HasMaxLength(200);
            entity.Property(e => e.Descreption).HasMaxLength(200);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Position).HasMaxLength(50);
            entity.Property(e => e.Status).HasComment("0 - Không hoạt động; 1 - Hoạt động");
            entity.Property(e => e.UserIdcreated).HasColumnName("UserIDCreated");
            entity.Property(e => e.UserIdupdated).HasColumnName("UserIDUpdated");
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.ToTable("Expense");

            entity.Property(e => e.ExpenseId).HasColumnName("ExpenseID");
            entity.Property(e => e.ClaimId).HasColumnName("ClaimID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.ExpenseAmount).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.ExpenseDate).HasColumnType("datetime");
            entity.Property(e => e.UserIdcreated).HasColumnName("UserIDCreated");
            entity.Property(e => e.UserIdupdated).HasColumnName("UserIDUpdated");

            entity.HasOne(d => d.Claim).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.ClaimId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Expense_Claim");

            entity.HasOne(d => d.Employee).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Expense_Employee");
        });

        modelBuilder.Entity<Feature>(entity =>
        {
            entity.ToTable("Feature");

            entity.Property(e => e.FeatureId).HasColumnName("FeatureID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Descreption).HasMaxLength(200);
            entity.Property(e => e.FeatureName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HistorySending>(entity =>
        {
            entity.HasKey(e => e.SendId);

            entity.ToTable("HistorySending");

            entity.Property(e => e.SendId).HasColumnName("SendID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.PolicyId).HasColumnName("PolicyID");
            entity.Property(e => e.SendDate).HasColumnType("datetime");
            entity.Property(e => e.SendUrl)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UserIdcreated).HasColumnName("UserIDCreated");
            entity.Property(e => e.UserIdupdated).HasColumnName("UserIDUpdated");

            entity.HasOne(d => d.Customer).WithMany(p => p.HistorySendings)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HistorySending_Customer");

            entity.HasOne(d => d.Policy).WithMany(p => p.HistorySendings)
                .HasForeignKey(d => d.PolicyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HistorySending_InsurancePolicy");
        });

        modelBuilder.Entity<InsuranceFee>(entity =>
        {
            entity.HasKey(e => e.FeeId).HasName("PK_InsuranceFee_1");

            entity.ToTable("InsuranceFee");

            entity.Property(e => e.FeeId).HasColumnName("FeeID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.FeeName).HasMaxLength(200);
            entity.Property(e => e.InsuranceInfoId).HasColumnName("InsuranceInfoID");
            entity.Property(e => e.Price).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.UserIdcreated).HasColumnName("UserIDCreated");
            entity.Property(e => e.UserIdupdated).HasColumnName("UserIDUpdated");

            entity.HasOne(d => d.InsuranceInfo).WithMany(p => p.InsuranceFees)
                .HasForeignKey(d => d.InsuranceInfoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InsuranceFee_InsuranceInfo");
        });

        modelBuilder.Entity<InsuranceInfo>(entity =>
        {
            entity.ToTable("InsuranceInfo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CompensationScope).HasMaxLength(500);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Duration).HasMaxLength(500);
            entity.Property(e => e.InsuranceName).HasMaxLength(200);
            entity.Property(e => e.InsuranceObject).HasMaxLength(500);
            entity.Property(e => e.UserIdcreated).HasColumnName("UserIDCreated");
            entity.Property(e => e.UserIdupdated).HasColumnName("UserIDUpdated");
        });

        modelBuilder.Entity<InsurancePolicy>(entity =>
        {
            entity.HasKey(e => e.PolicyId).HasName("PK_InsuranceContract");

            entity.ToTable("InsurancePolicy");

            entity.Property(e => e.PolicyId)
                .ValueGeneratedNever()
                .HasColumnName("PolicyID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateEnd).HasColumnType("datetime");
            entity.Property(e => e.DateStart).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.DurationId).HasColumnName("DurationID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.InsuranceFeeId).HasColumnName("InsuranceFeeID");
            entity.Property(e => e.InsurancePrice).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.PersonwithPrice).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ToltalPrice).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.UserIdcreated).HasColumnName("UserIDCreated");
            entity.Property(e => e.UserIdupdated).HasColumnName("UserIDUpdated");
            entity.Property(e => e.VehicleId).HasColumnName("VehicleID");

            entity.HasOne(d => d.Customer).WithMany(p => p.InsurancePolicies)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InsurancePolicy_Customer");

            entity.HasOne(d => d.Employee).WithMany(p => p.InsurancePolicies)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InsurancePolicy_Employee");

            entity.HasOne(d => d.InsuranceFee).WithMany(p => p.InsurancePolicies)
                .HasForeignKey(d => d.InsuranceFeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InsurancePolicy_InsuranceFee");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.InsurancePolicies)
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InsurancePolicy_Vehicle");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.ToTable("Permission");

            entity.Property(e => e.PermissionId)
                .ValueGeneratedNever()
                .HasColumnName("PermissionID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.FeatureId).HasColumnName("FeatureID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Feature).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.FeatureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permission_Feature");

            entity.HasOne(d => d.User).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permission_User");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Description).HasMaxLength(150);
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.Users)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_User_Customer");

            entity.HasOne(d => d.Employee).WithMany(p => p.Users)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_User_Employee");

            entity.HasOne(d => d.LevelsNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Levels)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.ToTable("Vehicle");

            entity.Property(e => e.VehicleId)
                .ValueGeneratedNever()
                .HasColumnName("VehicleID");
            entity.Property(e => e.ChassisNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.EngineNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModelCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumberPlate)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TypeId).HasColumnName("TypeID");
            entity.Property(e => e.UserIdcreated).HasColumnName("UserIDCreated");
            entity.Property(e => e.UserIdupdated).HasColumnName("UserIDUpdated");
            entity.Property(e => e.VehicleBrand).HasMaxLength(50);
            entity.Property(e => e.VehicleColor).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CharityApp.TestModels
{
    public partial class TestContext : DbContext
    {
        public TestContext()
        {
        }

        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<BranchesRef> BranchesRefs { get; set; }
        public virtual DbSet<CitiesRef> CitiesRefs { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<CountriesRef> CountriesRefs { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<DistrictsRef> DistrictsRefs { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<RegionsRef> RegionsRefs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("host=db-mysql-fra1-22087-do-user-13921736-0.b.db.ondigitalocean.com;username=doadmin;password=AVNS_EDhriF16LWiSS6233Wj;port=25060;database=Test");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Action>(entity =>
            {
                entity.ToTable("actions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasMaxLength(45);
            });

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.HasKey(e => e.BranchNo)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CityNo, "FK_Branches_Cities");

                entity.HasIndex(e => e.CountryNo, "FK_Branches_Countries");

                entity.HasIndex(e => e.DistrictNo, "FK_Branches_Districts");

                entity.HasIndex(e => e.RegionNo, "FK_Branches_Regions");

                entity.Property(e => e.BranchNo).HasColumnName("Branch_No");

                entity.Property(e => e.AccountNo)
                    .HasMaxLength(20)
                    .HasColumnName("Account_No");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.BranchName)
                    .HasMaxLength(400)
                    .HasColumnName("Branch_Name");

                entity.Property(e => e.BranchNameLatin)
                    .HasMaxLength(400)
                    .HasColumnName("Branch_Name_Latin");

                entity.Property(e => e.BuildingId)
                    .HasMaxLength(100)
                    .HasColumnName("Building_ID");

                entity.Property(e => e.CityNo).HasColumnName("City_No");

                entity.Property(e => e.ContactName)
                    .HasMaxLength(400)
                    .HasColumnName("Contact_Name");

                entity.Property(e => e.CountryNo).HasColumnName("Country_No");

                entity.Property(e => e.DateOpen)
                    .HasColumnType("datetime(6)")
                    .HasColumnName("Date_Open");

                entity.Property(e => e.DistrictNo).HasColumnName("District_No");

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.Fax).HasMaxLength(30);

                entity.Property(e => e.Fax1)
                    .HasMaxLength(30)
                    .HasColumnName("Fax_1");

                entity.Property(e => e.Mobile).HasMaxLength(30);

                entity.Property(e => e.Mobile1)
                    .HasMaxLength(30)
                    .HasColumnName("Mobile_1");

                entity.Property(e => e.OriginDate).HasColumnName("Origin_Date");

                entity.Property(e => e.PcName)
                    .HasMaxLength(50)
                    .HasColumnName("PC_Name");

                entity.Property(e => e.PcUserName)
                    .HasMaxLength(50)
                    .HasColumnName("PC_User_Name");

                entity.Property(e => e.PoBox)
                    .HasMaxLength(20)
                    .HasColumnName("Po_Box");

                entity.Property(e => e.RegionNo).HasColumnName("Region_No");

                entity.Property(e => e.Remarks).HasMaxLength(400);

                entity.Property(e => e.Status).HasMaxLength(2);

                entity.Property(e => e.StatusDate).HasColumnName("Status_Date");

                entity.Property(e => e.StreetId)
                    .HasMaxLength(100)
                    .HasColumnName("Street_ID");

                entity.Property(e => e.Tel).HasMaxLength(20);

                entity.Property(e => e.Tel1)
                    .HasMaxLength(30)
                    .HasColumnName("Tel_1");

                entity.Property(e => e.UpdateDate).HasColumnName("Update_Date");

                entity.Property(e => e.UserNoCreated).HasColumnName("User_No_Created");

                entity.Property(e => e.UserNoUpdate).HasColumnName("User_No_Update");

                entity.Property(e => e.VatReg)
                    .HasMaxLength(30)
                    .HasColumnName("Vat_Reg")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(20)
                    .HasColumnName("Zip_Code");

                entity.HasOne(d => d.CityNoNavigation)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.CityNo)
                    .HasConstraintName("FK_Branches_Cities");

                entity.HasOne(d => d.CountryNoNavigation)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.CountryNo)
                    .HasConstraintName("FK_Branches_Countries");

                entity.HasOne(d => d.DistrictNoNavigation)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.DistrictNo)
                    .HasConstraintName("FK_Branches_Districts");

                entity.HasOne(d => d.RegionNoNavigation)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.RegionNo)
                    .HasConstraintName("FK_Branches_Regions");
            });

            modelBuilder.Entity<BranchesRef>(entity =>
            {
                entity.HasKey(e => e.OpNo)
                    .HasName("PRIMARY");

                entity.ToTable("Branches_Ref");

                entity.HasIndex(e => e.ActionId, "action_Name_idx");

                entity.Property(e => e.OpNo).HasColumnName("Op_No");

                entity.Property(e => e.AccountNo)
                    .HasMaxLength(20)
                    .HasColumnName("Account_No");

                entity.Property(e => e.ActionId).HasColumnName("action_id");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.ArchiveSeq).HasColumnName("Archive_Seq");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(400)
                    .HasColumnName("Branch_Name");

                entity.Property(e => e.BranchNameLatin)
                    .HasMaxLength(400)
                    .HasColumnName("Branch_Name_Latin");

                entity.Property(e => e.BranchNo).HasColumnName("Branch_No");

                entity.Property(e => e.BuildingId)
                    .HasMaxLength(100)
                    .HasColumnName("Building_ID");

                entity.Property(e => e.CityNo).HasColumnName("City_No");

                entity.Property(e => e.CompanyNo).HasColumnName("Company_No");

                entity.Property(e => e.ContactName)
                    .HasMaxLength(400)
                    .HasColumnName("Contact_Name");

                entity.Property(e => e.CountryNo).HasColumnName("Country_No");

                entity.Property(e => e.DateOpen).HasColumnName("Date_Open");

                entity.Property(e => e.DistrictNo).HasColumnName("District_No");

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.Fax).HasMaxLength(30);

                entity.Property(e => e.Fax1)
                    .HasMaxLength(30)
                    .HasColumnName("Fax_1");

                entity.Property(e => e.Mobile).HasMaxLength(30);

                entity.Property(e => e.Mobile1)
                    .HasMaxLength(30)
                    .HasColumnName("Mobile_1");

                entity.Property(e => e.OriginDate).HasColumnName("Origin_Date");

                entity.Property(e => e.PcName)
                    .HasMaxLength(50)
                    .HasColumnName("PC_Name");

                entity.Property(e => e.PcUserName)
                    .HasMaxLength(50)
                    .HasColumnName("PC_User_Name");

                entity.Property(e => e.PoBox)
                    .HasMaxLength(20)
                    .HasColumnName("Po_Box");

                entity.Property(e => e.RegionNo).HasColumnName("Region_No");

                entity.Property(e => e.Remarks).HasMaxLength(400);

                entity.Property(e => e.Status).HasMaxLength(2);

                entity.Property(e => e.StatusDate).HasColumnName("Status_Date");

                entity.Property(e => e.StreetId)
                    .HasMaxLength(100)
                    .HasColumnName("Street_ID");

                entity.Property(e => e.Tel).HasMaxLength(20);

                entity.Property(e => e.Tel1)
                    .HasMaxLength(30)
                    .HasColumnName("Tel_1");

                entity.Property(e => e.UpdateDate).HasColumnName("Update_Date");

                entity.Property(e => e.UserNoCreated).HasColumnName("User_No_Created");

                entity.Property(e => e.UserNoUpdate).HasColumnName("User_No_Update");

                entity.Property(e => e.VatReg)
                    .HasMaxLength(30)
                    .HasColumnName("Vat_Reg");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(20)
                    .HasColumnName("Zip_Code");

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.BranchesRefs)
                    .HasForeignKey(d => d.ActionId)
                    .HasConstraintName("action_Name");
            });

            modelBuilder.Entity<CitiesRef>(entity =>
            {
                entity.HasKey(e => e.OpNo)
                    .HasName("PRIMARY");

                entity.ToTable("Cities_Ref");

                entity.Property(e => e.OpNo).HasColumnName("Op_No");

                entity.Property(e => e.CityName)
                    .HasMaxLength(100)
                    .HasColumnName("City_Name");

                entity.Property(e => e.CityNameLatin)
                    .HasMaxLength(100)
                    .HasColumnName("City_Name_Latin");

                entity.Property(e => e.CityNo).HasColumnName("City_No");

                entity.Property(e => e.CountryNo).HasColumnName("Country_No");

                entity.Property(e => e.DateOpen)
                    .HasMaxLength(10)
                    .HasColumnName("Date_Open");

                entity.Property(e => e.OriginDate).HasColumnName("Origin_Date");

                entity.Property(e => e.PcName)
                    .HasMaxLength(50)
                    .HasColumnName("PC_Name");

                entity.Property(e => e.PcUserName)
                    .HasMaxLength(50)
                    .HasColumnName("PC_User_Name");

                entity.Property(e => e.RegionNo).HasColumnName("Region_No");

                entity.Property(e => e.Remarks).HasMaxLength(200);

                entity.Property(e => e.Status).HasMaxLength(2);

                entity.Property(e => e.StatusDate).HasColumnName("Status_Date");

                entity.Property(e => e.UpdateDate).HasColumnName("Update_Date");

                entity.Property(e => e.UserNoCreated).HasColumnName("User_No_Created");

                entity.Property(e => e.UserNoUpdate).HasColumnName("User_No_Update");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.CityNo)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.RegionNo, "FK_Cities_Regions");

                entity.Property(e => e.CityNo).HasColumnName("City_No");

                entity.Property(e => e.CityName)
                    .HasMaxLength(100)
                    .HasColumnName("City_Name");

                entity.Property(e => e.CityNameLatin)
                    .HasMaxLength(100)
                    .HasColumnName("City_Name_Latin");

                entity.Property(e => e.DateOpen)
                    .HasMaxLength(10)
                    .HasColumnName("Date_Open");

                entity.Property(e => e.OriginDate).HasColumnName("Origin_Date");

                entity.Property(e => e.PcName)
                    .HasMaxLength(50)
                    .HasColumnName("PC_Name");

                entity.Property(e => e.PcUserName)
                    .HasMaxLength(50)
                    .HasColumnName("PC_User_Name");

                entity.Property(e => e.RegionNo).HasColumnName("Region_No");

                entity.Property(e => e.Remarks).HasMaxLength(200);

                entity.Property(e => e.Status).HasMaxLength(2);

                entity.Property(e => e.StatusDate).HasColumnName("Status_Date");

                entity.Property(e => e.UpdateDate).HasColumnName("Update_Date");

                entity.Property(e => e.UserNoCreated).HasColumnName("User_No_Created");

                entity.Property(e => e.UserNoUpdate).HasColumnName("User_No_Update");

                entity.HasOne(d => d.RegionNoNavigation)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.RegionNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cities_Regions");
            });

            modelBuilder.Entity<CountriesRef>(entity =>
            {
                entity.HasKey(e => e.OpNo)
                    .HasName("PRIMARY");

                entity.ToTable("Countries_REF");

                entity.Property(e => e.OpNo).HasColumnName("Op_No");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(100)
                    .HasColumnName("Country_Name");

                entity.Property(e => e.CountryNameLatin)
                    .HasMaxLength(100)
                    .HasColumnName("Country_Name_Latin");

                entity.Property(e => e.CountryNo).HasColumnName("Country_No");

                entity.Property(e => e.DateOpen)
                    .HasMaxLength(10)
                    .HasColumnName("Date_Open");

                entity.Property(e => e.OriginDate)
                    .HasColumnType("datetime(6)")
                    .HasColumnName("Origin_Date");

                entity.Property(e => e.PcName)
                    .HasMaxLength(60)
                    .HasColumnName("PC_Name");

                entity.Property(e => e.PcUserName)
                    .HasMaxLength(60)
                    .HasColumnName("PC_User_Name");

                entity.Property(e => e.Remarks).HasMaxLength(200);

                entity.Property(e => e.Status).HasMaxLength(2);

                entity.Property(e => e.StatusDate)
                    .HasColumnType("datetime(6)")
                    .HasColumnName("Status_Date");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime(6)")
                    .HasColumnName("Update_Date");

                entity.Property(e => e.UserNoCreated).HasColumnName("User_No_Created");

                entity.Property(e => e.UserNoUpdate).HasColumnName("User_No_Update");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryNo)
                    .HasName("PRIMARY");

                entity.Property(e => e.CountryNo).HasColumnName("Country_No");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(100)
                    .HasColumnName("Country_Name");

                entity.Property(e => e.CountryNameLatin)
                    .HasMaxLength(100)
                    .HasColumnName("Country_Name_Latin");

                entity.Property(e => e.DateOpen)
                    .HasMaxLength(10)
                    .HasColumnName("Date_Open");

                entity.Property(e => e.OriginDate)
                    .HasColumnType("datetime(6)")
                    .HasColumnName("Origin_Date");

                entity.Property(e => e.PcName)
                    .HasMaxLength(60)
                    .HasColumnName("PC_Name");

                entity.Property(e => e.PcUserName)
                    .HasMaxLength(60)
                    .HasColumnName("PC_User_Name");

                entity.Property(e => e.Remarks).HasMaxLength(200);

                entity.Property(e => e.Status).HasMaxLength(2);

                entity.Property(e => e.StatusDate)
                    .HasColumnType("datetime(6)")
                    .HasColumnName("Status_Date");

                entity.Property(e => e.UpdateDate)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("Update_Date");

                entity.Property(e => e.UserNoCreated).HasColumnName("User_No_Created");

                entity.Property(e => e.UserNoUpdate).HasColumnName("User_No_Update");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasKey(e => e.DistrictNo)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CityNo, "FK_Districts_Cities");

                entity.Property(e => e.DistrictNo).HasColumnName("District_No");

                entity.Property(e => e.CityNo).HasColumnName("City_No");

                entity.Property(e => e.DateOpen)
                    .HasMaxLength(10)
                    .HasColumnName("Date_Open");

                entity.Property(e => e.DistrictName)
                    .HasMaxLength(200)
                    .HasColumnName("District_Name");

                entity.Property(e => e.DistrictNameLatin)
                    .HasMaxLength(200)
                    .HasColumnName("District_Name_Latin");

                entity.Property(e => e.OriginDate).HasColumnName("Origin_Date");

                entity.Property(e => e.PcName)
                    .HasMaxLength(50)
                    .HasColumnName("PC_Name");

                entity.Property(e => e.PcUserName)
                    .HasMaxLength(50)
                    .HasColumnName("PC_User_Name");

                entity.Property(e => e.Remarks).HasMaxLength(200);

                entity.Property(e => e.Status).HasMaxLength(2);

                entity.Property(e => e.StatusDate).HasColumnName("Status_Date");

                entity.Property(e => e.UpdateDate).HasColumnName("Update_Date");

                entity.Property(e => e.UserNoCreated).HasColumnName("User_No_Created");

                entity.Property(e => e.UserNoUpdate).HasColumnName("User_No_Update");

                entity.HasOne(d => d.CityNoNavigation)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.CityNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Districts_Cities");
            });

            modelBuilder.Entity<DistrictsRef>(entity =>
            {
                entity.HasKey(e => e.OpNo)
                    .HasName("PRIMARY");

                entity.ToTable("Districts_REF");

                entity.Property(e => e.OpNo).HasColumnName("Op_No");

                entity.Property(e => e.CityNo).HasColumnName("City_No");

                entity.Property(e => e.CountryNo).HasColumnName("Country_No");

                entity.Property(e => e.DateOpen)
                    .HasMaxLength(10)
                    .HasColumnName("Date_Open");

                entity.Property(e => e.DistrictName)
                    .HasMaxLength(200)
                    .HasColumnName("District_Name");

                entity.Property(e => e.DistrictNameLatin)
                    .HasMaxLength(200)
                    .HasColumnName("District_Name_Latin");

                entity.Property(e => e.DistrictNo).HasColumnName("District_No");

                entity.Property(e => e.OriginDate).HasColumnName("Origin_Date");

                entity.Property(e => e.PcName)
                    .HasMaxLength(50)
                    .HasColumnName("PC_Name");

                entity.Property(e => e.PcUserName)
                    .HasMaxLength(50)
                    .HasColumnName("PC_User_Name");

                entity.Property(e => e.RegionNo).HasColumnName("Region_No");

                entity.Property(e => e.Remarks).HasMaxLength(200);

                entity.Property(e => e.Status).HasMaxLength(2);

                entity.Property(e => e.StatusDate).HasColumnName("Status_Date");

                entity.Property(e => e.UpdateDate).HasColumnName("Update_Date");

                entity.Property(e => e.UserNoCreated).HasColumnName("User_No_Created");

                entity.Property(e => e.UserNoUpdate).HasColumnName("User_No_Update");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.RegionNo)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CountryNo, "FK_Regions_Countries");

                entity.Property(e => e.RegionNo).HasColumnName("Region_No");

                entity.Property(e => e.CountryNo).HasColumnName("Country_No");

                entity.Property(e => e.DateOpen)
                    .HasMaxLength(10)
                    .HasColumnName("Date_Open");

                entity.Property(e => e.OriginDate)
                    .HasColumnType("datetime(6)")
                    .HasColumnName("Origin_Date");

                entity.Property(e => e.PcName)
                    .HasMaxLength(60)
                    .HasColumnName("PC_Name");

                entity.Property(e => e.PcUserName)
                    .HasMaxLength(60)
                    .HasColumnName("PC_User_Name");

                entity.Property(e => e.RegionName)
                    .HasMaxLength(200)
                    .HasColumnName("Region_Name");

                entity.Property(e => e.RegionNameLatin)
                    .HasMaxLength(200)
                    .HasColumnName("Region_Name_Latin");

                entity.Property(e => e.Remarks).HasMaxLength(200);

                entity.Property(e => e.Status).HasMaxLength(2);

                entity.Property(e => e.StatusDate)
                    .HasColumnType("datetime(6)")
                    .HasColumnName("Status_Date");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime(6)")
                    .HasColumnName("Update_Date");

                entity.Property(e => e.UserNoCreated).HasColumnName("User_No_Created");

                entity.Property(e => e.UserNoUpdate).HasColumnName("User_No_Update");

                entity.HasOne(d => d.CountryNoNavigation)
                    .WithMany(p => p.Regions)
                    .HasForeignKey(d => d.CountryNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Regions_Countries");
            });

            modelBuilder.Entity<RegionsRef>(entity =>
            {
                entity.HasKey(e => e.OpNo)
                    .HasName("PRIMARY");

                entity.ToTable("Regions_Ref");

                entity.Property(e => e.OpNo).HasColumnName("Op_No");

                entity.Property(e => e.CountryNo).HasColumnName("Country_No");

                entity.Property(e => e.DateOpen)
                    .HasMaxLength(10)
                    .HasColumnName("Date_Open");

                entity.Property(e => e.OriginDate).HasColumnName("Origin_Date");

                entity.Property(e => e.PcName)
                    .HasMaxLength(50)
                    .HasColumnName("PC_Name");

                entity.Property(e => e.PcUserName)
                    .HasMaxLength(50)
                    .HasColumnName("PC_User_Name");

                entity.Property(e => e.RegionName)
                    .HasMaxLength(400)
                    .HasColumnName("Region_Name");

                entity.Property(e => e.RegionNameLatin)
                    .HasMaxLength(400)
                    .HasColumnName("Region_Name_Latin");

                entity.Property(e => e.RegionNo).HasColumnName("Region_No");

                entity.Property(e => e.Remarks).HasMaxLength(200);

                entity.Property(e => e.Status).HasMaxLength(2);

                entity.Property(e => e.StatusDate).HasColumnName("Status_Date");

                entity.Property(e => e.UpdateDate).HasColumnName("Update_Date");

                entity.Property(e => e.UserNoCreated).HasColumnName("User_No_Created");

                entity.Property(e => e.UserNoUpdate).HasColumnName("User_No_Update");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserNo)
                    .HasName("PRIMARY");

                entity.Property(e => e.UserNo).HasColumnName("User_No");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.AllAccount).HasColumnName("All_Account");

                entity.Property(e => e.AllActive).HasColumnName("All_Active");

                entity.Property(e => e.AllCost).HasColumnName("All_Cost");

                entity.Property(e => e.AllProject).HasColumnName("All_Project");

                entity.Property(e => e.ArabMode).HasColumnName("Arab_Mode");

                entity.Property(e => e.DateOpen)
                    .HasMaxLength(10)
                    .HasColumnName("Date_Open");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Mobile).HasMaxLength(100);

                entity.Property(e => e.OriginDate)
                    .HasColumnType("datetime(6)")
                    .HasColumnName("Origin_Date");

                entity.Property(e => e.PcName)
                    .HasMaxLength(60)
                    .HasColumnName("PC_Name");

                entity.Property(e => e.PcUserName)
                    .HasMaxLength(60)
                    .HasColumnName("PC_User_Name");

                entity.Property(e => e.Remarks).HasMaxLength(200);

                entity.Property(e => e.Status).HasMaxLength(2);

                entity.Property(e => e.StatusDate)
                    .HasColumnType("datetime(6)")
                    .HasColumnName("Status_Date");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime(6)")
                    .HasColumnName("Update_Date");

                entity.Property(e => e.UserCap).HasColumnName("User_Cap");

                entity.Property(e => e.UserLoginName)
                    .HasMaxLength(200)
                    .HasColumnName("User_Login_Name");

                entity.Property(e => e.UserName)
                    .HasMaxLength(200)
                    .HasColumnName("User_Name");

                entity.Property(e => e.UserNameLatin)
                    .HasMaxLength(200)
                    .HasColumnName("User_Name_Latin");

                entity.Property(e => e.UserNoCreated).HasColumnName("User_No_Created");

                entity.Property(e => e.UserNoUpdate).HasColumnName("User_No_Update");

                entity.Property(e => e.UserPass)
                    .HasMaxLength(100)
                    .HasColumnName("User_Pass");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

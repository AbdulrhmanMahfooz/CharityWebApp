using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CharityApp.EndwomentData;

public partial class EndowmentDbContext : DbContext
{
    public EndowmentDbContext()
    {
    }

    public EndowmentDbContext(DbContextOptions<EndowmentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bank> Banks { get; set; }

    public virtual DbSet<BanksRef> BanksRefs { get; set; }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<BranchesRef> BranchesRefs { get; set; }

    public virtual DbSet<CitiesRef> CitiesRefs { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<CountriesRef> CountriesRefs { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<CurrenciesRef> CurrenciesRefs { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomersRef> CustomersRefs { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<DistrictsRef> DistrictsRefs { get; set; }

    public virtual DbSet<DocType> DocTypes { get; set; }

    public virtual DbSet<EndomentAccount> EndomentAccounts { get; set; }

    public virtual DbSet<EndomentAccountsRef> EndomentAccountsRefs { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<RegionsRef> RegionsRefs { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<SettingModify> SettingModifies { get; set; }

    public virtual DbSet<Sysdiagram> Sysdiagrams { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersPrivilege> UsersPrivileges { get; set; }

    public virtual DbSet<UsersRef> UsersRefs { get; set; }

    public virtual DbSet<VoucherEndomentHeader> VoucherEndomentHeaders { get; set; }

    public virtual DbSet<VoucherEndomentHeaderRef> VoucherEndomentHeaderRefs { get; set; }

    public virtual DbSet<VoucherEndomentLine> VoucherEndomentLines { get; set; }

    public virtual DbSet<VoucherEndomentLinesRef> VoucherEndomentLinesRefs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=db-mysql-fra1-22087-do-user-13921736-0.b.db.ondigitalocean.com;username=doadmin;password=AVNS_EDhriF16LWiSS6233Wj;port=25060;database=endowment_db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bank>(entity =>
        {
            entity.HasKey(e => e.BankNo).HasName("PRIMARY");
        });

        modelBuilder.Entity<BanksRef>(entity =>
        {
            entity.HasKey(e => e.OpNo).HasName("PRIMARY");
        });

        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.BranchNo).HasName("PRIMARY");
        });

        modelBuilder.Entity<BranchesRef>(entity =>
        {
            entity.HasKey(e => e.OpNo).HasName("PRIMARY");
        });

        modelBuilder.Entity<CitiesRef>(entity =>
        {
            entity.HasKey(e => e.OpNo).HasName("PRIMARY");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityNo).HasName("PRIMARY");
        });

        modelBuilder.Entity<CountriesRef>(entity =>
        {
            entity.HasKey(e => e.OpNo).HasName("PRIMARY");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryNo).HasName("PRIMARY");
        });

        modelBuilder.Entity<CurrenciesRef>(entity =>
        {
            entity.HasKey(e => e.SeqOp).HasName("PRIMARY");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.CurrencyNo).HasName("PRIMARY");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustNo).HasName("PRIMARY");
        });

        modelBuilder.Entity<CustomersRef>(entity =>
        {
            entity.HasKey(e => e.OpNo).HasName("PRIMARY");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.DistrictNo).HasName("PRIMARY");
        });

        modelBuilder.Entity<DistrictsRef>(entity =>
        {
            entity.HasKey(e => e.OpNo).HasName("PRIMARY");
        });

        modelBuilder.Entity<DocType>(entity =>
        {
            entity.HasKey(e => e.TypeCode).HasName("PRIMARY");
        });

        modelBuilder.Entity<EndomentAccount>(entity =>
        {
            entity.HasKey(e => e.IdNo).HasName("PRIMARY");
        });

        modelBuilder.Entity<EndomentAccountsRef>(entity =>
        {
            entity.HasKey(e => e.OpNo).HasName("PRIMARY");
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.HasKey(e => e.PaymentNo).HasName("PRIMARY");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionNo).HasName("PRIMARY");
        });

        modelBuilder.Entity<RegionsRef>(entity =>
        {
            entity.HasKey(e => e.OpNo).HasName("PRIMARY");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.CompanyNo).HasName("PRIMARY");

            entity.Property(e => e.CompanyNo).IsFixedLength();
            entity.Property(e => e.DateCalendar).IsFixedLength();
        });

        modelBuilder.Entity<SettingModify>(entity =>
        {
            entity.HasKey(e => e.SeqOp).HasName("PRIMARY");

            entity.Property(e => e.CompanyNo).IsFixedLength();
            entity.Property(e => e.DateCalendar).IsFixedLength();
        });

        modelBuilder.Entity<Sysdiagram>(entity =>
        {
            entity.HasKey(e => e.DiagramId).HasName("PRIMARY");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserNo).HasName("PRIMARY");
        });

        modelBuilder.Entity<UsersPrivilege>(entity =>
        {
            entity.HasKey(e => e.Index).HasName("PRIMARY");
        });

        modelBuilder.Entity<UsersRef>(entity =>
        {
            entity.HasKey(e => e.OpNo).HasName("PRIMARY");
        });

        modelBuilder.Entity<VoucherEndomentHeader>(entity =>
        {
            entity.HasKey(e => new { e.BranchNo, e.VoucherNo }).HasName("PRIMARY");
        });

        modelBuilder.Entity<VoucherEndomentHeaderRef>(entity =>
        {
            entity.HasKey(e => e.OpNo).HasName("PRIMARY");
        });

        modelBuilder.Entity<VoucherEndomentLine>(entity =>
        {
            entity.HasKey(e => new { e.BranchNo, e.VoucherNo, e.LineNo }).HasName("PRIMARY");
        });

        modelBuilder.Entity<VoucherEndomentLinesRef>(entity =>
        {
            entity.HasKey(e => e.OpNo).HasName("PRIMARY");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

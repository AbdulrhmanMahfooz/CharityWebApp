using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CharityApp.testModels
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
            modelBuilder.Entity<Branch>(entity =>
            {
                entity.HasKey(e => e.BranchNo)
                    .HasName("PRIMARY");

                entity.Property(e => e.VatReg).HasDefaultValueSql("'0'");

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
            });

            modelBuilder.Entity<CitiesRef>(entity =>
            {
                entity.HasKey(e => e.OpNo)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.CityNo)
                    .HasName("PRIMARY");

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
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryNo)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasKey(e => e.DistrictNo)
                    .HasName("PRIMARY");

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
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.RegionNo)
                    .HasName("PRIMARY");

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
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserNo)
                    .HasName("PRIMARY");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

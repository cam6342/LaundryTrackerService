using System;
using laundry_svc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace laundry_svc.Models
{
    public partial class LaundryDBContext : DbContext
    {
        public LaundryDBContext()
        {
        }

        public LaundryDBContext(DbContextOptions<LaundryDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LaundryRuns> LaundryRuns { get; set; }
        public virtual DbSet<Supplies> Supplies { get; set; }
        public virtual DbSet<SupplyType> SupplyType { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<UnitType> UnitType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:laundry-svc.database.windows.net,1433;Initial Catalog=LaundryDB;Persist Security Info=False;User ID=cmarasco;Password=b8V989YBbgac;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<LaundryRuns>(entity =>
            {
                entity.HasKey(e => e.LaundryRunId);

                entity.Property(e => e.LaundryRunId).ValueGeneratedNever();

                entity.Property(e => e.RunEnd).HasColumnType("datetime");

                entity.Property(e => e.RunStart).HasColumnType("datetime");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.LaundryRuns)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LaundryRuns_ToUnit");
            });

            modelBuilder.Entity<Supplies>(entity =>
            {
                entity.HasKey(e => e.SupplyId)
                    .HasName("PK__Supplies__7CDD6CAECDFF960D");

                entity.Property(e => e.SupplyId).ValueGeneratedNever();

                entity.HasOne(d => d.SupplyType)
                    .WithMany(p => p.Supplies)
                    .HasForeignKey(d => d.SupplyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Supplies_ToSupplyType");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Supplies)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Supplies_ToUnit");
            });

            modelBuilder.Entity<SupplyType>(entity =>
            {
                entity.Property(e => e.SupplyTypeId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.Property(e => e.UnitId).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.UnitType)
                    .WithMany(p => p.Unit)
                    .HasForeignKey(d => d.UnitTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Unit_ToUnitType");
            });

            modelBuilder.Entity<UnitType>(entity =>
            {
                entity.Property(e => e.UnitTypeId).ValueGeneratedNever();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}

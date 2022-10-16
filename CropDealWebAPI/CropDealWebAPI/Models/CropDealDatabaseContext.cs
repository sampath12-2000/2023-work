using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CropDealWebAPI.Models
{
    public partial class CropDealDatabaseContext : DbContext
    {
        public CropDealDatabaseContext()
        {
        }

        public CropDealDatabaseContext(DbContextOptions<CropDealDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Crop> Crops { get; set; }
        public virtual DbSet<CropOnSale> CropOnSales { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=.;Database=CropDealDatabase;Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.AdminPassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdminUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Crop>(entity =>
            {
                entity.ToTable("Crop");

                entity.Property(e => e.CropId).HasColumnName("CropID");

                entity.Property(e => e.CropImage)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CropName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CropOnSale>(entity =>
            {
                entity.HasKey(e => e.CropSaleId)
                    .HasName("PK__CropOnSa__DA8EB9AF0354DD7A");

                entity.ToTable("CropOnSale");

                entity.Property(e => e.CropSaleId).HasColumnName("CropSaleID");

                entity.Property(e => e.CropId).HasColumnName("CropID");

                entity.Property(e => e.CropName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CropType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FarmerId).HasColumnName("FarmerID");

                entity.HasOne(d => d.Crop)
                    .WithMany(p => p.CropOnSales)
                    .HasForeignKey(d => d.CropId)
                    .HasConstraintName("fk_CropID");

                entity.HasOne(d => d.Farmer)
                    .WithMany(p => p.CropOnSales)
                    .HasForeignKey(d => d.FarmerId)
                    .HasConstraintName("fk_FarmerID");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.CropName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CropType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DealerId).HasColumnName("DealerID");

                entity.Property(e => e.FarmerId).HasColumnName("FarmerID");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.Review)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dealer)
                    .WithMany(p => p.InvoiceDealers)
                    .HasForeignKey(d => d.DealerId)
                    .HasConstraintName("fk_DealerID1");

                entity.HasOne(d => d.Farmer)
                    .WithMany(p => p.InvoiceFarmers)
                    .HasForeignKey(d => d.FarmerId)
                    .HasConstraintName("fk_FarmerID1");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserProf__1788CCAC3B13F0B3");

                entity.ToTable("UserProfile");

                entity.HasIndex(e => e.UserAccNo, "UQ__UserProf__01507BF2C9C34348")
                    .IsUnique();

                entity.HasIndex(e => e.UserPhoneNo, "UQ__UserProf__687B5AF54D77F64F")
                    .IsUnique();

                entity.HasIndex(e => e.UserIfsc, "UQ__UserProf__9EB2242E612265E6")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserAddress)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserBankName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserIfsc)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UserIFSC");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPhoneNo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Active')");

                entity.Property(e => e.UserType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

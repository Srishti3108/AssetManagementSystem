using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AssetManagementSystem.Models
{
    public partial class assetManagementContext : DbContext
    {
        public assetManagementContext()
        {
        }

        public assetManagementContext(DbContextOptions<assetManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asset> Assets { get; set; } = null!;
        public virtual DbSet<AssetAudit> AssetAudits { get; set; } = null!;
        public virtual DbSet<AssetBorrowing> AssetBorrowings { get; set; } = null!;
        public virtual DbSet<AssetServiceRequest> AssetServiceRequests { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-DDKO0J5;Database=assetManagement;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>(entity =>
            {
                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.AssetCategory)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AssetModel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AssetName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AssetValue).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExpiryDate).HasColumnType("date");

                entity.Property(e => e.ManufacturingDate).HasColumnType("date");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Available')");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<AssetAudit>(entity =>
            {
                entity.HasKey(e => e.AuditId)
                    .HasName("PK__AssetAud__A17F23B886884626");

                entity.ToTable("AssetAudit");

                entity.Property(e => e.AuditId).HasColumnName("AuditID");

                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.AuditDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Pending')");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetAudits)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__AssetAudi__Asset__4E88ABD4");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AssetAudits)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__AssetAudi__Emplo__4F7CD00D");
            });

            modelBuilder.Entity<AssetBorrowing>(entity =>
            {
                entity.HasKey(e => e.BorrowId)
                    .HasName("PK__AssetBor__4295F85FA1E541D3");

                entity.ToTable("AssetBorrowing");

                entity.Property(e => e.BorrowId).HasColumnName("BorrowID");

                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.BorrowDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Borrowed')");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetBorrowings)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__AssetBorr__Asset__440B1D61");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AssetBorrowings)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__AssetBorr__Emplo__4316F928");
            });

            modelBuilder.Entity<AssetServiceRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK__AssetSer__33A8519A7658C314");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.IssueType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RequestDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Pending')");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetServiceRequests)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__AssetServ__Asset__48CFD27E");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AssetServiceRequests)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__AssetServ__Emplo__49C3F6B7");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Employee__A9D105341A32CA44")
                    .IsUnique();

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

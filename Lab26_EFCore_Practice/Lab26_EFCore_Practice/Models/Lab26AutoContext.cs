using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab26_EFCore_Practice.Models;

public partial class Lab26AutoContext : DbContext
{
    public Lab26AutoContext()
    {
    }

    public Lab26AutoContext(DbContextOptions<Lab26AutoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auto> Autos { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Magazine> Magazines { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=USER-PC;Initial Catalog=Lab26_Auto;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auto>(entity =>
        {
            entity.ToTable("Auto");

            entity.Property(e => e.AutoId).HasColumnName("AutoID");
            entity.Property(e => e.AutoModel)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("money");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Client");

            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.ClientName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ClientSname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ClientSName");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Role");
        });

        modelBuilder.Entity<Magazine>(entity =>
        {
            entity.ToTable("Magazine");

            entity.Property(e => e.MagazineId).HasColumnName("MagazineID");
            entity.Property(e => e.AutoId).HasColumnName("AutoID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

            entity.HasOne(d => d.Auto).WithMany(p => p.Magazines)
                .HasForeignKey(d => d.AutoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Magazine_Auto");

            entity.HasOne(d => d.Client).WithMany(p => p.Magazines)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Magazine_Client");

            entity.HasOne(d => d.Employee).WithMany(p => p.Magazines)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Magazine_Employee");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

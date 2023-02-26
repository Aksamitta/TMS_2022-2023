using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab23_Aksana.Patrubeika_ORM.Models;

public partial class OrmtestDbfirstContext : DbContext
{
    public OrmtestDbfirstContext()
    {
    }

    public OrmtestDbfirstContext(DbContextOptions<OrmtestDbfirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=USER-PC;Initial Catalog=ORMTest_DBFirst;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CustomerDiscount).HasColumnName("Customer_discount");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Customer_Name");
            entity.Property(e => e.StoreId).HasColumnName("StoreID");

            entity.HasOne(d => d.Store).WithMany(p => p.Customers)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Store");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.ToTable("Store");

            entity.Property(e => e.StoreId).HasColumnName("StoreID");
            entity.Property(e => e.StoreName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Store_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

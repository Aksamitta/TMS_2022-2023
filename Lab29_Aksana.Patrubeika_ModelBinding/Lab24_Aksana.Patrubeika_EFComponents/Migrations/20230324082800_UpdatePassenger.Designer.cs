﻿// <auto-generated />
using System;
using Lab24_Aksana.Patrubeika_EFComponents.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab24_Aksana.Patrubeika_EFComponents.Migrations
{
    [DbContext(typeof(AirLineContext))]
    [Migration("20230324082800_UpdatePassenger")]
    partial class UpdatePassenger
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lab24_Aksana.Patrubeika_EFComponents.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CompanyID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Lab24_Aksana.Patrubeika_EFComponents.Models.PassInTrip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PassengerId")
                        .HasColumnType("int")
                        .HasColumnName("PassengerID");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PassengerId");

                    b.HasIndex("TripId");

                    b.ToTable("PassInTrips");
                });

            modelBuilder.Entity("Lab24_Aksana.Patrubeika_EFComponents.Models.Passenger", b =>
                {
                    b.Property<int>("PassengerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PassengerID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PassengerId"));

                    b.Property<DateTime>("Birth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PassengerId");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("Lab24_Aksana.Patrubeika_EFComponents.Models.Trip", b =>
                {
                    b.Property<int>("TripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TripID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TripId"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Plane")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TownFrom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TownTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TripId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("Lab24_Aksana.Patrubeika_EFComponents.Models.PassInTrip", b =>
                {
                    b.HasOne("Lab24_Aksana.Patrubeika_EFComponents.Models.Passenger", "Passenger")
                        .WithMany()
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab24_Aksana.Patrubeika_EFComponents.Models.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passenger");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("Lab24_Aksana.Patrubeika_EFComponents.Models.Trip", b =>
                {
                    b.HasOne("Lab24_Aksana.Patrubeika_EFComponents.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });
#pragma warning restore 612, 618
        }
    }
}

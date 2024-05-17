﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Practices.Data;

#nullable disable

namespace Practices.Data.Migrations
{
    [DbContext(typeof(PracticesContext))]
    [Migration("20240517111741_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Practices.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 90.0,
                            CompanyId = 1,
                            DepartureDate = new DateTime(2023, 1, 3, 13, 54, 48, 0, DateTimeKind.Unspecified),
                            Destination = "Japón",
                            Origin = "España",
                            ReturnDate = new DateTime(2024, 1, 3, 13, 54, 48, 0, DateTimeKind.Unspecified),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Amount = 70.0,
                            CompanyId = 2,
                            DepartureDate = new DateTime(2023, 1, 3, 13, 54, 48, 0, DateTimeKind.Unspecified),
                            Destination = "EEUU",
                            Origin = "España",
                            ReturnDate = new DateTime(2024, 1, 3, 13, 54, 48, 0, DateTimeKind.Unspecified),
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Amount = 30.0,
                            CompanyId = 1,
                            DepartureDate = new DateTime(2023, 1, 3, 13, 54, 48, 0, DateTimeKind.Unspecified),
                            Destination = "Islas Canarias",
                            Origin = "Argentina",
                            ReturnDate = new DateTime(2024, 1, 3, 13, 54, 48, 0, DateTimeKind.Unspecified),
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Practices.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EmployeeCount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FoundationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Website")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmployeeCount = "100",
                            FoundationDate = new DateTime(2022, 1, 3, 13, 54, 18, 0, DateTimeKind.Unspecified),
                            Name = "Ryanair",
                            Password = "ryanair12345",
                            Website = true
                        },
                        new
                        {
                            Id = 2,
                            EmployeeCount = "50",
                            FoundationDate = new DateTime(2021, 1, 3, 13, 54, 48, 0, DateTimeKind.Unspecified),
                            Name = "Vueling",
                            Password = "vueling12345",
                            Website = false
                        });
                });

            modelBuilder.Entity("Practices.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DNI = "32452464D",
                            Email = "mario@gmail.com",
                            Name = "Mario",
                            Password = "mario12345",
                            Phone = "4574"
                        },
                        new
                        {
                            Id = 2,
                            DNI = "23523562D",
                            Email = "carlos@gmail.com",
                            Name = "Carlos",
                            Password = "carlos12345",
                            Phone = "4567477"
                        },
                        new
                        {
                            Id = 3,
                            DNI = "23526445X",
                            Email = "fernando@gmail.com",
                            Name = "Fernando",
                            Password = "fernando12345",
                            Phone = "4745"
                        },
                        new
                        {
                            Id = 4,
                            DNI = "52353425D",
                            Email = "eduardo@gmail.com",
                            Name = "Eduardo",
                            Password = "eduardo12345",
                            Phone = "4574548"
                        });
                });

            modelBuilder.Entity("Practices.Models.Booking", b =>
                {
                    b.HasOne("Practices.Models.Company", null)
                        .WithMany("Flights")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Practices.Models.User", null)
                        .WithMany("MyBookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Practices.Models.Company", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("Practices.Models.User", b =>
                {
                    b.Navigation("MyBookings");
                });
#pragma warning restore 612, 618
        }
    }
}

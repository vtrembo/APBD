﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using test2.Models;

namespace test2.Migrations
{
    [DbContext(typeof(MainDbContext))]
    partial class MainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("test2.Models.CityDict", b =>
                {
                    b.Property<int>("IdCityDict")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdCityDict");

                    b.ToTable("CityDict");

                    b.HasData(
                        new
                        {
                            IdCityDict = 1,
                            City = "Warsaw"
                        },
                        new
                        {
                            IdCityDict = 2,
                            City = "Odessa"
                        });
                });

            modelBuilder.Entity("test2.Models.Flight", b =>
                {
                    b.Property<int>("IdFlight")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("FlightDate")
                        .HasColumnType("datetime");

                    b.Property<int>("IdCityDict")
                        .HasColumnType("int");

                    b.Property<int>("IdPlane")
                        .HasColumnType("int");

                    b.HasKey("IdFlight");

                    b.HasIndex("IdCityDict");

                    b.HasIndex("IdPlane");

                    b.ToTable("Flight");

                    b.HasData(
                        new
                        {
                            IdFlight = 1,
                            FlightDate = new DateTime(2021, 6, 22, 11, 7, 46, 507, DateTimeKind.Local).AddTicks(657),
                            IdCityDict = 1,
                            IdPlane = 1
                        },
                        new
                        {
                            IdFlight = 2,
                            FlightDate = new DateTime(2021, 6, 22, 11, 7, 46, 509, DateTimeKind.Local).AddTicks(9652),
                            IdCityDict = 2,
                            IdPlane = 2
                        });
                });

            modelBuilder.Entity("test2.Models.FlightPassenger", b =>
                {
                    b.Property<int>("IdFlight")
                        .HasColumnType("int");

                    b.Property<int>("IdPassenger")
                        .HasColumnType("int");

                    b.HasKey("IdFlight", "IdPassenger");

                    b.HasIndex("IdPassenger");

                    b.ToTable("FlightPassenger");

                    b.HasData(
                        new
                        {
                            IdFlight = 1,
                            IdPassenger = 1
                        });
                });

            modelBuilder.Entity("test2.Models.Passenger", b =>
                {
                    b.Property<int>("IdPassenger")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("PassportNum")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdPassenger");

                    b.ToTable("Passenger");

                    b.HasData(
                        new
                        {
                            IdPassenger = 1,
                            FirstName = "Valerii",
                            LastName = "Trembovetsky",
                            PassportNum = "Not today"
                        },
                        new
                        {
                            IdPassenger = 2,
                            FirstName = "Kris",
                            LastName = "Delamoi",
                            PassportNum = "LD232954"
                        });
                });

            modelBuilder.Entity("test2.Models.Plane", b =>
                {
                    b.Property<int>("IdPlane")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaxSeats")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdPlane");

                    b.ToTable("Plane");

                    b.HasData(
                        new
                        {
                            IdPlane = 1,
                            MaxSeats = 56,
                            Name = "Bojong"
                        },
                        new
                        {
                            IdPlane = 2,
                            MaxSeats = 34,
                            Name = "QouterPlus"
                        });
                });

            modelBuilder.Entity("test2.Models.Flight", b =>
                {
                    b.HasOne("test2.Models.CityDict", "cityDict")
                        .WithMany("Flights")
                        .HasForeignKey("IdCityDict")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("test2.Models.Plane", "plane")
                        .WithMany("Flights")
                        .HasForeignKey("IdPlane")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("cityDict");

                    b.Navigation("plane");
                });

            modelBuilder.Entity("test2.Models.FlightPassenger", b =>
                {
                    b.HasOne("test2.Models.Flight", "flight")
                        .WithMany("FlightPassengers")
                        .HasForeignKey("IdFlight")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("test2.Models.Passenger", "passenger")
                        .WithMany("FlightPassengers")
                        .HasForeignKey("IdPassenger")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("flight");

                    b.Navigation("passenger");
                });

            modelBuilder.Entity("test2.Models.CityDict", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("test2.Models.Flight", b =>
                {
                    b.Navigation("FlightPassengers");
                });

            modelBuilder.Entity("test2.Models.Passenger", b =>
                {
                    b.Navigation("FlightPassengers");
                });

            modelBuilder.Entity("test2.Models.Plane", b =>
                {
                    b.Navigation("Flights");
                });
#pragma warning restore 612, 618
        }
    }
}

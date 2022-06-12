﻿// <auto-generated />
using System;
using InventoryManagementAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InventoryManagementAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220611205150_dbUpdateSp2")]
    partial class dbUpdateSp2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InventoryManagementAPI.Models.Airline", b =>
                {
                    b.Property<int>("AirlineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AirlineLogo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AirlineName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.HasKey("AirlineID");

                    b.ToTable("Airline");
                });

            modelBuilder.Entity("InventoryManagementAPI.Models.AirlineSchedule", b =>
                {
                    b.Property<int>("AirlineScheduleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AirlineID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FlightName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlightNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FromLocation")
                        .HasColumnType("int");

                    b.Property<bool>("IsDaily")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSpecificDays")
                        .HasColumnType("bit");

                    b.Property<bool>("IsWeekdays")
                        .HasColumnType("bit");

                    b.Property<bool>("IsWeekends")
                        .HasColumnType("bit");

                    b.Property<string>("MealType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ToLocation")
                        .HasColumnType("int");

                    b.HasKey("AirlineScheduleID");

                    b.HasIndex("AirlineID");

                    b.HasIndex("FromLocation");

                    b.HasIndex("ToLocation");

                    b.ToTable("AirlineSchedule");
                });

            modelBuilder.Entity("InventoryManagementAPI.Models.AirlineScheduleDayReln", b =>
                {
                    b.Property<int>("RefID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AirlineID")
                        .HasColumnType("int");

                    b.Property<int>("AirlineScheduleID")
                        .HasColumnType("int");

                    b.Property<string>("weekDay")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RefID");

                    b.HasIndex("AirlineID");

                    b.ToTable("AirlineScheduleDayReln");
                });

            modelBuilder.Entity("InventoryManagementAPI.Models.AirlineSeatCostReln", b =>
                {
                    b.Property<int>("RefID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FlightID")
                        .HasColumnType("int");

                    b.Property<int>("NoOfSeats")
                        .HasColumnType("int");

                    b.Property<string>("SeatType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Tax")
                        .HasColumnType("float");

                    b.Property<double>("TicketCost")
                        .HasColumnType("float");

                    b.HasKey("RefID");

                    b.HasIndex("FlightID");

                    b.ToTable("AirlineSeatCostReln");
                });

            modelBuilder.Entity("InventoryManagementAPI.Models.Airport", b =>
                {
                    b.Property<int>("AirportID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AirportCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AirportName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AirportID");

                    b.ToTable("Airport");
                });

            modelBuilder.Entity("InventoryManagementAPI.Models.AirlineSchedule", b =>
                {
                    b.HasOne("InventoryManagementAPI.Models.Airline", "AirlineRef")
                        .WithMany()
                        .HasForeignKey("AirlineID");

                    b.HasOne("InventoryManagementAPI.Models.Airport", "AirportFrom")
                        .WithMany()
                        .HasForeignKey("FromLocation");

                    b.HasOne("InventoryManagementAPI.Models.Airport", "AirportTo")
                        .WithMany()
                        .HasForeignKey("ToLocation");

                    b.Navigation("AirlineRef");

                    b.Navigation("AirportFrom");

                    b.Navigation("AirportTo");
                });

            modelBuilder.Entity("InventoryManagementAPI.Models.AirlineScheduleDayReln", b =>
                {
                    b.HasOne("InventoryManagementAPI.Models.AirlineSchedule", "AirlineSchedule")
                        .WithMany()
                        .HasForeignKey("AirlineID");

                    b.Navigation("AirlineSchedule");
                });

            modelBuilder.Entity("InventoryManagementAPI.Models.AirlineSeatCostReln", b =>
                {
                    b.HasOne("InventoryManagementAPI.Models.AirlineSchedule", "AirlineScheduleRef")
                        .WithMany()
                        .HasForeignKey("FlightID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AirlineScheduleRef");
                });
#pragma warning restore 612, 618
        }
    }
}

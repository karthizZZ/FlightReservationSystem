﻿// <auto-generated />
using System;
using BookingManagementAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookingManagementAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220616125537_BookingTableUpdate2")]
    partial class BookingTableUpdate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookingManagementAPI.Models.BookingDetails", b =>
                {
                    b.Property<int>("BookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AirlineID")
                        .HasColumnType("int");

                    b.Property<string>("AirlineName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedUserID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlightNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromAirport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("bit");

                    b.Property<string>("MealType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoOfPassengers")
                        .HasColumnType("int");

                    b.Property<string>("PNR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeatType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToAirport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToLocation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookingID");

                    b.ToTable("BookingDetails");
                });

            modelBuilder.Entity("BookingManagementAPI.Models.BookingPassengerReln", b =>
                {
                    b.Property<int>("RefID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("BookingRefNumber")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassengerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RefID");

                    b.HasIndex("BookingRefNumber");

                    b.ToTable("PassengerDetails");
                });

            modelBuilder.Entity("BookingManagementAPI.Models.BookingSeatNoReln", b =>
                {
                    b.Property<int>("RefID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookingNumber")
                        .HasColumnType("int");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.HasKey("RefID");

                    b.HasIndex("BookingNumber");

                    b.ToTable("BookingSeatNumberRelation");
                });

            modelBuilder.Entity("BookingManagementAPI.Models.BookingPassengerReln", b =>
                {
                    b.HasOne("BookingManagementAPI.Models.BookingDetails", "BookingDetailsReference")
                        .WithMany()
                        .HasForeignKey("BookingRefNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookingDetailsReference");
                });

            modelBuilder.Entity("BookingManagementAPI.Models.BookingSeatNoReln", b =>
                {
                    b.HasOne("BookingManagementAPI.Models.BookingDetails", "BookingDetailsRef")
                        .WithMany()
                        .HasForeignKey("BookingNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookingDetailsRef");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TelstarLogistics.Data;

#nullable disable

namespace TelstarLogistics.Migrations
{
    [DbContext(typeof(TelstarLogisticsContext))]
    partial class TelstarLogisticsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TelstarLogistics.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<string>("CargoCenterLocations")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CustEmail")
                        .HasColumnType("text");

                    b.Property<string>("CustName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("CustPhone")
                        .HasColumnType("int");

                    b.Property<DateTime>("Handover")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(18,0)");

                    b.Property<decimal>("Length")
                        .HasColumnType("decimal(18,0)");

                    b.Property<string>("ParcelType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Recommended")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,0)");

                    b.Property<decimal>("Width")
                        .HasColumnType("decimal(18,0)");

                    b.ToTable("Booking", (string)null);
                });

            modelBuilder.Entity("TelstarLogistics.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("City", (string)null);
                });

            modelBuilder.Entity("TelstarLogistics.Models.Route", b =>
                {
                    b.Property<int>("City1Id")
                        .HasColumnType("int");

                    b.Property<int>("City2Id")
                        .HasColumnType("int");

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<string>("TransportType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,0)");

                    b.ToTable("Route", (string)null);
                });

            modelBuilder.Entity("TelstarLogistics.Models.User", b =>
                {
                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("User", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}

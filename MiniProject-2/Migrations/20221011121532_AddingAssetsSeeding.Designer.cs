﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniProject_2;

#nullable disable

namespace MiniProject_2.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20221011121532_AddingAssetsSeeding")]
    partial class AddingAssetsSeeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MiniProject_2.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<double>("PriceUSD")
                        .HasColumnType("float");

                    b.Property<DateTime>("PurchesDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.ToTable("Assets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Asus",
                            Model = "W324",
                            OfficeId = 3,
                            PriceUSD = 2222.0,
                            PurchesDate = new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Computer"
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Lenovo",
                            Model = "Yoga 730",
                            OfficeId = 2,
                            PriceUSD = 1230.0,
                            PurchesDate = new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Computer"
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Lenovo",
                            Model = "Yoga 430",
                            OfficeId = 2,
                            PriceUSD = 1333.0,
                            PurchesDate = new DateTime(2021, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Computer"
                        },
                        new
                        {
                            Id = 4,
                            Brand = "HP",
                            Model = "EliteBook",
                            OfficeId = 1,
                            PriceUSD = 2551.0,
                            PurchesDate = new DateTime(2022, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Computer"
                        },
                        new
                        {
                            Id = 5,
                            Brand = "HP",
                            Model = "EliteBook",
                            OfficeId = 3,
                            PriceUSD = 2442.0,
                            PurchesDate = new DateTime(2021, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Computer"
                        },
                        new
                        {
                            Id = 6,
                            Brand = "Acer",
                            Model = "One",
                            OfficeId = 3,
                            PriceUSD = 675.0,
                            PurchesDate = new DateTime(2007, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Computer"
                        },
                        new
                        {
                            Id = 7,
                            Brand = "iPhone",
                            Model = "8",
                            OfficeId = 1,
                            PriceUSD = 1111.0,
                            PurchesDate = new DateTime(2019, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Phone"
                        },
                        new
                        {
                            Id = 8,
                            Brand = "iPhone",
                            Model = "11",
                            OfficeId = 1,
                            PriceUSD = 923.0,
                            PurchesDate = new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Phone"
                        },
                        new
                        {
                            Id = 9,
                            Brand = "iPhone",
                            Model = "X",
                            OfficeId = 3,
                            PriceUSD = 875.0,
                            PurchesDate = new DateTime(2020, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Phone"
                        },
                        new
                        {
                            Id = 10,
                            Brand = "Motorola",
                            Model = "Razr",
                            OfficeId = 2,
                            PriceUSD = 533.0,
                            PurchesDate = new DateTime(2020, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Phone"
                        },
                        new
                        {
                            Id = 11,
                            Brand = "Sony",
                            Model = "Xperia",
                            OfficeId = 2,
                            PriceUSD = 463.0,
                            PurchesDate = new DateTime(2011, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Phone"
                        });
                });

            modelBuilder.Entity("MiniProject_2.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("ConvertPriceFromUSD")
                        .HasColumnType("float");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Offices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConvertPriceFromUSD = 0.84999999999999998,
                            Country = "England",
                            Currency = "GBP"
                        },
                        new
                        {
                            Id = 2,
                            ConvertPriceFromUSD = 10.42,
                            Country = "Sweden",
                            Currency = "SEK"
                        },
                        new
                        {
                            Id = 3,
                            ConvertPriceFromUSD = 1.0,
                            Country = "USA",
                            Currency = "USD"
                        });
                });

            modelBuilder.Entity("MiniProject_2.Asset", b =>
                {
                    b.HasOne("MiniProject_2.Office", "Office")
                        .WithMany("Assets")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Office");
                });

            modelBuilder.Entity("MiniProject_2.Office", b =>
                {
                    b.Navigation("Assets");
                });
#pragma warning restore 612, 618
        }
    }
}

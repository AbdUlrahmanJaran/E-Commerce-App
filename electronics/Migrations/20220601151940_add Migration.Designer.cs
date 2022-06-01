﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using electronics.Data;

namespace Electronics.Migrations
{
    [DbContext(typeof(ElectronicsDbContext))]
    [Migration("20220601151940_add Migration")]
    partial class addMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Electronics.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Info = "A lot of Laptops",
                            Name = "Laptops"
                        },
                        new
                        {
                            Id = 2,
                            Info = "A lot of Mobiles",
                            Name = "Mobiles"
                        });
                });

            modelBuilder.Entity("Electronics.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutProduct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("MakerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AboutProduct = "1tb SSD storage, 2x8 ddr4 ram 3000mhz, i5-10th, nvidia mx230",
                            CategoryId = 1,
                            MakerName = "Asus",
                            Price = 799.89999999999998,
                            ReleaseDate = new DateTime(2022, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubName = "XO2022"
                        },
                        new
                        {
                            Id = 2,
                            AboutProduct = "500gb SSD storage, 8 ddr4 ram 3666mhz",
                            CategoryId = 1,
                            MakerName = "Apple",
                            Price = 999.89999999999998,
                            ReleaseDate = new DateTime(2019, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubName = "Mac 2019"
                        },
                        new
                        {
                            Id = 3,
                            AboutProduct = "128gb storage",
                            CategoryId = 2,
                            MakerName = "Apple",
                            Price = 650.0,
                            ReleaseDate = new DateTime(2019, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubName = "Iphone 11"
                        },
                        new
                        {
                            Id = 4,
                            AboutProduct = "128gb storage, 6gb ram",
                            CategoryId = 2,
                            MakerName = "Poco",
                            Price = 199.90000000000001,
                            ReleaseDate = new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubName = "X3 NFC"
                        });
                });

            modelBuilder.Entity("Electronics.Models.Product", b =>
                {
                    b.HasOne("Electronics.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Electronics.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
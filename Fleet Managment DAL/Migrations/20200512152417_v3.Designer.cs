﻿// <auto-generated />
using System;
using Fleet_Managment_DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fleet_Managment_DAL.Migrations
{
    [DbContext(typeof(FleetManagmentContext))]
    [Migration("20200512152417_v3")]
    partial class v3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fleet_Managment_DAL.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Fleet_Managment_DAL.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Chassis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDateContract")
                        .HasColumnType("datetime2");

                    b.Property<int>("Fuel")
                        .HasColumnType("int");

                    b.Property<int>("Km")
                        .HasColumnType("int");

                    b.Property<int?>("ModelId")
                        .HasColumnType("int");

                    b.Property<string>("Numberplate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDateContract")
                        .HasColumnType("datetime2");

                    b.Property<string>("VehicleStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Year")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Fleet_Managment_DAL.Entities.Insurance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Insurances");
                });

            modelBuilder.Entity("Fleet_Managment_DAL.Entities.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("Fleet_Managment_DAL.Entities.TechnicalControl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("TechnicalControls");
                });

            modelBuilder.Entity("Fleet_Managment_DAL.Entities.Car", b =>
                {
                    b.HasOne("Fleet_Managment_DAL.Entities.Model", "Model")
                        .WithMany("Cars")
                        .HasForeignKey("ModelId");
                });

            modelBuilder.Entity("Fleet_Managment_DAL.Entities.Insurance", b =>
                {
                    b.HasOne("Fleet_Managment_DAL.Entities.Car", "Car")
                        .WithMany("Insurances")
                        .HasForeignKey("CarId");
                });

            modelBuilder.Entity("Fleet_Managment_DAL.Entities.Model", b =>
                {
                    b.HasOne("Fleet_Managment_DAL.Entities.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fleet_Managment_DAL.Entities.TechnicalControl", b =>
                {
                    b.HasOne("Fleet_Managment_DAL.Entities.Car", "Car")
                        .WithMany("TechnicalControls")
                        .HasForeignKey("CarId");
                });
#pragma warning restore 612, 618
        }
    }
}

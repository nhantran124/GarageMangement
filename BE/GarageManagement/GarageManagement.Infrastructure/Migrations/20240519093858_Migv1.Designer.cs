﻿// <auto-generated />
using System;
using GarageManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GarageManagement.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240519093858_Migv1")]
    partial class Migv1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GarageManagement.Domain.Entities.CategoryManagement.DepartmentDetails", b =>
                {
                    b.Property<string>("DepartmentId")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DepartmentNote")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("GarageManagement.Domain.Entities.CategoryManagement.RoleDetails", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<int>("PremissionGroupName")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("GarageManagement.Domain.Entities.CategoryManagement.Staff", b =>
                {
                    b.Property<string>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(15)");

                    b.Property<int>("AccountActive")
                        .HasColumnType("int");

                    b.Property<DateTime>("DayIn")
                        .HasColumnType("date");

                    b.Property<string>("DepartmentId")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<int>("PremissionDay")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("StaffAddress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("StaffName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("StaffPhonenumber")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("StaffId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("GarageManagement.Domain.Entities.CategoryManagement.Supplier", b =>
                {
                    b.Property<string>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("SupplierAddress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SupplierBank")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SupplierBranch")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SupplierPhonenumber")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("SupplierTax")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });
#pragma warning restore 612, 618
        }
    }
}

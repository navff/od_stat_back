﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OD_Stat.DataAccess;

namespace OD_Stat.Migrations
{
    [DbContext(typeof(OdContext))]
    [Migration("20200412064125_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("OD_Stat.Modules.Divisions.Division", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DirectorUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DivisionType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ParentDivisionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("DirectorUserId");

                    b.HasIndex("ParentDivisionId");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("OD_Stat.Modules.Geo.Addresses.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CityFiasId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CountryFiasId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RegionFiasId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SettlementFiasId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SettlementName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UnrestrictedValue")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("OD_Stat.Modules.Persons.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DivisionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OD_Stat.Modules.Divisions.Division", b =>
                {
                    b.HasOne("OD_Stat.Modules.Geo.Addresses.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OD_Stat.Modules.Persons.User", "Director")
                        .WithMany()
                        .HasForeignKey("DirectorUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OD_Stat.Modules.Divisions.Division", "ParentDivision")
                        .WithMany()
                        .HasForeignKey("ParentDivisionId");
                });

            modelBuilder.Entity("OD_Stat.Modules.Persons.User", b =>
                {
                    b.HasOne("OD_Stat.Modules.Divisions.Division", null)
                        .WithMany("Admins")
                        .HasForeignKey("DivisionId");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OD_Stat.DataAccess;

namespace OD_Stat.Migrations
{
    [DbContext(typeof(OdContext))]
    partial class OdContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.2.20159.4");

            modelBuilder.Entity("OD_Stat.Modules.Addresses.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CityFiasId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FiasId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RegionFiasId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RegionWithType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Settlement")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SettlementFiasId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UnrestrictedValue")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

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

            modelBuilder.Entity("OD_Stat.Modules.Persons.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DivisionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OD_Stat.Modules.Users.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("OD_Stat.Modules.Divisions.Division", b =>
                {
                    b.HasOne("OD_Stat.Modules.Addresses.Address", "Address")
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

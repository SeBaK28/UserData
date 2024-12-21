﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("api.Models.PlaceOfBirth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HouseNumber")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserDataId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserDataId");

                    b.ToTable("PlaceOfBirths", (string)null);
                });

            modelBuilder.Entity("api.Models.ResidentialAddres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserDataId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserDataId");

                    b.ToTable("ResidentialAddress", (string)null);
                });

            modelBuilder.Entity("api.Models.UserData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfCreateAccount")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserDatas", (string)null);
                });

            modelBuilder.Entity("api.Models.PlaceOfBirth", b =>
                {
                    b.HasOne("api.Models.UserData", "userData")
                        .WithMany("PlaceOfBirths")
                        .HasForeignKey("UserDataId");

                    b.Navigation("userData");
                });

            modelBuilder.Entity("api.Models.ResidentialAddres", b =>
                {
                    b.HasOne("api.Models.UserData", "userData")
                        .WithMany("ResidentialAddresProp")
                        .HasForeignKey("UserDataId");

                    b.Navigation("userData");
                });

            modelBuilder.Entity("api.Models.UserData", b =>
                {
                    b.Navigation("PlaceOfBirths");

                    b.Navigation("ResidentialAddresProp");
                });
#pragma warning restore 612, 618
        }
    }
}

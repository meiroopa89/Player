﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dotnetapp.Models;

#nullable disable

namespace dotnetapp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240312175359_ini112")]
    partial class ini112
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("dotnetapp.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("LibraryCardId")
                        .HasColumnType("int");

                    b.Property<int>("PublishedYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("LibraryCardId")
                        .IsUnique()
                        .HasFilter("[LibraryCardId] IS NOT NULL");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("dotnetapp.Models.LibraryCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MemberName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("LibraryCards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CardNumber = "LC-12345",
                            ExpiryDate = new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MemberName = "John Doe"
                        },
                        new
                        {
                            Id = 2,
                            CardNumber = "LC-54321",
                            ExpiryDate = new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MemberName = "Jane Smith"
                        });
                });

            modelBuilder.Entity("dotnetapp.Models.Book", b =>
                {
                    b.HasOne("dotnetapp.Models.LibraryCard", "LibraryCard")
                        .WithOne("Book")
                        .HasForeignKey("dotnetapp.Models.Book", "LibraryCardId");

                    b.Navigation("LibraryCard");
                });

            modelBuilder.Entity("dotnetapp.Models.LibraryCard", b =>
                {
                    b.Navigation("Book")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

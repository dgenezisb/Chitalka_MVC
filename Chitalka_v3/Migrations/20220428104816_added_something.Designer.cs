﻿// <auto-generated />
using System;
using Chitalka_v3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Chitalka_v3.Migrations
{
    [DbContext(typeof(Chitalka_v3Context))]
    [Migration("20220428104816_added_something")]
    partial class added_something
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Chitalka_v3.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Biogr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Books")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("Chitalka_v3.Models.Books", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int?>("CentuaryId")
                        .HasColumnType("int");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<int?>("Genreid")
                        .HasColumnType("int");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("bookInside")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bookName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descriprionBook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("inpAuthor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("inpCentuary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("inpCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("inpGenre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("inpImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CentuaryId");

                    b.HasIndex("CountryId");

                    b.HasIndex("Genreid");

                    b.HasIndex("ImageId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Chitalka_v3.Models.Centuary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Centuary");
                });

            modelBuilder.Entity("Chitalka_v3.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Chitalka_v3.Models.Genre", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("Chitalka_v3.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("big")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("book")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("small")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("Chitalka_v3.Models.Image2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("img")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Image2");
                });

            modelBuilder.Entity("Chitalka_v3.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("ico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ifAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pswrd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usrName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Chitalka_v3.Models.Author", b =>
                {
                    b.HasOne("Chitalka_v3.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Chitalka_v3.Models.Books", b =>
                {
                    b.HasOne("Chitalka_v3.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("Chitalka_v3.Models.Centuary", "Centuary")
                        .WithMany()
                        .HasForeignKey("CentuaryId");

                    b.HasOne("Chitalka_v3.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("Chitalka_v3.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("Genreid");

                    b.HasOne("Chitalka_v3.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.Navigation("Author");

                    b.Navigation("Centuary");

                    b.Navigation("Country");

                    b.Navigation("Genre");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Chitalka_v3.Models.Image2", b =>
                {
                    b.HasOne("Chitalka_v3.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.Navigation("Author");
                });
#pragma warning restore 612, 618
        }
    }
}

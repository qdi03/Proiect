﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect.Data;

#nullable disable

namespace Proiect.Migrations
{
    [DbContext(typeof(ProiectContext))]
    [Migration("20250112105808_Appointments")]
    partial class Appointments
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proiect.Models.Appointment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("AppointmentTime")
                        .HasColumnType("time");

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<int?>("TatuajID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("TatuajID");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("Proiect.Models.Artist", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("Proiect.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Proiect.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Proiect.Models.Salon", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("NumeSalon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Salon");
                });

            modelBuilder.Entity("Proiect.Models.TattooCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("TatuajID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("TatuajID");

                    b.ToTable("TattooCategory");
                });

            modelBuilder.Entity("Proiect.Models.Tatuaj", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ArtistID")
                        .HasColumnType("int");

                    b.Property<int>("Durata")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<int?>("SalonID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ArtistID");

                    b.HasIndex("SalonID");

                    b.ToTable("Tatuaj");
                });

            modelBuilder.Entity("Proiect.Models.Appointment", b =>
                {
                    b.HasOne("Proiect.Models.Client", "Client")
                        .WithMany("Appointments")
                        .HasForeignKey("ClientID");

                    b.HasOne("Proiect.Models.Tatuaj", "Tatuaj")
                        .WithMany("Appointments")
                        .HasForeignKey("TatuajID");

                    b.Navigation("Client");

                    b.Navigation("Tatuaj");
                });

            modelBuilder.Entity("Proiect.Models.TattooCategory", b =>
                {
                    b.HasOne("Proiect.Models.Category", "Category")
                        .WithMany("TattooCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect.Models.Tatuaj", "Tatuaj")
                        .WithMany("TattooCategories")
                        .HasForeignKey("TatuajID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Tatuaj");
                });

            modelBuilder.Entity("Proiect.Models.Tatuaj", b =>
                {
                    b.HasOne("Proiect.Models.Artist", "Artist")
                        .WithMany("Tatuaje")
                        .HasForeignKey("ArtistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect.Models.Salon", "Salon")
                        .WithMany("Tatuaje")
                        .HasForeignKey("SalonID");

                    b.Navigation("Artist");

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("Proiect.Models.Artist", b =>
                {
                    b.Navigation("Tatuaje");
                });

            modelBuilder.Entity("Proiect.Models.Category", b =>
                {
                    b.Navigation("TattooCategories");
                });

            modelBuilder.Entity("Proiect.Models.Client", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Proiect.Models.Salon", b =>
                {
                    b.Navigation("Tatuaje");
                });

            modelBuilder.Entity("Proiect.Models.Tatuaj", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("TattooCategories");
                });
#pragma warning restore 612, 618
        }
    }
}

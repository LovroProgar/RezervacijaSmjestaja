﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RezervacijaSmjestaja.Data;

#nullable disable

namespace RezervacijaSmjestaja.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250203121805_daaaaa")]
    partial class daaaaa
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RezervacijaSmjestaja.Models.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lozinka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("RezervacijaSmjestaja.Models.Rezervacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatumDo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumOd")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("SmjestajId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("SmjestajId");

                    b.ToTable("Rezervacije");
                });

            modelBuilder.Entity("RezervacijaSmjestaja.Models.Smjestaj", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("CijenaPoNoci")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Grad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("SlikaUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Smjestaji");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CijenaPoNoci = 120m,
                            Grad = "Zagreb",
                            Naziv = "Modern City Apartment",
                            Opis = "Luksuzan apartman u centru grada",
                            SlikaUrl = "https://images.pexels.com/photos/271624/pexels-photo-271624.jpeg?w=1280"
                        },
                        new
                        {
                            Id = 2,
                            CijenaPoNoci = 250m,
                            Grad = "Split",
                            Naziv = "Seaside Apartment",
                            Opis = "Apartman s pogledom na more",
                            SlikaUrl = "https://images.pexels.com/photos/164595/pexels-photo-164595.jpeg?w=1280"
                        },
                        new
                        {
                            Id = 3,
                            CijenaPoNoci = 180m,
                            Grad = "Rijeka",
                            Naziv = "Cozy Mountain Loft",
                            Opis = "Moderan loft u planinama",
                            SlikaUrl = "https://images.pexels.com/photos/2102587/pexels-photo-2102587.jpeg?w=1280"
                        },
                        new
                        {
                            Id = 4,
                            CijenaPoNoci = 300m,
                            Grad = "Osijek",
                            Naziv = "Luxury Penthouse",
                            Opis = "Ekskluzivan penthouse s terasom",
                            SlikaUrl = "https://images.pexels.com/photos/258154/pexels-photo-258154.jpeg?w=1280"
                        },
                        new
                        {
                            Id = 5,
                            CijenaPoNoci = 100m,
                            Grad = "Dubrovnik",
                            Naziv = "Rustic Countryside Home",
                            Opis = "Udobna kuća u prirodi",
                            SlikaUrl = "https://images.pexels.com/photos/1643383/pexels-photo-1643383.jpeg?w=1280"
                        },
                        new
                        {
                            Id = 6,
                            CijenaPoNoci = 200m,
                            Grad = "Pula",
                            Naziv = "Tropical Beach Apartment",
                            Opis = "Apartman uz samu plažu",
                            SlikaUrl = "https://images.pexels.com/photos/271619/pexels-photo-271619.jpeg?w=1280"
                        },
                        new
                        {
                            Id = 7,
                            CijenaPoNoci = 160m,
                            Grad = "Zadar",
                            Naziv = "Elegant City Suite",
                            Opis = "Moderan apartman s elegantnim dizajnom",
                            SlikaUrl = "https://images.pexels.com/photos/259950/pexels-photo-259950.jpeg?w=1280"
                        },
                        new
                        {
                            Id = 8,
                            CijenaPoNoci = 220m,
                            Grad = "Šibenik",
                            Naziv = "Hillside Retreat",
                            Opis = "Apartman na osami s predivnim pogledom",
                            SlikaUrl = "https://images.pexels.com/photos/271618/pexels-photo-271618.jpeg?w=1280"
                        },
                        new
                        {
                            Id = 9,
                            CijenaPoNoci = 140m,
                            Grad = "Varaždin",
                            Naziv = "Panoramic View Apartment",
                            Opis = "Apartman s panoramskim pogledom",
                            SlikaUrl = "https://images.pexels.com/photos/276663/pexels-photo-276663.jpeg?w=1280"
                        },
                        new
                        {
                            Id = 10,
                            CijenaPoNoci = 320m,
                            Grad = "Karlovac",
                            Naziv = "Seaview Penthouse",
                            Opis = "Penthouse s pogledom na more",
                            SlikaUrl = "https://images.pexels.com/photos/276554/pexels-photo-276554.jpeg?w=1280"
                        },
                        new
                        {
                            Id = 11,
                            CijenaPoNoci = 110m,
                            Grad = "Makarska",
                            Naziv = "Downtown Studio",
                            Opis = "Minimalistički studio u centru",
                            SlikaUrl = "https://images.pexels.com/photos/276671/pexels-photo-276671.jpeg?w=1280"
                        },
                        new
                        {
                            Id = 12,
                            CijenaPoNoci = 130m,
                            Grad = "Hvar",
                            Naziv = "Wooden Chalet",
                            Opis = "Planinska brvnara za potpuni odmor",
                            SlikaUrl = "https://images.pexels.com/photos/1643386/pexels-photo-1643386.jpeg?w=1280"
                        },
                        new
                        {
                            Id = 13,
                            CijenaPoNoci = 400m,
                            Grad = "Zadar",
                            Naziv = "Luxury Villa",
                            Opis = "Privatna vila s bazenom",
                            SlikaUrl = "https://images.pexels.com/photos/164595/pexels-photo-164595.jpeg?w=1280"
                        },
                        new
                        {
                            Id = 14,
                            CijenaPoNoci = 175m,
                            Grad = "Šibenik",
                            Naziv = "Modern Apartment",
                            Opis = "Stilno uređen apartman u centru",
                            SlikaUrl = "https://images.pexels.com/photos/276663/pexels-photo-276663.jpeg?w=1280"
                        },
                        new
                        {
                            Id = 15,
                            CijenaPoNoci = 145m,
                            Grad = "Plitvice",
                            Naziv = "Open Space Loft",
                            Opis = "Prostrani loft s modernim dizajnom",
                            SlikaUrl = "https://images.pexels.com/photos/276652/pexels-photo-276652.jpeg?w=1280"
                        },
                        new
                        {
                            Id = 16,
                            CijenaPoNoci = 135m,
                            Grad = "Dubrovnik",
                            Naziv = "City Center Apartment",
                            Opis = "Savršeno mjesto za urbane nomade",
                            SlikaUrl = "https://images.pexels.com/photos/276671/pexels-photo-276671.jpeg?w=1280"
                        });
                });

            modelBuilder.Entity("RezervacijaSmjestaja.Models.Rezervacija", b =>
                {
                    b.HasOne("RezervacijaSmjestaja.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RezervacijaSmjestaja.Models.Smjestaj", "Smjestaj")
                        .WithMany()
                        .HasForeignKey("SmjestajId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");

                    b.Navigation("Smjestaj");
                });
#pragma warning restore 612, 618
        }
    }
}

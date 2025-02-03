using Microsoft.EntityFrameworkCore;
using RezervacijaSmjestaja.Models;

namespace RezervacijaSmjestaja.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Smjestaj> Smjestaji { get; set; }

        public DbSet<Korisnik> Korisnici { get; set; }

        public DbSet<Rezervacija> Rezervacije { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Smjestaj>()
                .Property(s => s.CijenaPoNoci)
                .HasColumnType("decimal(18,2)");

            
            modelBuilder.Entity<Smjestaj>().HasData(
        new Smjestaj
        {
            Id = 1,
            Naziv = "Modern City Apartment",
            Opis = "Luksuzan apartman u centru grada",
            SlikaUrl = "https://images.pexels.com/photos/439391/pexels-photo-439391.jpeg?w=1280",
            CijenaPoNoci = 120,
            Grad = "Zagreb"
        },
        new Smjestaj
        {
            Id = 2,
            Naziv = "Seaside Apartment",
            Opis = "Apartman s pogledom na more",
            SlikaUrl = "https://images.pexels.com/photos/439416/pexels-photo-439416.jpeg?w=1280",
            CijenaPoNoci = 250,
            Grad = "Split"
        },
        new Smjestaj
        {
            Id = 3,
            Naziv = "Cozy Mountain Loft",
            Opis = "Moderan loft u planinama",
            SlikaUrl = "https://images.pexels.com/photos/276651/pexels-photo-276651.jpeg?w=1280",
            CijenaPoNoci = 180,
            Grad = "Rijeka"
        },
        new Smjestaj
        {
            Id = 4,
            Naziv = "Luxury Penthouse",
            Opis = "Ekskluzivan penthouse s terasom",
            SlikaUrl = "https://images.pexels.com/photos/707581/pexels-photo-707581.jpeg?w=1280",
            CijenaPoNoci = 300,
            Grad = "Osijek"
        },
        new Smjestaj
        {
            Id = 5,
            Naziv = "Rustic Countryside Home",
            Opis = "Udobna kuća u prirodi",
            SlikaUrl = "https://images.pexels.com/photos/279746/pexels-photo-279746.jpeg?w=1280",
            CijenaPoNoci = 100,
            Grad = "Dubrovnik"
        },
        new Smjestaj
        {
            Id = 6,
            Naziv = "Tropical Beach Apartment",
            Opis = "Apartman uz samu plažu",
            SlikaUrl = "https://images.pexels.com/photos/271618/pexels-photo-271618.jpeg?w=1280",
            CijenaPoNoci = 200,
            Grad = "Pula"
        },
        new Smjestaj
        {
            Id = 7,
            Naziv = "Elegant City Suite",
            Opis = "Moderan apartman s elegantnim dizajnom",
            SlikaUrl = "https://images.pexels.com/photos/164595/pexels-photo-164595.jpeg?w=1280",
            CijenaPoNoci = 160,
            Grad = "Zadar"
        },
        new Smjestaj
        {
            Id = 8,
            Naziv = "Hillside Retreat",
            Opis = "Apartman na osami s predivnim pogledom",
            SlikaUrl = "https://images.pexels.com/photos/2029738/pexels-photo-2029738.jpeg?w=1280",
            CijenaPoNoci = 220,
            Grad = "Šibenik"
        },
        new Smjestaj
        {
            Id = 9,
            Naziv = "Panoramic View Apartment",
            Opis = "Apartman s panoramskim pogledom",
            SlikaUrl = "https://images.pexels.com/photos/2089698/pexels-photo-2089698.jpeg?w=1280",
            CijenaPoNoci = 140,
            Grad = "Varaždin"
        },
        new Smjestaj
        {
            Id = 10,
            Naziv = "Seaview Penthouse",
            Opis = "Penthouse s pogledom na more",
            SlikaUrl = "https://images.pexels.com/photos/1438834/pexels-photo-1438834.jpeg?w=1280",
            CijenaPoNoci = 320,
            Grad = "Karlovac"
        },
        new Smjestaj
        {
            Id = 11,
            Naziv = "Downtown Studio",
            Opis = "Minimalistički studio u centru",
            SlikaUrl = "https://images.pexels.com/photos/276671/pexels-photo-276671.jpeg?w=1280",
            CijenaPoNoci = 110,
            Grad = "Makarska"
        },
        new Smjestaj
        {
            Id = 12,
            Naziv = "Wooden Chalet",
            Opis = "Planinska brvnara za potpuni odmor",
            SlikaUrl = "https://images.pexels.com/photos/271618/pexels-photo-271618.jpeg?w=1280",
            CijenaPoNoci = 130,
            Grad = "Hvar"
        },
        new Smjestaj
        {
            Id = 13,
            Naziv = "Luxury Villa",
            Opis = "Privatna vila s bazenom",
            SlikaUrl = "https://images.pexels.com/photos/276554/pexels-photo-276554.jpeg?w=1280",
            CijenaPoNoci = 400,
            Grad = "Zadar"
        },
        new Smjestaj
        {
            Id = 14,
            Naziv = "Modern Apartment",
            Opis = "Stilno uređen apartman u centru",
            SlikaUrl = "https://images.pexels.com/photos/439416/pexels-photo-439416.jpeg?w=1280",
            CijenaPoNoci = 175,
            Grad = "Šibenik"
        },
        new Smjestaj
        {
            Id = 15,
            Naziv = "Open Space Loft",
            Opis = "Prostrani loft s modernim dizajnom",
            SlikaUrl = "https://images.pexels.com/photos/439391/pexels-photo-439391.jpeg?w=1280",
            CijenaPoNoci = 145,
            Grad = "Plitvice"
        },
        new Smjestaj
        {
            Id = 16,
            Naziv = "City Center Apartment",
            Opis = "Savršeno mjesto za urbane nomade",
            SlikaUrl = "https://images.pexels.com/photos/276671/pexels-photo-276671.jpeg?w=1280",
            CijenaPoNoci = 135,
            Grad = "Dubrovnik"
        }
    );
        }
    }
}

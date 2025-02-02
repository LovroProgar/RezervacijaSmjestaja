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

            // 📌 Dodavanje smještaja u bazu pri svakom pokretanju aplikacije
            modelBuilder.Entity<Smjestaj>().HasData(
                new Smjestaj { Id = 1, Naziv = "Hotel Blue Lagoon", Opis = "Luksuzan hotel uz obalu", SlikaUrl = "/pictures/1.jpg", CijenaPoNoci = 120 },
                new Smjestaj { Id = 2, Naziv = "Villa Sun", Opis = "Privatna vila s bazenom", SlikaUrl = "/pictures/2.jpg", CijenaPoNoci = 250 },
                new Smjestaj { Id = 3, Naziv = "Mountain Resort", Opis = "Odmaralište u planinama", SlikaUrl = "/pictures/3.jpg", CijenaPoNoci = 180 },
                new Smjestaj { Id = 4, Naziv = "Apartman Deluxe", Opis = "Moderan apartman u centru", SlikaUrl = "/pictures/4.jpg", CijenaPoNoci = 100 },
                new Smjestaj { Id = 5, Naziv = "Seoska Kuća", Opis = "Mirno mjesto za odmor", SlikaUrl = "/pictures/5.jpg", CijenaPoNoci = 80 },
                new Smjestaj { Id = 6, Naziv = "Beach House", Opis = "Kuća na plaži s pogledom", SlikaUrl = "/pictures/6.jpg", CijenaPoNoci = 200 }
            );
        }
    }
}

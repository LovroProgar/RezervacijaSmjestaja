using Microsoft.EntityFrameworkCore;
using RezervacijaSmjestaja.Models;

namespace RezervacijaSmjestaja.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Smjestaj> Smjestaji { get; set; }
        public DbSet<Rezervacija> Rezervacije { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Dodajte ovu liniju za specifično podešavanje CijenaPoNoci
            modelBuilder.Entity<Smjestaj>()
                .Property(s => s.CijenaPoNoci)
                .HasColumnType("decimal(18,2)");  // Preciznost 18, skala 2 (dva decimalna mjesta)

            // Seed podaci za Smjestaj
            modelBuilder.Entity<Smjestaj>().HasData(
                new Smjestaj { Id = 1, Naziv = "Hotel Blue Lagoon", Opis = "Luksuzan hotel uz obalu", SlikaUrl = "/pictures/1.jpg", CijenaPoNoci = 120m},
                new Smjestaj { Id = 2, Naziv = "Villa Sun", Opis = "Privatna vila s bazenom", SlikaUrl = "/pictures/2.jpg", CijenaPoNoci = 250m },
                new Smjestaj { Id = 3, Naziv = "Mountain Resort", Opis = "Odmaralište u planinama", SlikaUrl = "/pictures/3.jpg", CijenaPoNoci = 180m },
                new Smjestaj { Id = 4, Naziv = "Apartman Deluxe", Opis = "Moderan apartman u centru", SlikaUrl = "/pictures/4.jpg", CijenaPoNoci = 100m },
                new Smjestaj { Id = 5, Naziv = "Seoska Kuća", Opis = "Mirno mjesto za odmor", SlikaUrl = "/pictures/5.jpg", CijenaPoNoci = 80m},
                new Smjestaj { Id = 6, Naziv = "Beach House", Opis = "Kuća na plaži s pogledom", SlikaUrl = "/pictures/6.jpg", CijenaPoNoci = 200m}
            );
        }
    }
}
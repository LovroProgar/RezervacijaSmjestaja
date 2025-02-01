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
        }
    }
}
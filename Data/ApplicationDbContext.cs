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
        public DbSet<Rezervacija> Rezervacije { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Smjestaj>()
                .Property(s => s.CijenaPoNoci)
                .HasColumnType("decimal(18,2)");

            // Uklonili smo "HasData()" kako bi smještaji više ne dolazili iz baze
        }
    }
}

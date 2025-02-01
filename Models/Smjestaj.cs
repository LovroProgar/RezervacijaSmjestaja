using System.ComponentModel.DataAnnotations;

namespace RezervacijaSmjestaja.Models
{
    public class Smjestaj
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        [Required]
        public string Opis { get; set; }

        [Required]
        public string SlikaUrl { get; set; } // Link do slike

        [Required]
        public decimal CijenaPoNoci { get; set; }
    }
}

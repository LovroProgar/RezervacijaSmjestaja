using System.ComponentModel.DataAnnotations;

namespace RezervacijaSmjestaja.Models
{
    public class Smjestaj
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]  // Ograničenje za dužinu naziva smještaja
        public string Naziv { get; set; }

        [Required]
        [StringLength(500)]  // Ograničenje za dužinu opisa smještaja
        public string Opis { get; set; }

        [Required]
        public string SlikaUrl { get; set; } // Link do slike

        [Required]
        [Range(0, 9999.99)] // Ograničenje za cijenu po noći (od 0 do 9999.99)
        public decimal CijenaPoNoci { get; set; }
    }
}

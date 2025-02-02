using System.ComponentModel.DataAnnotations;

namespace RezervacijaSmjestaja.Models
{
    public class Smjestaj
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Naziv { get; set; }

        [Required]
        [StringLength(500)]
        public string Opis { get; set; }

        [Required]
        public string SlikaUrl { get; set; }

        [Required]
        [Range(0, 9999.99)]
        public decimal CijenaPoNoci { get; set; }

        [Required] // 📌 Dodano polje za grad
        [StringLength(100)]
        public string Grad { get; set; }
    }
}

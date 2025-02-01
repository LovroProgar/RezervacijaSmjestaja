using System.ComponentModel.DataAnnotations;

namespace RezervacijaSmjestaja.Models
{
    public class Korisnik
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Lozinka { get; set; }
    }
}
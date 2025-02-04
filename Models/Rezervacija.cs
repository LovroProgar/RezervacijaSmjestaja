﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RezervacijaSmjestaja.Models
{
    public class Rezervacija
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SmjestajId { get; set; }

        [ForeignKey("SmjestajId")]
        public Smjestaj Smjestaj { get; set; }

        [Required]
        public int KorisnikId { get; set; } // 🔹 Veza na korisnika

        [ForeignKey("KorisnikId")]
        public Korisnik Korisnik { get; set; } // 🔹 Povezano s korisnikom

        [Required]
        public DateTime DatumOd { get; set; }

        [Required]
        public DateTime DatumDo { get; set; }
    }
}

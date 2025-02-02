using Microsoft.AspNetCore.Mvc;
using RezervacijaSmjestaja.Models;
using System.Collections.Generic;

namespace RezervacijaSmjestaja.Controllers
{
    public class SmjestajController : Controller
    {
        private static List<Smjestaj> _smjestaji = new List<Smjestaj>
        {
            new Smjestaj { Id = 1, Naziv = "Hotel Blue Lagoon", Opis = "Luksuzan hotel uz obalu", SlikaUrl = "/pictures/1.jpg", CijenaPoNoci = 120m },
            new Smjestaj { Id = 2, Naziv = "Villa Sun", Opis = "Privatna vila s bazenom", SlikaUrl = "/pictures/2.jpg", CijenaPoNoci = 250m },
            new Smjestaj { Id = 3, Naziv = "Mountain Resort", Opis = "Odmaralište u planinama", SlikaUrl = "/pictures/3.jpg", CijenaPoNoci = 180m },
            new Smjestaj { Id = 4, Naziv = "Apartman Deluxe", Opis = "Moderan apartman u centru", SlikaUrl = "/pictures/4.jpg", CijenaPoNoci = 100m },
            new Smjestaj { Id = 5, Naziv = "Seoska Kuća", Opis = "Mirno mjesto za odmor", SlikaUrl = "/pictures/5.jpg", CijenaPoNoci = 80m },
            new Smjestaj { Id = 6, Naziv = "Beach House", Opis = "Kuća na plaži s pogledom", SlikaUrl = "/pictures/6.jpg", CijenaPoNoci = 200m }
        };

        public IActionResult Index()
        {
            return View(_smjestaji);
        }

        public IActionResult Detalji(int id)
        {
            var smjestaj = _smjestaji.Find(s => s.Id == id);
            if (smjestaj == null)
                return NotFound();

            return View(smjestaj);
        }
    }
}

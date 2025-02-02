using Microsoft.AspNetCore.Mvc;
using RezervacijaSmjestaja.Models;
using System.Collections.Generic;
using System.Linq;

namespace RezervacijaSmjestaja.Controllers
{
    public class RezervacijaController : Controller
    {
        private static List<Rezervacija> _rezervacije = new List<Rezervacija>();

        private static List<Smjestaj> _smjestaji = new List<Smjestaj>
        {
            new Smjestaj { Id = 1, Naziv = "Hotel Blue Lagoon", Opis = "Luksuzan hotel uz obalu", SlikaUrl = "/pictures/1.jpg", CijenaPoNoci = 120m },
            new Smjestaj { Id = 2, Naziv = "Villa Sun", Opis = "Privatna vila s bazenom", SlikaUrl = "/pictures/2.jpg", CijenaPoNoci = 250m },
            new Smjestaj { Id = 3, Naziv = "Mountain Resort", Opis = "Odmaralište u planinama", SlikaUrl = "/pictures/3.jpg", CijenaPoNoci = 180m },
            new Smjestaj { Id = 4, Naziv = "Apartman Deluxe", Opis = "Moderan apartman u centru", SlikaUrl = "/pictures/4.jpg", CijenaPoNoci = 100m },
            new Smjestaj { Id = 5, Naziv = "Seoska Kuća", Opis = "Mirno mjesto za odmor", SlikaUrl = "/pictures/5.jpg", CijenaPoNoci = 80m },
            new Smjestaj { Id = 6, Naziv = "Beach House", Opis = "Kuća na plaži s pogledom", SlikaUrl = "/pictures/6.jpg", CijenaPoNoci = 200m }
        };

        public IActionResult Rezerviraj(int smjestajId)
        {
            var smjestaj = _smjestaji.FirstOrDefault(s => s.Id == smjestajId);
            if (smjestaj == null) return NotFound();

            var model = new Rezervacija
            {
                SmjestajId = smjestajId,
                Smjestaj = smjestaj
            };

            return View(model);
        }

        public IActionResult PotvrdiRezervaciju(int smjestajId, DateTime datumOd, DateTime datumDo)
        {
            var smjestaj = _smjestaji.FirstOrDefault(s => s.Id == smjestajId);
            if (smjestaj == null) return NotFound();

            var model = new Rezervacija
            {
                Id = _rezervacije.Count + 1,
                SmjestajId = smjestajId,
                Smjestaj = smjestaj,
                DatumOd = datumOd,
                DatumDo = datumDo
            };

            _rezervacije.Add(model);
            return RedirectToAction("MojeRezervacije");
        }

        public IActionResult MojeRezervacije()
        {
            return View(_rezervacije);
        }

        public IActionResult ObrisiRezervaciju(int id)
        {
            var rezervacija = _rezervacije.FirstOrDefault(r => r.Id == id);
            if (rezervacija != null)
            {
                _rezervacije.Remove(rezervacija);
            }
            return RedirectToAction("MojeRezervacije");
        }

        public IActionResult PromijeniDatume(int id, DateTime datumOd, DateTime datumDo)
        {
            var rezervacija = _rezervacije.FirstOrDefault(r => r.Id == id);
            if (rezervacija != null && datumOd < datumDo)
            {
                rezervacija.DatumOd = datumOd;
                rezervacija.DatumDo = datumDo;
            }
            return RedirectToAction("MojeRezervacije");
        }
    }
}

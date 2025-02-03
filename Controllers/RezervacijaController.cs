using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RezervacijaSmjestaja.Data;
using RezervacijaSmjestaja.Models;
using System;
using System.Linq;

namespace RezervacijaSmjestaja.Controllers
{
    public class RezervacijaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RezervacijaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Rezerviraj(int smjestajId)
        {
            var smjestaj = _context.Smjestaji.FirstOrDefault(s => s.Id == smjestajId);
            if (smjestaj == null)
            {
                return NotFound();
            }

            var model = new Rezervacija
            {
                SmjestajId = smjestajId,
                Smjestaj = smjestaj
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult PotvrdiRezervaciju(int smjestajId, DateTime datumOd, DateTime datumDo)
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Login", "Account");
            }

            var korisnik = _context.Korisnici.FirstOrDefault(k => k.Email == userEmail);
            if (korisnik == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var smjestaj = _context.Smjestaji.FirstOrDefault(s => s.Id == smjestajId);
            if (smjestaj == null)
            {
                return NotFound();
            }

            // 🔹 Provjera da korisnik ne može rezervirati isti smještaj u istom terminu više puta
            bool vecRezerviranoZaIstogKorisnika = _context.Rezervacije.Any(r =>
                r.SmjestajId == smjestajId &&
                r.KorisnikId == korisnik.Id &&
                ((datumOd >= r.DatumOd && datumOd < r.DatumDo) ||
                 (datumDo > r.DatumOd && datumDo <= r.DatumDo) ||
                 (datumOd <= r.DatumOd && datumDo >= r.DatumDo)));

            if (vecRezerviranoZaIstogKorisnika)
            {
                TempData["Greska"] = "Već imate rezervaciju za ovaj smještaj u odabranom terminu!";
                return RedirectToAction("Rezerviraj", new { smjestajId });
            }

            // 🔹 Provjera da **bilo koji drugi korisnik** ne može rezervirati smještaj koji je zauzet u istom terminu
            bool vecRezerviranoOdDrugogKorisnika = _context.Rezervacije.Any(r =>
                r.SmjestajId == smjestajId &&
                ((datumOd >= r.DatumOd && datumOd < r.DatumDo) ||
                 (datumDo > r.DatumOd && datumDo <= r.DatumDo) ||
                 (datumOd <= r.DatumOd && datumDo >= r.DatumDo)));

            if (vecRezerviranoOdDrugogKorisnika)
            {
                TempData["Greska"] = "Odabrani smještaj je već rezerviran u odabranom terminu!";
                return RedirectToAction("Rezerviraj", new { smjestajId });
            }

            var rezervacija = new Rezervacija
            {
                SmjestajId = smjestajId,
                KorisnikId = korisnik.Id, // Vežemo rezervaciju za korisnika
                DatumOd = datumOd,
                DatumDo = datumDo
            };

            _context.Rezervacije.Add(rezervacija);
            _context.SaveChanges();

            return RedirectToAction("MojeRezervacije");
        }

        public IActionResult MojeRezervacije()
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Login", "Account");
            }

            var korisnik = _context.Korisnici.FirstOrDefault(k => k.Email == userEmail);
            if (korisnik == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var rezervacije = _context.Rezervacije
                .Include(r => r.Smjestaj)
                .Where(r => r.KorisnikId == korisnik.Id) // Filtriramo samo rezervacije prijavljenog korisnika
                .ToList();

            return View(rezervacije);
        }

        public IActionResult ObrisiRezervaciju(int id)
        {
            var rezervacija = _context.Rezervacije.FirstOrDefault(r => r.Id == id);
            if (rezervacija != null)
            {
                _context.Rezervacije.Remove(rezervacija);
                _context.SaveChanges();
            }
            return RedirectToAction("MojeRezervacije");
        }

        public IActionResult PromijeniDatume(int id, DateTime datumOd, DateTime datumDo)
        {
            var rezervacija = _context.Rezervacije.FirstOrDefault(r => r.Id == id);
            if (rezervacija != null && datumOd >= DateTime.Today && datumDo > datumOd)
            {
                rezervacija.DatumOd = datumOd;
                rezervacija.DatumDo = datumDo;
                _context.SaveChanges();
            }
            return RedirectToAction("MojeRezervacije");
        }
    }
}

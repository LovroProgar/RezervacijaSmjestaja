using Microsoft.AspNetCore.Mvc;
using RezervacijaSmjestaja.Data;
using RezervacijaSmjestaja.Models;
using Microsoft.AspNetCore.Http;

namespace RezervacijaSmjestaja.Controllers
{
    public class RezervacijaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RezervacijaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult MojeRezervacije()
        {
            string email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(email))
                return RedirectToAction("Login", "Account");

            var korisnik = _context.Korisnici.FirstOrDefault(k => k.Email == email);
            if (korisnik == null)
                return RedirectToAction("Login", "Account");

            var rezervacije = _context.Rezervacije
                .Where(r => r.KorisnikId == korisnik.Id)
                .ToList();

            return View(rezervacije);
        }

        public IActionResult Rezervisi(int smjestajId)
        {
            return View(new Rezervacija { SmjestajId = smjestajId });
        }

        [HttpPost]
        public IActionResult Rezervisi(Rezervacija rezervacija)
        {
            if (ModelState.IsValid)
            {
                _context.Rezervacije.Add(rezervacija);
                _context.SaveChanges();
                return RedirectToAction("MojeRezervacije");
            }
            return View(rezervacija);
        }
    }
}
